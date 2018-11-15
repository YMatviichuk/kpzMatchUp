using System;

namespace GameBin
{
    [Flags]
    public enum CardTypes
    {
        One = 1,
        Two = 2,
        Three = 4,
        Four = 8,
        Five = 16,
        Six = 32,
        Seven = 64,
        Eight = 128
    }
}