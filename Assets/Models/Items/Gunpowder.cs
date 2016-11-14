using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Enums;

namespace Assets.Models.Items
{
    public class Gunpowder : Item
    {
        public Gunpowder()
        {
            Name = ItemType.Gunpowder.ToString();
            ItemType = ItemType.Gunpowder;
        }
    }
}
