using Assets.Enums;
using UnityEngine;

namespace Assets.Models.Items
{
    public class TradeItem : MonoBehaviour
    {
        public string Name { get; set; }

        public ItemType ItemType { get; set; }

        public float Price { get; set; }

        public int TradeAmount { get; set; }

        public int Amount { get; set; }
    }
}