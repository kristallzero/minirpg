using System;
using System.Threading;

namespace minirpg
{
    public class Fight
    {
        public static List<Enemy> enemies = new();
        public static void Show(Player player)
        {
            Console.Write("\nВраги (");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Здоровье ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Атака ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Защита Кач.защиты");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(")");
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.Write($"Враг {i + 1}: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(enemies[i].Hp);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" {enemies[i].Atk} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{enemies[i].Equip.Armor?.Def ?? 0} {enemies[i].Equip.Armor?.Dq ?? 0}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            int enemy;
            while (true)
            {
                Console.Write("Введите номер врага, на которого хотите напасть (q - выход в главное меню): ");
                string? data = Console.ReadLine();
                if (data == "q") return;
                if (int.TryParse(data, out enemy)) break;
            }

            int playerHp = player.Hp;
            int playerAtk = player.Atk;

            int enemyHp = enemies[enemy - 1].Hp;
            int enemyAtk = enemies[enemy - 1].Atk;
            bool alive = StartFight(player, enemies[enemy - 1]);
            if (alive)
            {
                player.Gold += 2 * player.Lvl;
                if (playerHp < player.Lvl * 100) playerHp = player.Lvl * 100;
                if (playerHp < enemyHp - 20) playerHp = enemyHp;
                else playerHp += 20;
                if (playerHp > (player.Lvl + 1) * 100) playerHp = (player.Lvl + 1) * 100;
                player.Hp = playerHp;

                if (playerAtk < enemyAtk - 5) playerAtk = enemyAtk;
                else playerAtk += 5;
                if (playerAtk > (player.Lvl + 1) * 20) playerAtk = (player.Lvl + 1) * 20;
                player.Atk = playerAtk;

                Console.Write("\nПобеда! Золото: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.Gold} (+{2 * player.Lvl})");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ваши характеристики увеличены: Здоровье: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(player.Hp);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | Атака: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(player.Atk);
                Console.ForegroundColor = ConsoleColor.White;

                if (player.Hp >= (player.Lvl + 1) * 100 && player.Atk >= (player.Lvl + 1) * 20)
                {
                    player.LevelUp();
                    Console.WriteLine($"Повышение уровня! Теперь ваш уровень: {player.Lvl}");
                }
            }
            else
            {
                player.Hp = player.Lvl * 100;
                player.Atk = player.Lvl * 20;
                Console.Write("Вы проиграли! Ваше здоровье и атака уменьшены: Здоровье: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(player.Hp);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | Атака: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(player.Atk);
                Console.ForegroundColor = ConsoleColor.White;
            }
            RecreateEnemies(player.Lvl);
            Console.ReadKey();
        }

        private static bool StartFight(Player player, Enemy enemy)
        {
            Console.Clear();
            Print.ShowStats(player);
            Console.WriteLine();
            Print.ShowStats(enemy);
            for (int i = 0; i < 4; i++) Console.WriteLine();

            while (true)
            {
                Thread.Sleep(500);
                if (Game.rnd.Next(1, 10) != 1)
                {
                    int rawAtk = player.Atk + (player.Equip.Weapon?.Atk ?? 0) + Game.rnd.Next(-5, 5);
                    int atk = (int)(rawAtk - (enemy.Equip.Armor?.Def ?? 0) - ((float)rawAtk / 100 * (enemy.Equip.Armor?.Dq ?? 0)));
                    enemy.Hp -= atk;
                    Console.Write("Вы нанесли противнику ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(atk);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" урона");
                    if (enemy.Hp <= 0)
                    {
                        enemy.Hp = 0;
                        RedrawStats(player, enemy);
                        return true;
                    }
                }
                else Console.WriteLine("Вы промахнулись! Урон не засчитан!");

                RedrawStats(player, enemy);

                Thread.Sleep(500);

                if (Game.rnd.Next(1, 10) != 1)
                {
                    int rawAtk = enemy.Atk + (enemy.Equip.Weapon?.Atk ?? 0) + Game.rnd.Next(-5, 5);
                    int atk = (int)(rawAtk - (player.Equip.Armor?.Def ?? 0) - ((float)rawAtk / 100 * (enemy.Equip.Armor?.Dq ?? 0)));
                    player.Hp -= atk;
                    Console.Write("Вам нанесено ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(atk);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" урона");
                    if (player.Hp <= 0)
                    {
                        player.Hp = 0;
                        RedrawStats(player, enemy);
                        return false;
                    }
                }
                else Console.WriteLine("Враг промахнулся! Вам повезло!");

                RedrawStats(player, enemy);
            }
        }

        private static void RedrawStats(Player player, Enemy enemy)
        {
            var (left, top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 14; i++) Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);

            Print.ShowStats(player);
            Console.WriteLine();
            Print.ShowStats(enemy);
            Console.SetCursorPosition(left, top);
        }

        public static void RecreateEnemies(int lvl)
        {
            enemies.Clear();
            for (int i = 0; i < Game.rnd.Next(3, 5); i++)
                enemies.Add(new Enemy(lvl));
        }
    }
}