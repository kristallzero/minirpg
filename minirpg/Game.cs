using System;

namespace minirpg
{
    class Game
    {
        public static readonly Random rnd = new();
        static void Main()
        {
            Console.WriteLine("Создание персонажа. q - выход");
            Console.Write("Введите имя вашего персонажа: ");
            string? name = Console.ReadLine();
            if (name == "q") return;
            Console.WriteLine("\nВыберите расу. Описание рас:");
            Console.WriteLine("1) Рыцарь - броня стоит дешевле, бесплатная броня в начале игры, здоровье немного ниже стандартной");
            Console.WriteLine("2) Эльф - здоровье выше, чем у других рас, аксессуары лучше увеличивают здоровье, увеличен шанс критического удара, нельзя надевать и покупать броню");
            Console.WriteLine("3) Гном - большая атака, оружие лучше увеличивает атаку");
            Console.WriteLine("4) Человек - скидка на все предметы в магазине");
            bool quit = false;
            int result;
            while (true)
            {
                Console.Write("Введите номер расы: ");
                string? data = Console.ReadLine();
                if (data == "q")
                {
                    quit = true;
                    return;
                }
                if (int.TryParse(data, out result) && result > 0 && result < 5) break;
            }
            if (quit) return;
            Races race;
            switch (result)
            {
                case 1:
                    race = Races.Knight;
                    break;
                case 2:
                    race = Races.Elf;
                    break;
                case 3:
                    race = Races.Gnome;
                    break;
                case 4:
                    race = Races.Human;
                    break;
                default:
                    race = Races.Human;
                    break;
            }
            Player player = new(name, race);
            Fight.RecreateEnemies(player.Lvl);
            while (true)
            {
                Console.Clear();

                quit = false;
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