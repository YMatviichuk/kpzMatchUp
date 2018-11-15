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
    }
}