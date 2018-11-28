using System;

namespace GameBin
{
    class Card3D : Card
    {
        int bonusPoints;

        public Card3D()
        {

            Console.WriteLine("init simple 3dcard");
        }

        public Card3D(CardTypes _type) : base(_type)
        {
        }

        public Card3D(string _type) : this()
        {
        }

        override public Card Copy()
        {
            return (Card)this.MemberwiseClone();
        }
    }
}