using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Models.Items;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Models
{
    public class Warehouse : MonoBehaviour
    {
        public int GunpowderAmount = 100;

        public IList<Item> Items { get; set; }
        public Gunpowder Gunpowder { get; set; }

        public Warehouse()
        {
            Items = new List<Item>();
            Gunpowder = new Gunpowder {Amount = GunpowderAmount};
            Items.Add(Gunpowder);
        }
    }
}
