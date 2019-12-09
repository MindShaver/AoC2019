using AdventOfCode2019.Solutions.DayEight;
using AdventOfCode2019.Solutions.DayFiveSolver;
using AdventOfCode2019.Solutions.DayFour;
using AdventOfCode2019.Solutions.DayOne;
using AdventOfCode2019.Solutions.DaySix;
using AdventOfCode2019.Solutions.DayThree;
using AdventOfCode2019.Solutions.DayTwo;
using System;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new DayEightSolver(3, 2);

            solver.Solve();
        }
    }
}
