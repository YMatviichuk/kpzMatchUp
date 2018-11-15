using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Board
    {
        private Card[,] cards;
        private int col;
        private int row;
        private Card FirstUpCard;

        public Board(int _row, int _col)
        {
            if(_col * _row % 2 == 1)
            {
                throw new ArgumentException("Can not create board with odd number of cells");
            }
            col = _col;
            row = _row;

            cards = new Card[row, col];

            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    cards[i, j] = new Card();
                }
            }

            initBoard();
        }

        private void initBoard ()
        {
            Array values = Enum.GetValues(typeof(CardTypes));
            Random randomValue = new Random();
            Random randomCell = new Random();
            List<int> boardCells = Enumerable.Range(0, col * row).ToList();
            for (int i = 0; i < (col * row) / 2; ++i)
            {
                var type = (CardTypes)values.GetValue(randomValue.Next(values.Length));

                var randValue = boardCells[randomCell.Next(0, boardCells.Count)];
                cards[randValue / col, randValue % col].type = type;
                boardCells.Remove(randValue);

                randValue = boardCells[randomCell.Next(0, boardCells.Count)];
                cards[randValue / col, randValue % col].type = type;
                boardCells.Remove(randValue);

            }
        }

        public void print()
        {
            for(int i = 0; i < row; ++i)
            {
                for(int j = 0; j < col; ++j)
                {
                    if(cards[i, j].isUp)
                    {
                        Console.Write(Enum.GetName(typeof(CardTypes), cards[i, j].type) + "\t");
                    }
                    else
                    {
                        Console.Write("Down\t");
                    }
                }
                Console.Write("\n");
            }
        }

        public void cardUp(int indRow, int indCol)
        {
            if(FirstUpCard is null)
            {
                FirstUpCard = cards[indRow, indCol];
                FirstUpCard.isUp = true;
            }
            else if(FirstUpCard == cards[indRow, indCol])
            {
                FirstUpCard.isUp = false;
                FirstUpCard = null;
            }
            else
            {
                Card SecondUpCard = cards[indRow, indCol];
                SecondUpCard.isUp = true;

                Console.Clear();
                print();
                System.Threading.Thread.Sleep(3000);
                
                if (SecondUpCard.type != FirstUpCard.type)
                {
                    SecondUpCard.isUp = false;
                    FirstUpCard.isUp = false;

                }
                FirstUpCard = null;
            }
        }
    }

    public enum CardTypes
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight
    }

    class Card
    {
        public CardTypes type;
        public bool isUp = false;
    }

}
