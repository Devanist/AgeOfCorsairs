using System;
using UnityEngine;
using System.Collections;
using Assets.Enums;
using UnityEngine.UI;

public class ShopItemButtons : MonoBehaviour
{
    private TradeScript _tradeScript;

    public GameObject ItemPanelPrefab;
    public GameObject ItemsPanel;

    // Use this for initialization
    void Start()
    {
        _tradeScript = ItemsPanel.GetComponent<TradeScript>();

        GenerateItemsButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateItemsButtons()
    {
        int i = 0;

        foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            GameObject panel = Instantiate(ItemPanelPrefab);

            var imageObject = panel.transform.Find("Image");

            var image = GetItemImageByType(item);

            imageObject.GetComponent<Image>().sprite = image;

            panel.transform.SetParent(ItemsPanel.transform, false);
            panel.transform.localScale = new Vector3(1, 1, 1);
            panel.transform.localPosition = new Vector3(0, 0 - i * 70, 0);

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
}
