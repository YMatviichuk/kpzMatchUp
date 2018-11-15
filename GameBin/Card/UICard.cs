namespace GameBin
{
    public class UICard
    {
        byte[] backside, frontside;
        CardTypes type;
        public UICard(CardTypes _type)
        {
            type = _type;
            backside = LoadImage("BackSide.png");
            switch (type)
            {
                case CardTypes.One:
                    frontside = LoadImage("One.png");
                    break;
                case CardTypes.Two:
                    frontside = LoadImage("Two.png");
                    break;
                case CardTypes.Three:
                    frontside = LoadImage("Three.png");
                    break;
                case CardTypes.Four:
                    frontside = LoadImage("Four.png");
                    break;
                case CardTypes.Five:
                    frontside = LoadImage("Five.png");
                    break;
                case CardTypes.Six:
                    frontside = LoadImage("Six.png");
                    break;
                case CardTypes.Seven:
                    frontside = LoadImage("Seven.png");
                    break;
                case CardTypes.Eight:
                    frontside = LoadImage("Eight.png");
                    break;
            }
        }
        byte[] LoadImage(string url)
        {
            return new byte[] { 1, 2 };
        }
    }
}