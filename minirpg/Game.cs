using System;

namespace minirpg
{
    class Game
    {
        public static readonly Random rnd = new();
        static void Main()
        {
            Console.WriteLine("Для выхода, введите quit");
            Player player = new();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Данные игрока:");
                Console.WriteLine("Уровень: " + player.Lvl);
                Console.WriteLine("Здоровье: " + player.Hp);
                Console.WriteLine("Атака: " + player.Atk);

                Console.WriteLine("\nВраги (Здоровье/Атака):");
                Enemy[] enemies = new Enemy[5];
                for (int i = 0; i < 5; i++)
                {
                    enemies[i] = new Enemy(player.Lvl);
                    Console.WriteLine($"Враг {i + 1}({enemies[i].Hp}/{enemies[i].Atk}), шанс победы: {enemies[i].GetWinChance(player)}%");
                }


                int data = 0;
                bool exit = false;
                while (true)
                {
                    Console.Write("Введите номер врага, на которого вы хотите напасть: ");
                    string? input = Console.ReadLine();
                    if (input == "quit")
                    {
                        exit = true;
                        break;
                    }
                    if (int.TryParse(input, out data) && data > 0 && data < 6) break;
                }
                if (exit) break;
                bool alive = player.Attack(enemies[data - 1]);
                if (alive)
                {
                    if (player.Hp >= (player.Lvl + 1) * 10 && player.Atk >= (player.Lvl + 1) * 10)
                    {
                        player.LevelUp();
                        Console.WriteLine($"Повышение уровня! Теперь ваш уровень: {player.Lvl}");
                    }
                    else if (player.Hp < (player.Lvl - 1) * 10)
                    {
                        player.LevelDown();
                        Console.WriteLine($"Ваше здоровье слишком низкое! Уровень уменьшен: {player.Lvl}");
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Вы умерли! Начать игру заново(y/n)?");
                    if (Console.ReadLine() == "y") player = new Player();
                    else break;
                }
            }
        }
    }
}
