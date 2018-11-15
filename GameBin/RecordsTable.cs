using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GameBin
{

    public class Record
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }

    interface IRecordsTable
    {
        List<Record> Records { get; }
    }

    class RecordsTable: IRecordsTable
    {
        public RecordsTable()
        {
        }

        bool isChanges = true;

        public bool CheckChanges()
        {
            if(isChanges)
            {
                isChanges = false;
                return true;
            }
            return isChanges;
        }
        
        public List<Record> Records => new List<Record>
        {
            new Record
            {
                Id = 0,
                UserId = 0,
                UserName = "Alex",
                Date = new DateTime(2018, 5, 12),
                Score = 1000,
            },
            new Record
            {
                Id = 1,
                UserId = 0,
                UserName = "Alex",
                Date = new DateTime(2018, 4, 16),
                Score = 1023,
            },
            new Record
            {
                Id = 2,
                UserId = 3,
                UserName = "Frank",
                Date = new DateTime(2018, 7, 8),
                Score = 1320,
            },
            new Record
            {
                Id = 3,
                UserId = 1,
                UserName = "Elise",
                Date = new DateTime(2018, 5, 12),
                Score = 932,
            },
            new Record
            {
                Id = 4,
                UserId = 1,
                UserName = "Elise",
                Date = new DateTime(2018, 5, 4),
                Score = 1500,
            },new Record
            {
                Id = 5,
                UserId = 2,
                UserName = "Margaret",
                Date = new DateTime(2018, 10, 12),
                Score = 999,
            },
            new Record
            {
                Id = 6,
                UserId = 0,
                UserName = "Alex",
                Date = new DateTime(2018, 6, 1),
                Score = 1102,
            },
            new Record
            {
                Id = 7,
                UserId = 3,
                UserName = "Frank",
                Date = new DateTime(2018, 5, 13),
                Score = 1202,
            }
        };
    }


    public class ProxyRecordsTable: IRecordsTable
    {
        RecordsTable recordsTable = null;
        List<Record> cached;
        Timer timer = new Timer();

        public List<Record> Records
        {
            get
            {
                if (recordsTable is null)
                {
                    recordsTable = new RecordsTable();
                }
                if (recordsTable.CheckChanges())
                {
                    cached = recordsTable.Records;
                }
                return cached;
            }
        }
    }

    public static class Extentions
    {
        public static void PrintTable(this List<Record> records)
        {
            records.ForEach(x => Console.WriteLine($"Id: {x?.Id}\nUserName: {x?.UserName}\nDate: {x?.Date}\nScore: {x?.Score}\n"));
        }
        public static void PrintKeysAndValues(this SortedList myList)
        {
            Console.WriteLine("\t-KEY-\t-VALUE-");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i));
            }
            Console.WriteLine();
        }
    }

    public class RecordsComparer: IComparer<Record> {
        public int Compare(Record x, Record y)
        {
            if (x.Score > y.Score)
            {
                return -1;
            }
            else if (x.Score < y.Score)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


}
