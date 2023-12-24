using System;

namespace minirpg
{
    public class Print
    {
        public static void ShowItems(List<Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Предметов нет :(");
            }
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                switch (item.Type)
                {
                    case ItemType.Weapon:
                        Console.Write($"{i + 1}) Тип: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Оружие");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" | Название: {item.Name} | Цена: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{item.Cost}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | Атака: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"+{item.Atk}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ItemType.Armor:
                        Console.Write($"{i + 1}) Тип: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Броня");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" | Название: {item.Name} | Цена: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{item.Cost}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | Защита: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"+{item.Def}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | Качество защиты: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"+{item.Dq}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case ItemType.Accessory:
                        Console.Write($"{i + 1}) Тип: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Аксессуар");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" | Название: {item.Name} | Цена: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{item.Cost}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | Здоровье: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"+{item.Hp}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        public static void ShowItems(Equipment equip)
        {
            if (equip.Weapon != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Оружие");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": {equip.Weapon?.Name} | Цена: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{equip.Weapon?.Cost}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | Атака: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"+{equip.Weapon?.Atk}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Оружие");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": отсутствует");
            }

            if (equip.Armor != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Броня");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": {equip.Armor?.Name} | Цена: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{equip.Armor?.Cost}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | Защита: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"+{equip.Armor?.Def}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | Качество защиты: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"+{equip.Armor?.Dq}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Броня");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": отсутствует");
            }

            if (equip.Accessory != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Аксессуар");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($": {equip.Accessory?.Name} | Цена: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{equip.Accessory?.Cost}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | Здоровье: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"+{equip.Accessory?.Hp}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Аксессуар");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": отсутствует");
            }
        }

        public static void ShowStats(Player player)
        {
            ShowStats(player, false);
        }

        public static void ShowStats(Player player, bool details)
        {
            Console.WriteLine("Данные игрока:");
            Console.WriteLine($"Имя: {player.Name}");
            Console.WriteLine($"Уровень: {player.Lvl}");
            Console.Write("Золото: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(player.Gold);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Раса: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Person.GetRace(player.Race));
            Console.ForegroundColor = ConsoleColor.White;
            if (details)
            {
                Console.Write("Здоровье: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(player.Hp + player.HpRaceBonus);
                if (player.Equip.Accessory != null)
                    Console.Write($"(+{player.Equip.Accessory?.Hp})");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"/{(player.Lvl + 1) * 100 + (player.Equip.Accessory?.Hp ?? 0) + player.HpRaceBonus}");

                Console.Write("Атака: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player.Atk + player.AtkRaceBonus);
                if (player.Equip.Weapon != null)
                    Console.Write($"(+{player.Equip.Weapon?.Atk})");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"/{(player.Lvl + 1) * 20 + (player.Equip.Weapon?.Atk ?? 0) + player.AtkRaceBonus}");
            }
            else
            {
                Console.Write("Здоровье: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(player.Hp + (player.Equip.Accessory?.Hp ?? 0) + player.HpRaceBonus);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"/{(player.Lvl + 1) * 100 + (player.Equip.Accessory?.Hp ?? 0) + player.HpRaceBonus}");

                Console.Write("Атака: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player.Atk + (player.Equip.Weapon?.Atk ?? 0) + player.AtkRaceBonus);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"/{(player.Lvl + 1) * 20 + (player.Equip.Weapon?.Atk ?? 0) + player.AtkRaceBonus}");
            }

            if (player.Equip.Armor != null)
            {
                Console.Write("Защита: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(player.Equip.Armor?.Def);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Качество защиты: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{player.Equip.Armor?.Dq}%");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void ShowStats(Enemy enemy)
        {
            Console.WriteLine("Данные врага:");
            Console.WriteLine($"Уровень: {enemy.Lvl}");

            Console.Write("Раса: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Person.GetRace(enemy.Race));
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Здоровье: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(enemy.Hp + (enemy.Equip.Accessory?.Hp ?? 0));
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Атака: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(enemy.Atk + (enemy.Equip.Weapon?.Atk ?? 0));
            Console.ForegroundColor = ConsoleColor.White;

            if (enemy.Equip.Armor != null)
            {
                Console.Write("Защита: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(enemy.Equip.Armor?.Def);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Качество защиты: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{enemy.Equip.Armor?.Dq}%");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
