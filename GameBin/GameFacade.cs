using System;

namespace GameBin
{
    public class GameFacade
    {
        public Board CreateGame(string gametype, int _col, int _row)
        {
            if (_col * _row % 2 == 1)
            {
                throw new ArgumentException("Can not create board with odd number of cells");
            }

            GameFactory factory;
            if (gametype == "Simple")
                factory = new SimpleGameFactory();
            else
                throw new ArgumentException("Cannot specify gametype");

            Board board = factory.CreateBoard();
            Card[,] cards = new Card[_row, _col];

            for (int i = 0; i < _row; ++i)
            {
                for (int j = 0; j < _col; ++j)
                {
                    cards[i, j] = factory.CreateCard();
                }
            }
            board.InitBoard(cards, _col, _row);
            return board;
        }
    }
}