using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json.JsonSerializer;

namespace GameBin
{
    public class BoardMemento
    {
        public Card[,] cards { get; private set; }
        public Card firstUpCard { get; private set; }

        public BoardMemento(Card[,] cards, Card firstUpCard = null)
        {
            this.cards = new Card[cards.GetLength(0),cards.GetLength(1)];

            for (int i = 0; i < cards.GetLength(0); ++i)
            {
                for( int j = 0; j < cards.GetLength(1); ++j)
                {
                    this.cards[i,j] = cards[i, j].Copy();
                    if(firstUpCard == cards[i, j])
                    {
                        this.firstUpCard = this.cards[i, j];
                    }
                }
            }
        }
    }

    public class GameHistory
    {
        public Stack<string> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<string>();
        }
        public void AddMemento(BoardMemento memento)
        {
           // History.Push.SerializeObject(memento));
        }
    }
}
