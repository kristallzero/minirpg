using System;

namespace minirpg
{
    class Game
    {
        public static readonly Random rnd = new();
        static void Main()
        {
            Player player = new();
            Fight.RecreateEnemies(player.Lvl);

            while (true)
            {
                Console.Clear();

                bool quit = false;
                Print.ShowStats(player);
                Console.Write("\nf - бой, i - открыть инвентарь, s - открыть магазин, q - выход: ");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "f": Fight.Show(player); break;
                    case "i": Inventory.Show(player); break;
                    case "s": Shop.Show(player); break;
                    case "q": quit = true; break;
                }

                if (quit) break;
            }
        }
    }
}