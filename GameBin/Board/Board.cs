﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameBin
{
    public interface IBoard
    {
        void RestoreState(BoardMemento memento);
        BoardMemento SaveState();
        void InitBoard(Card[,] _cards, int _col, int _row);
        void cardUp(int indRow, int indCol);
        void print(bool printCardsValues);
    }

    public abstract class Board: IBoard
    {
        public Card[,] cards;
        public int col;
        public int row;
        public Card FirstUpCard = null;
        
        public void RestoreState(BoardMemento memento)
        {
            if (this.col != memento.col || this.row != memento.row)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < memento.row; i++)
            {
                for (int j = 0; j < memento.col; j++)
                {
                    this.cards[i, j] = memento.cards[i * memento.col + j];
                }
            }
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

        public void cardUp(int indRow, int indCol)
        {
            if (cards[indRow, indCol].isUp)
            {
                return;;
            }

            if (FirstUpCard is null)
            {
                FirstUpCard = cards[indRow, indCol];
                FirstUpCard.isUp = true;
            }
            else if (FirstUpCard == cards[indRow, indCol])
            {
                FirstUpCard.isUp = false;
                FirstUpCard = null;
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
            }
        }
    }
}