using System;


namespace minirpg
{
    public class Player : Person
    {
        public List<Item> Inventory;

        public int Gold;

        public string Name => _name;
        public int HpRaceBonus => _hpRaceBonus;
        public int AtkRaceBonus => _atkRaceBonus;

        private string _name;
        private int _hpRaceBonus;
        private int _atkRaceBonus;

        public Player(string name, Races race)
        {
            _lvl = 1;
            _name = name;
            _race = race;
            switch (_race)
            {
                case Races.Knight:
                    _hpRaceBonus = -15;
                    _atkRaceBonus = 10;
                    Equip.Armor = Shop.items[1];
                    Shop.items.Remove((Item)Equip.Armor);
                    for (int i = 0; i < Shop.items.Count; i++)
                    {
                        Item item = Shop.items[i];
                        if (item.Type == ItemType.Armor)
                        {
                            item.Cost /= 3;
                            Shop.items[i] = item;
                        }
                    }

                    break;
                case Races.Elf:
                    _hpRaceBonus = 40;
                    _atkRaceBonus = -5;
                    Shop.items.RemoveAll(x => x.Type == ItemType.Armor);
                    for (int i = 0; i < Shop.items.Count; i++)
                    {
                        Item item = Shop.items[i];
                        item.Hp *= 2;
                        Shop.items[i] = item;
                    }
                    break;
                case Races.Gnome:
                    _atkRaceBonus = 20;
                    for (int i = 0; i < Shop.items.Count; i++)
                    {
                        Item item = Shop.items[i];
                        item.Atk *= 2;
                        Shop.items[i] = item;
                    }
                    break;
                case Races.Human:
                    for (int i = 0; i < Shop.items.Count; i++)
                    {
                        Item item = Shop.items[i];
                        item.Cost /= 2;
                        Shop.items[i] = item;
                    }
                    break;
            }
            Hp = 125;
            Atk = 30;
            Inventory = new();
            Gold = 0;
        }

        public void LevelUp()
        {
            _lvl++;
            _atkRaceBonus = _atkRaceBonus / (_lvl - 1) * _lvl;
            _hpRaceBonus = _hpRaceBonus / (_lvl - 1) * _lvl;
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
