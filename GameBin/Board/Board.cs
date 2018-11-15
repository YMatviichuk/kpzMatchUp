using System;
using System.Collections.Generic;
using System.Linq;

namespace GameBin
{
    public interface IBoard
    {
        void RestoreState(BoardMemento memento);
        BoardMemento SaveState();
        void InitBoard(Card[,] _cards, int _col, int _row);
        Tuple<bool, CardTypes> cardUp(int indRow, int indCol);
        void print(bool printCardsValues);
    }

    public abstract class Board: IBoard, IDisposable
    {
        private Card[,] cards;
        private int col;
        private int row;
        private Card FirstUpCard = null;
        
        public void RestoreState(BoardMemento memento)
        {
            this.cards = memento.cards;
            this.FirstUpCard = memento.firstUpCard;
        }

        public BoardMemento SaveState()
        {
            return new BoardMemento(cards, FirstUpCard);
        }

        public void InitBoard(Card[,] _cards, int _col, int _row)
        {
            cards = _cards;
            col = _col;
            row = _row;
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

        public void print(bool printCardsValues)
        {
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)   
                {
                    if (cards[i, j].isUp || printCardsValues)
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

        public Tuple<bool, CardTypes> cardUp(int indRow, int indCol)
        {
            if (FirstUpCard is null)
            {
                FirstUpCard = cards[indRow, indCol];
                FirstUpCard.isUp = true;
                return new Tuple<bool, CardTypes>(FirstUpCard.isUp, FirstUpCard.type);
            }
            else if (FirstUpCard == cards[indRow, indCol])
            {
                FirstUpCard.isUp = false;
                FirstUpCard = null;
                return new Tuple<bool, CardTypes>(FirstUpCard.isUp, FirstUpCard.type);
            }
            else
            {
                Card SecondUpCard = cards[indRow, indCol];
                SecondUpCard.isUp = true;

                if (SecondUpCard.type != FirstUpCard.type)
                {
                    SecondUpCard.isUp = false;
                    FirstUpCard.isUp = false;
                }
                FirstUpCard = null;
                return new Tuple<bool, CardTypes>(SecondUpCard.isUp, SecondUpCard.type);
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Board Disposed");
        }
    }
}