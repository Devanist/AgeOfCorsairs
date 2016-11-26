using Assets.Enums;
using UnityEngine;

namespace Assets.Models.Items
{
    public class TradeItem
    {

        public Item Item { get; set; }

        public int Price { get; set; }

        public int TradeAmount { get; set; }
    }
}