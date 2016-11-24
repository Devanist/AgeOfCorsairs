using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Enums;
using Assets.Models;
using Assets.Models.Items;
using UnityEngine;
using UnityEngine.UI;


public class TradeScript : MonoBehaviour
{
    private Wallet _shopWallet;
    private Warehouse _shopWarehouse;
    public Wallet PlayerWallet { get; set; }
    public Warehouse PlayerWarehouse { get; set; }

    public GameObject Player { get; set; }

    public IList<TradeItem> ItemsToBuy = new List<TradeItem>();
    public IList<TradeItem> ItemsToSell = new List<TradeItem>();


    public Text GunpowderTotalAmountBuyText;
    public Text GunpowderTotalAmountSellText;
    public Text GunpowderTradeAmountBuyText;
    public Text GunpowderTradeAmountSellText;


    void Start()
    {
        _shopWallet = GetComponent<Wallet>();
        _shopWarehouse = GetComponent<Warehouse>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        PlayerWallet = Player.GetComponent<Wallet>();
        PlayerWarehouse = Player.GetComponent<Warehouse>();

        foreach (var shopItem in _shopWarehouse.Items)
        {
            ItemsToBuy.Add(new TradeItem { Name = shopItem.Name, Amount = shopItem.Amount, TradeAmount = 0, ItemType = shopItem.ItemType, Price = 10 });
        }

        foreach (var playerItem in PlayerWarehouse.Items)
        {
            ItemsToSell.Add(new TradeItem { Name = playerItem.Name, Amount = playerItem.Amount, TradeAmount = 0, ItemType = playerItem.ItemType, Price = 5 });
        }

    }

    void Update()
    {
        GunpowderTotalAmountBuyText.text =
            ItemsToBuy.Single(i => i.ItemType == ItemType.Rum).Amount.ToString();

        GunpowderTotalAmountSellText.text =
           ItemsToSell.Single(i => i.ItemType == ItemType.Rum).Amount.ToString();

        GunpowderTradeAmountBuyText.text =
            ItemsToBuy.Single(i => i.ItemType == ItemType.Rum).TradeAmount.ToString();

        GunpowderTradeAmountSellText.text =
           ItemsToSell.Single(i => i.ItemType == ItemType.Rum).TradeAmount.ToString();
    }

    public void AcceptTrade()
    {
        float earnedMoney = 0;
        float spentMoney = 0;

        foreach (var buyItem in ItemsToBuy)
        {
            spentMoney = buyItem.TradeAmount * buyItem.Price;
        }

        foreach (var sellItem in ItemsToSell)
        {
            earnedMoney = sellItem.TradeAmount * sellItem.Price;
        }

        var playerMoney = PlayerWallet.CashAmount - spentMoney + earnedMoney;

        if (playerMoney < 0)
            return;

        foreach (var buyItem in ItemsToBuy)
        {
            var playerItem = PlayerWarehouse.Items.Single(i => i.ItemType == buyItem.ItemType);
            playerItem.Amount += buyItem.TradeAmount;

            var shopItem = _shopWarehouse.Items.Single(i => i.ItemType == buyItem.ItemType);
            shopItem.Amount -= buyItem.TradeAmount;
            buyItem.TradeAmount = 0;
        }

        foreach (var sellItem in ItemsToSell)
        {
            var playerItem = PlayerWarehouse.Items.Single(i => i.ItemType == sellItem.ItemType);
            playerItem.Amount -= sellItem.TradeAmount;

            var shopItem = _shopWarehouse.Items.Single(i => i.ItemType == sellItem.ItemType);
            shopItem.Amount += sellItem.TradeAmount;
            sellItem.TradeAmount = 0;
        }


        

    }

    public void RaiseBuyAmount(string x)
    {
        var item = ItemsToBuy.Single(i => i.ItemType.ToString().ToLower() == x);

        if (item.Amount <= 0)
            return;

        item.Amount--;
        item.TradeAmount++;
    }

    public void RaiseSellAmount(string x)
    {
        var item = ItemsToSell.Single(i => i.ItemType.ToString().ToLower() == x);

        if (item.Amount <= 0)
            return;

        item.Amount--;
        item.TradeAmount++;
    }

    public void DecreaseBuyAmount(string x)
    {
        var item = ItemsToBuy.Single(i => i.ItemType.ToString().ToLower() == x);

        if (item.TradeAmount <= 0)
            return;

        item.Amount++;
        item.TradeAmount--;
    }

    public void DecreaseSellAmount(string x)
    {
        var item = ItemsToSell.Single(i => i.ItemType.ToString().ToLower() == x);


        if (item.TradeAmount <= 0)
            return;

        item.Amount++;
        item.TradeAmount--;
    }
}

