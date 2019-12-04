using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Solutions.DayOne
{
    public class DayOneSolver : ISolver
    {
        private IEnumerable<string> _input;

        public DayOneSolver()
        {
            var reader = new LineReader();
            _input = reader.ReadLine("Solutions/DayOne/DayOneInput.txt");
        }

        public void Solve()
        {
            SolvePartOne();
            SolvePartTwo();
        }

        public void SolvePartOne()
        {
            var fuelSum = 0;

            foreach(var mass in _input)
            {
                fuelSum += CalculateFuel(int.Parse(mass));
            }

            PrintSolution(true, fuelSum);
        }

        public void SolvePartTwo()
        {
            var fuelSum = 0;

            foreach (var mass in _input)
            {
                fuelSum += RecurseCalculateFuel(int.Parse(mass));
            }

            PrintSolution(false, fuelSum);
        }

        private void PrintSolution(bool isPartOne, int fuelSum)
        {
            var partString = isPartOne ? "One" : "Two";

            Console.WriteLine($"The solution to Part {partString} of Day One is - {fuelSum}");
            Console.ReadKey();
        }

        private int CalculateFuel(int mass)
        {
            return Convert.ToInt32(Math.Floor((decimal)(mass / 3)) - 2);
        }

        private int RecurseCalculateFuel(int mass, int runningCount = 0)
        {
            var result = CalculateFuel(mass);
            if(result <= 0)
                return runningCount;

            runningCount += result;

            return RecurseCalculateFuel(result, runningCount);
        }
    }
}
