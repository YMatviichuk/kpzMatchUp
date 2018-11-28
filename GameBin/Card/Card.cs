using System;
using System.Runtime.Serialization;

namespace GameBin
{
    [DataContract]
    [KnownType(typeof(SimpleCard))]
    public abstract class Card
    {
        [DataMember]
        public CardTypes type { get; set; }

        [DataMember]
        public bool isUp { get; set; }

        public Card()
        {
            Console.WriteLine("Init Simple Card");
        }
        public Card(CardTypes _type)
        {
            type = _type;
        }
        public abstract Card Copy();
    }
}