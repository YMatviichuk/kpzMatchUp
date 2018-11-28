using System;
using System.Runtime.Serialization;

namespace GameBin
{
    public class SimpleCard: Card
    {
        public SimpleCard()
        {
        }

        public SimpleCard(CardTypes _type): base(_type)
        {
        }

        override public Card Copy()
        {
            return (Card)this.MemberwiseClone();
        }

        public static implicit operator SimpleCard(string cardType)
        {
            Enum.TryParse<CardTypes>(cardType, out var type);
            return new SimpleCard(type);
        }

        public static explicit operator SimpleCard(int cardTypeNumber)
        {
            return new SimpleCard((CardTypes)cardTypeNumber);
        }
    }
}