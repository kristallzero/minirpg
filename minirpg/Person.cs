using System;

namespace minirpg
{
    public struct PersonData
    {
        public int lvl;
        public int hp;
        public int atk;
    }
    internal class Person
    {
        protected int _lvl;
        protected int _hp;
        protected int _atk;

        public int Lvl => _lvl;
        public int Hp => _hp;
        public int Atk => _atk;

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
