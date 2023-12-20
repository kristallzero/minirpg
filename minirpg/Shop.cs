using System;

namespace minirpg
{
    public class Shop
    {
        public static void Show(Player player)
        {
            bool firstRun = true;
            bool enoughMoney = false;
            while (true)
            {
                Console.Clear();
                Print.ShowStats(player);
                Console.WriteLine("\nДоступные предметы:");
                Print.ShowItems(items);

                if (!firstRun)
                {
                    if (enoughMoney) Console.WriteLine("\nПоздравляем с покупкой!");
                    else Console.WriteLine("\nНедосточно золота для покупки данного предмета!");
                }

                int num;
                while (true)
                {
                    Console.Write("\nВведите номер предмета, который вы хотите купить (q - выход в главное меню): ");
                    string? input = Console.ReadLine();
                    if (input == "q") return;
                    if (int.TryParse(input, out num) && num > 0 && num <= items.Count) break;
                }
                enoughMoney = Buy(player, num - 1);
                firstRun = false;
            }
        }

        private static bool Buy(Player player, int itemIndex)
        {
            Item item = items[itemIndex];
            if (player.Gold < item.Cost) return false;
            player.Gold -= item.Cost;
            player.Inventory.Add(item);
            items.Remove(item);
            return true;
        }

        public static List<Item> items = new()
        {
            new Item()
            {
                Type = ItemType.Weapon,
                Size = ItemSize.M,
                Name = "Серебряный меч",
                Cost = 5,
                Atk = 10
            },
            new Item()
            {
                Type = ItemType.Armor,
                Size = ItemSize.M,
                Name = "Серебряные доспехи",
                Cost = 5,
                Def = 10,
                Dq = 10
            },

            new Item()
            {
                Type = ItemType.Accessory,
                Size = ItemSize.S,
                Name = "Серебряный амулет",
                Cost = 5,
                Hp = 25
            },
            new Item()
            {
                Type = ItemType.Weapon,
                Size = ItemSize.M,
                Name = "Закаленный меч",
                Cost = 15,
                Atk = 25
            },
            new Item()
            {
                Type = ItemType.Armor,
                Size = ItemSize.M,
                Name = "Закаленные доспехи",
                Cost = 15,
                Def = 25,
                Dq = 25
            },
            new Item()
            {
                Type = ItemType.Accessory,
                Size = ItemSize.S,
                Name = "Золотой амулет",
                Cost = 15,
                Hp = 50
            },
            new Item()
            { 
                Type = ItemType.Weapon,
                Size = ItemSize.L,
                Name = "Тяжелый меч",
                Cost = 30,
                Atk = 50
            },
            new Item()
            {
                Type = ItemType.Armor,
                Size = ItemSize.L,
                Name = "Тяжелые доспехи",
                Cost = 30,
                Def = 50,
                Dq = 40
            },
            new Item()
            {
                Type = ItemType.Accessory,
                Size = ItemSize.M,
                Name = "Кандалы",
                Cost = 30,
                Hp = 100
            }
        };
    }
}
