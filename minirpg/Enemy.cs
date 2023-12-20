using System;

namespace minirpg
{
    public class Enemy : Person
    {
        public Enemy(int level)
        {
            _lvl = level;
            Hp = Atk = 0;
            while (Hp == 0 || Atk == 0)
            {
                Hp = Game.rnd.Next((_lvl - 1) * 100, (_lvl + 1) * 100);
                Atk = Game.rnd.Next(_lvl * 10, (_lvl + 1) * 20);
            }
            int random = Game.rnd.Next(1, 100);
            if (random >= 50)
            {
                if (random <= 80) Equip.Armor = new Item() { Def = 10, Dq = 10 };
                else if (random <= 95) Equip.Armor = new Item() { Def = 25, Dq = 25 };
                else Equip.Armor = new Item() {  Def = 50, Dq = 45 };
            }
        }

        public byte GetWinChance(Player player)
        {
            byte chance1 = (byte)(50 - (Atk - player.Hp) * 2.63);
            byte chance2 = (byte)(50 - (Hp - player.Atk) * 2.63);

            byte chance = (byte)((chance1 + chance2) / 2);
            return (byte)(chance < 90 ? chance + 10 : chance);
        }
    }
}