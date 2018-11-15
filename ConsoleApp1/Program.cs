using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameBin;

namespace ConsoleApp1
{
    class OverridedObject : Object
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "It`s my object";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lab4();
        }

        static void Lab4()
        {
            GameFacade facade = new GameFacade();
            var board = facade.CreateGame("Simple", 3, 4);

            CardTypes card = CardTypes.Eight | CardTypes.Four;
            Console.WriteLine(card.ToString());


            //Boxing:
            int forBoxing = 5;
            object boxed = forBoxing;
            
            //Unboxing
            int forUnboxing = (int)forBoxing;

            OverridedObject obj = new OverridedObject();
            Console.WriteLine(obj.ToString());

            Console.ReadLine();
        }



        static void Lab3()
        {
            ProxyRecordsTable recordsTable = new ProxyRecordsTable();

            Console.WriteLine("_________________________________________");
            Console.WriteLine("Records with Date later than 2018-06-15 ordered by score");

            var topRecords = recordsTable.Records.Where(x => x.Date > new DateTime(2018, 5, 13)).ToList();
            topRecords.Sort(new RecordsComparer());

            topRecords.PrintTable();

            Console.WriteLine("_________________________________________");
            Console.WriteLine("Distinct Users");
            var usersIds = topRecords.Select(x => new { UserId = x.UserId, UserName = x.UserName }).Distinct().OrderBy(x => x.UserId).ToArray();

            foreach (var x in usersIds)
            {
                Console.WriteLine($"{x?.UserId} {x?.UserName}");
            }
            Console.WriteLine();

            Console.WriteLine("_________________________________________");
            Console.WriteLine("Dictionary Example");
            Dictionary<int, int> petDictionary = new Dictionary<int, int>
            {
                { topRecords[0].Id, topRecords[0].Score },
                { topRecords[1].Id, topRecords[1].Score },
                { topRecords[2].Id, topRecords[2].Score }
            };
            foreach (var name in petDictionary.Keys)
            {
                System.Console.WriteLine($"RecordId: {name}; Score: {petDictionary[name]}");
            }

            Console.WriteLine("_________________________________________");
            Console.WriteLine("Grouped List Example");

            var groupedRecords = recordsTable.Records.GroupBy(x => x.UserName).Select(x => new
            {
                UserName = x.Key,
                MaxScore = x.Max(y => y.Score)
            }).ToList();
            groupedRecords.ForEach(x => Console.WriteLine($"UserName: {x?.UserName}\nMax Score: {x?.MaxScore}\n"));


            Console.WriteLine("_________________________________________");
            Console.WriteLine("Sorted List Example");

            SortedList sortedRecords = new SortedList();

            foreach (var record in recordsTable.Records)
            {
                sortedRecords.Add(record.Score, record.UserName);
            }

            sortedRecords.PrintKeysAndValues();

            Console.ReadKey();
        }
    }
}
