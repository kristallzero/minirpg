using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace minirpg
{
    public class Player : Person
    {
        public List<Item> Inventory;

        public int Gold;

        public Player()
        {
            _lvl = 1;
            Hp = 125;
            Atk = 30;
            Inventory = new();
            Gold = 0;
        }

        public void UpdateEquip(int inventoryIndex)
        {
            Item item = Inventory[inventoryIndex];
            Item? previousItem = null;

            switch (item.Type)
            {
                case ItemType.Weapon:
                    previousItem = Equip.Weapon;
                    Equip.Weapon = item;
                    break;
                case ItemType.Armor:
                    previousItem = Equip.Armor;
                    Equip.Armor = item;
                    break;
                case ItemType.Accessory:
                    previousItem = Equip.Accessory;
                    Equip.Accessory = item;
                    break;
            }
            if (previousItem != null)
                Inventory.Add((Item)previousItem);
            Inventory.Remove(item);
        }
    }

}
