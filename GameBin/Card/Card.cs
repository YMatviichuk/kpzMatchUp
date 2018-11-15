using System;

namespace GameBin
{
    public abstract class Card
    {
        public Card()
        {
            Console.WriteLine("Init Simple Card");
        }
        public Card(CardTypes _type)
        {
            type = _type;
        }
        public CardTypes type { get; set; }
        public bool isUp = false;
        public abstract Card Copy();
    }
}