using System;

namespace minirpg
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Accessory
    };

    public enum ItemSize
    {
        S,
        M,
        L
    }

    public struct Item
    {
        public ItemType Type;
        public ItemSize Size;
        public string Name;
        public int Cost;
        public int Atk;
        public int Hp;
        public int Def;
        public byte Dq; // defence quality
    }
}
