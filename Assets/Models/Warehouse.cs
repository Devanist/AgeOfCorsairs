using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Enums;
using Assets.Models.Items;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Models
{
    public class Warehouse : MonoBehaviour
    {
        public IList<Item> Items { get; set; }

        public Warehouse()
        {
            Items = new List<Item>();
            foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
            {
                Items.Add(new Item
                {
                    Amount = 100,
                    ItemType = itemType,
                    Name = itemType.ToString()
                });
            }
        }
    }
}
