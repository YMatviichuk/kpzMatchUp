using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameBin
{
    [DataContract]
    public class BoardMemento
    {
        [DataMember]
        public Card[] cards { get; set; }
        [DataMember]
        public Card firstUpCard { get; set; }
        [DataMember]
        public int col { get; set; }
        [DataMember]
        public int row { get; set; }


        public BoardMemento(Card[,] cards, Card firstUpCard = null)
        {
            this.col = cards.GetLength(0);
            this.row = cards.GetLength(1);
            this.cards = cards.Cast<Card>().ToArray();
            this.firstUpCard = firstUpCard;
        }

        public string SaveToDisk()
        {
            Stream s = new MemoryStream();;
            var formatter = new DataContractSerializer(typeof(BoardMemento));
            formatter.WriteObject(s, this);
            StreamReader sr = new StreamReader(s);
            return sr.ReadToEnd();
        }

        public static BoardMemento ReadFromDisk(string filename)
        {
            if (File.Exists(filename))
            {
                var f = new FileStream(filename, FileMode.Open);
                var formatter = new DataContractSerializer(typeof(BoardMemento));
                return (BoardMemento)formatter.ReadObject(f);
            } 
            return null;
        }

        public static BoardMemento ReadFromStream(Stream stream)
        {
            var formatter = new DataContractSerializer(typeof(BoardMemento));
            return (BoardMemento)formatter.ReadObject(stream);
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
            //History.Push(formatter.Serialize());
        }
    }
}
