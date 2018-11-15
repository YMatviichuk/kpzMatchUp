using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBin
{
    public class Player
    {
        private static Player instance = null;
        private static readonly object padlock = new object();
        
        Player()
        {
            Console.WriteLine("Player thread safe");

        }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
                
            }
        }
    }


}
