using Assets.Enums;

namespace Assets.Models.Items
{
    public class Item
    {
        public string Name { get; set; }

        public ItemType ItemType { get; set; }

        public int Amount { get; set; }
    }
}
