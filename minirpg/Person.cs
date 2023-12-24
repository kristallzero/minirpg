using System;

namespace minirpg

{
    public enum Races
    {
        Knight,
        Elf,
        Gnome,
        Human
    }

    public class Person
    {
        protected int _lvl;
        public int Hp;
        public int Atk;

        protected Races _race;
        public Races Race => _race;
        public int Lvl => _lvl;

        public Equipment Equip = new();

        public static string GetRace(Races race)
        {
            return race switch
            {
                Races.Knight => "Рыцарь",
                Races.Elf => "Эльф",
                Races.Gnome => "Гном",
                Races.Human => "Человек",
                _ => "",
            };
        }

        public static Races? GetRace(string race)
        {
            return race switch
            {
                "Рыцарь" => Races.Knight,
                "Эльф" => Races.Elf,
                "Гном" => Races.Gnome,
                "Человек" => Races.Human,
                _ => null,
            };
        }
    }
}
