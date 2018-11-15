namespace GameBin
{
    public class SimpleGameFactory : GameFactory
    {
        public override Board CreateBoard()
        {
            return new SimpleBoard();
        }

        public override Card CreateCard()
        {
            return new SimpleCard();
        }
    }
}