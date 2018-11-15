using System;

namespace GameBin
{
    public class GoldCard : Card
    {
        int bonusPoints;

        public GoldCard()
        {
            Console.WriteLine("init Gold card");
        }

        public GoldCard(CardTypes _type) : base(_type)
        {
        }

        override public Card Copy()
        {
            return (Card)this.MemberwiseClone();
        }
    }
}