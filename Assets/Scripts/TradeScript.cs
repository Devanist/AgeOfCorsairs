using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Assets.Enums;
using Assets.Models;
using Assets.Models.Items;
using UnityEngine;
using UnityEngine.UI;


public class TradeScript : MonoBehaviour
{
    private int _moneyToSpend, _moneyToEarn;

    private Wallet _shopWallet;
    private Wallet _playerWallet;
    private Warehouse _shopWarehouse;
    private Warehouse _playerWarehouse;


    public GameObject Hud;

    public GameObject Player { get; set; }

    public IList<TradeItem> ItemsToBuy = new List<TradeItem>();
    public IList<TradeItem> ItemsToSell = new List<TradeItem>();

    void Awake()
    {
       
    }

    void Start()
    {
        GetComponents();
        GenerateItems();
    }


    void Update()
    {

    }

    private void GetComponents()
    {
        _shopWallet = GetComponent<Wallet>();
        _shopWarehouse = GetComponent<Warehouse>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        _playerWallet = Player.GetComponent<Wallet>();
        _playerWarehouse = Player.GetComponent<Warehouse>();

        SetHudLabels();
        SetTradeCashLabels();
    }

    private void GenerateItems()
    {
        
        foreach (var shopItem in _shopWarehouse.Items)
        {
            ItemsToBuy.Add(new TradeItem { Item = shopItem, Price = 20 });
        }

        foreach (var playerItem in _playerWarehouse.Items)
        {
            ItemsToSell.Add(new TradeItem { Item = playerItem, Price = 20 });
        }

    }

    void SetHudLabels()
    {
        var cashAmountTradesmanLabel = Hud.transform.Find("CashAmountTradesmanLabel");
        var cashAmountPlayerLabel = Hud.transform.Find("CashAmountPlayerLabel");
        
        cashAmountTradesmanLabel.GetComponent<Text>().text = _shopWallet.CashAmount.ToString();
        cashAmountPlayerLabel.GetComponent<Text>().text = _playerWallet.CashAmount.ToString();

    }

    void SetTradeCashLabels()
    {
        var tradeCashAmountTradesmanLabel = Hud.transform.Find("TradeCashAmountTradesmanLabel");
        var tradeCashAmountPlayerLabel = Hud.transform.Find("TradeCashAmountPlayerLabel");

        tradeCashAmountTradesmanLabel.GetComponent<Text>().text = _moneyToSpend.ToString();
        tradeCashAmountPlayerLabel.GetComponent<Text>().text = _moneyToEarn.ToString();
    }

    public void AcceptTrade()
    {

        var playerMoney = _playerWallet.CashAmount - _moneyToSpend + _moneyToEarn;
        var shopMoney = _shopWallet.CashAmount - _moneyToEarn + _moneyToSpend;

        if (playerMoney < 0 || shopMoney < 0)
            return;

        foreach (var buyItem in ItemsToBuy)
        {
            var playerItem = _playerWarehouse.Items.Single(i => i.ItemType == buyItem.Item.ItemType);
            playerItem.Amount += buyItem.TradeAmount;

            buyItem.TradeAmount = 0;
        }

        foreach (var sellItem in ItemsToSell)
        {
            var shopItem = _shopWarehouse.Items.Single(i => i.ItemType == sellItem.Item.ItemType);
            shopItem.Amount += sellItem.TradeAmount;
            sellItem.TradeAmount = 0;
        }


        _playerWallet.CashAmount = playerMoney;
        _shopWallet.CashAmount = shopMoney;

        _moneyToSpend = 0;
        _moneyToEarn = 0;

        SetHudLabels();
        SetTradeCashLabels();
    }

    public void RaiseBuyAmount(string itemType)
    {
        var item = ItemsToBuy.Single(i => i.Item.ItemType.ToString().ToLower() == itemType.ToLower());

        if (item.Item.Amount <= 0)
            return;

        item.Item.Amount--;
        item.TradeAmount++;

        _moneyToSpend += item.Price;

        SetTradeCashLabels();

    }

    public void RaiseSellAmount(string itemType)
    {
        var item = ItemsToSell.Single(i => i.Item.ItemType.ToString().ToLower() == itemType.ToLower());

        if (item.Item.Amount <= 0)
            return;

        item.Item.Amount--;
        item.TradeAmount++;

        _moneyToEarn += item.Price;

        SetTradeCashLabels();
    }

    public void DecreaseBuyAmount(string itemType)
    {
        var item = ItemsToBuy.Single(i => i.Item.ItemType.ToString().ToLower() == itemType.ToLower());

        if (item.TradeAmount <= 0)
            return;

        item.Item.Amount++;
        item.TradeAmount--;

        _moneyToSpend -= item.Price;

        SetTradeCashLabels();
    }

    public void DecreaseSellAmount(string itemType)
    {
        var item = ItemsToSell.Single(i => i.Item.ItemType.ToString().ToLower() == itemType.ToLower());


        if (item.TradeAmount <= 0)
            return;

        item.Item.Amount++;
        item.TradeAmount--;

        _moneyToEarn -= item.Price;

        SetTradeCashLabels();
    }
}

