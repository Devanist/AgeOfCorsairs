using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Enums;
using UnityEngine.UI;

public class ShopItemButtons : MonoBehaviour
{
    private TradeScript _tradeScript;
    private RectTransform _itemsPanelRectTransform;
    private IList<ShopItemPanel> _shopItemPanels;

    public GameObject ItemPanelPrefab;
    public GameObject ItemsPanel;



    // Use this for initialization
    void Start()
    {
        _shopItemPanels = new List<ShopItemPanel>();
        _tradeScript = transform.parent.GetComponent<TradeScript>();

        _itemsPanelRectTransform = ItemsPanel.GetComponent<RectTransform>();

        GenerateItemsButtons();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var itemPanel in _shopItemPanels)
        {
            SetPanelLabelsText(itemPanel);
        }
    }

    void GenerateItemsButtons()
    {
        int i = 0;

        foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            GameObject panel = Instantiate(ItemPanelPrefab);
            var ShopItemPanel = new ShopItemPanel {ItemType = item, Panel = panel};
            _shopItemPanels.Add(ShopItemPanel);

            var imageObject = panel.transform.Find("Image");

            var buttonPlusBuy = panel.transform.Find("Buttons/ButtonPlusBuy");
            var buttonMinusBuy = panel.transform.Find("Buttons/ButtonMinusBuy");
            var buttonPlusSell = panel.transform.Find("Buttons/ButtonPlusSell");
            var buttonMinusSell = panel.transform.Find("Buttons/ButtonMinusSell");

            imageObject.GetComponent<Image>().sprite = GetItemImageByType(item);

            var item1 = item;
            buttonPlusBuy.GetComponent<Button>().onClick.AddListener(() => _tradeScript.RaiseBuyAmount(item1.ToString()));
            buttonMinusBuy.GetComponent<Button>().onClick.AddListener(() => _tradeScript.DecreaseBuyAmount(item1.ToString()));
            buttonPlusSell.GetComponent<Button>().onClick.AddListener(() => _tradeScript.RaiseSellAmount(item1.ToString()));
            buttonMinusSell.GetComponent<Button>().onClick.AddListener(() => _tradeScript.DecreaseSellAmount(item1.ToString()));

            panel.transform.SetParent(ItemsPanel.transform, false);
            panel.transform.localScale = new Vector3(1, 1, 1);
            panel.transform.localPosition = new Vector3(0, 0 - i * 70, 0);

            _itemsPanelRectTransform.sizeDelta = new Vector2(_itemsPanelRectTransform.sizeDelta.x, _itemsPanelRectTransform.sizeDelta.y + 70);

            SetPanelLabelsText(ShopItemPanel);

            i++;
        }
    }

    Sprite GetItemImageByType(ItemType type)
    {
        switch (type)
        {
            case ItemType.Rum:
                return Resources.Load("Textures/Rum", typeof(Sprite)) as Sprite;
            case ItemType.Gunpowder:
                return Resources.Load("Textures/Gunpowder", typeof(Sprite)) as Sprite;
            case ItemType.Cotton:
                return Resources.Load("Textures/Cotton", typeof(Sprite)) as Sprite;
            case ItemType.Spices:
                return Resources.Load("Textures/Spices", typeof(Sprite)) as Sprite;
            case ItemType.Tobacco:
                return Resources.Load("Textures/Tobacco", typeof(Sprite)) as Sprite;
            default:
                return Resources.Load("Textures/Rum", typeof(Sprite)) as Sprite;

        }
    }

    private void SetPanelLabelsText(ShopItemPanel panel)
    {
        var labelTradeAmountBuy = panel.Panel.transform.Find("Labels/LabelTradeAmountBuy");
        var labelTotalAmountBuy = panel.Panel.transform.Find("Labels/LabelTotalAmountBuy");
        var labelTradeAmountSell = panel.Panel.transform.Find("Labels/LabelTradeAmountSell");
        var labelTotalAmountSell = panel.Panel.transform.Find("Labels/LabelTotalAmountSell");

        labelTradeAmountBuy.GetComponent<Text>().text = _tradeScript.ItemsToBuy.Single(x => x.Item.ItemType == panel.ItemType).TradeAmount.ToString();
        labelTotalAmountBuy.GetComponent<Text>().text = _tradeScript.ItemsToBuy.Single(x => x.Item.ItemType == panel.ItemType).Item.Amount.ToString();
        labelTradeAmountSell.GetComponent<Text>().text = _tradeScript.ItemsToSell.Single(x => x.Item.ItemType == panel.ItemType).TradeAmount.ToString();
        labelTotalAmountSell.GetComponent<Text>().text = _tradeScript.ItemsToSell.Single(x => x.Item.ItemType == panel.ItemType).Item.Amount.ToString();
    }
}
