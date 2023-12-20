using System;

namespace minirpg
{
    public class Person
    {
        protected int _lvl;
        public int Hp;
        public int Atk;

        public int Lvl => _lvl;

        public Equipment Equip = new();
        public void LevelUp()
        {
            _lvl++;
        }

        public void LevelDown()
        {
            _lvl--;
        }
    }
}
