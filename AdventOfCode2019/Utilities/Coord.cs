﻿namespace AdventOfCode2019.Utilities
{
    public struct Coord
    {
        public int X;
        public int Y;

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "" + X + Y;
        }
    }
}
