using System;

namespace minirpg
{
    internal class Enemy : Person
    {
        public Enemy(int level)
        {
            _lvl = level;
            _hp = Game.rnd.Next((_lvl - 1) * 10, (_lvl + 1) * 10);
            _atk = Game.rnd.Next(_lvl * 10, (_lvl + 1) * 10);
        }

        public int GetWinChance(Player player)
        {
            int chance1 = (int)(50 - (_atk - player.Hp) * 2.63);
            int chance2 = (int)(50 - (_hp - player.Atk) * 2.63);

            int chance = (chance1 + chance2) / 2;
            return chance < 90 ? chance + 10 : chance;
        }
    }
}