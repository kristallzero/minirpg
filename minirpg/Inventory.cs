using System;

namespace minirpg
{
    public class Inventory
    {
        public static void Show(Player player)
        {
            while (true)
            {
                Console.Clear();
                Print.ShowStats(player, true);
                Console.WriteLine("\nИспользуемые предметы:");
                Print.ShowItems(player.Equip);
                Console.WriteLine("\nИнвентарь:");
                Print.ShowItems(player.Inventory);

                int num;
                while (true)
                {
                    Console.Write("\nВведите номер предмета, чтобы экипировать его (q - выход в главное меню): ");
                    string? input = Console.ReadLine();
                    if (input == "q") { Console.Clear(); return; };
                    if (int.TryParse(input, out num) && num > 0 && num <= player.Inventory.Count) break;
                }
                player.UpdateEquip(num - 1);
            }
        }
    }
}
