using System;
namespace minirpg
{
    public abstract class Enemy : Person
    {

        public Enemy(int level, Races race, int extraHp, int extraAtk, int[] ArmorChance)
        {
            _lvl = level;
            _race = race;
            Hp = Atk = 0;
            while (Hp <= 0 || Atk <= 0)
            {
                Hp = Game.rnd.Next((_lvl - 1) * 100, (_lvl + 1) * 100) + _lvl * extraHp;
                Atk = Game.rnd.Next(_lvl * 20, (_lvl + 1) * 20) + _lvl * extraAtk;
            }
            int random = Game.rnd.Next(1, 100);
            if (random > ArmorChance[0])
            {
                if (random <= ArmorChance[1]) Equip.Armor = new Item() { Def = 10, Dq = 10 };
                else if (random <= ArmorChance[2] + ArmorChance[0]) Equip.Armor = new Item() { Def = 25, Dq = 25 };
                else Equip.Armor = new Item() { Def = 40, Dq = 35 };
            }
        }
    }

    public class Knight : Enemy
    {
        public Knight(int level) : base(level, Races.Knight, -15, 10, new int[3] { 0, 40, 45}) { }
    }

    public class Elf : Enemy
    {
        public Elf(int level) : base(level, Races.Elf, 40, -5, new int[3] { 100, 0, 0 }) { }
    }

    public class Gnome : Enemy
    {
        public Gnome(int level) : base(level, Races.Gnome, 0, 20, new int[3] { 30, 30, 30 }) { }
    }

    public class Human : Enemy
    {
        public Human(int level) : base(level, Races.Human, 0, 0, new int[3] { 50, 20, 20 }) { }
    }
}