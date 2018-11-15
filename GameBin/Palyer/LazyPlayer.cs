using System;

namespace GameBin
{
    public sealed class LazyPlayer
    {
        public static LazyPlayer Instance { get { return Nested.instance; } }

        public LazyPlayer()
        {
            Console.WriteLine("Init Lazy Player");
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly LazyPlayer instance = new LazyPlayer();
        }
    }
}