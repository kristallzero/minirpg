using System;

namespace minirpg
{

    internal class Player : Person
    {
        public Player()
        {
            _lvl = 1;
            _hp = 10;
            _atk = 10;
        }


        public bool Attack(Enemy enemy)
        {
            int chance = enemy.GetWinChance(this);

            if (chance > Game.rnd.Next(0, 100))
            {
                int prevHp = _hp;
                if (_hp < _lvl * 10) _hp = _lvl * 10;
                else if (_hp < enemy.Hp) _hp = enemy.Hp;
                else _hp += 1;
                
                if (_hp > (_lvl + 1) * 10) _hp = (_lvl + 1) * 10;

                int changeHp = _hp - prevHp;
                string hpChange = (changeHp > 0 ? "+" : "") + changeHp.ToString();

                int prevAtk = _atk;
                if (_atk < enemy.Atk) _atk = enemy.Atk;
                else _atk += 1;
                if (_atk > (_lvl + 1) * 10) _atk = (_lvl + 1) * 10;

                int changeAtk = _atk - prevAtk;
                string atkChange = (changeAtk > 0 ? "+" : "") + changeAtk.ToString();

                Console.WriteLine($"Победа! Здоровье: {_hp}({hpChange}), атака: {_atk}({atkChange})");
                return true;
            }
            else
            {
                int changeHp = enemy.Atk / 3;
                _hp = _hp - changeHp;

                Console.WriteLine($"Вы проиграли! ваше здоровье: {_hp}({-changeHp})");
                return _hp > 0;
            }
        }

    }

}
