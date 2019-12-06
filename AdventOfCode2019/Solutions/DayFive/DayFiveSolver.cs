using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Solutions.DayFiveSolver
{
    public class DayFiveSolver : ISolver
    {
        private IEnumerable<string> _input;

        public DayFiveSolver()
        {
            var reader = new LineReader();
            _input = reader.ReadLine("Solutions/DayFive/DayFiveInput.txt");
        }

        public void Solve()
        {
            SolvePartOne();
            SolvePartTwo();
        }

        public void SolvePartOne()
        {
            var splitInput = _input.ToArray()[0].Split(',');
            var memory = splitInput.Select(x => int.Parse(x)).ToArray();

            var computer = new IntCodeComputer(memory, 1);
            var result = computer.RunProgram();

            Console.WriteLine($"The solution to Part One Day Five is above ^^^");
        }

        public void SolvePartTwo()
        {
            var splitInput = _input.ToArray()[0].Split(',');
            var memory = splitInput.Select(x => int.Parse(x)).ToArray();

            var computer = new IntCodeComputer(memory, 5);
            var result = computer.RunProgram();

            Console.WriteLine($"The solution to Part One Day Five is above ^^^");
        }
    }
}
