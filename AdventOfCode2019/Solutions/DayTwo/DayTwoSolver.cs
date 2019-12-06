using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Solutions.DayTwo
{
    public class DayTwoSolver : ISolver
    {
        private IEnumerable<string> _input;

        public DayTwoSolver()
        {
            var reader = new LineReader();
            _input = reader.ReadLine("Solutions/DayTwo/DayTwoInput.txt");
        }

        public void Solve()
        {
            SolvePartOne();
            SolvePartTwo();
        }

        public void SolvePartOne()
        {
            var opCodes = _input.ToArray()[0].Split(',');
            var intOpCodes = opCodes.Select(x => int.Parse(x)).ToArray();

            var computer = new IntCodeComputer(intOpCodes, 12, 2, true);
            var result = computer.RunProgram();

            Console.WriteLine($"The solution to Part One Day Two is - {result[0]}");
        }

        public void SolvePartTwo()
        {
            int finalNoun = 0;
            int finalVerb = 0;

            var opCodes = _input.ToArray()[0].Split(',');
            var intOpCodes = opCodes.Select(x => int.Parse(x)).ToArray();

            var memory = new int[intOpCodes.Length];

            for(var i = 1; i < 99; i++)
            {
                for(var j = 1; j < 99; j++)
                {
                    ResetMemory(intOpCodes, memory);

                    var computer = new IntCodeComputer(memory, i, j, true);
                    var result = computer.RunProgram();

                    if(result[0] == 19690720)
                    {
                        finalNoun = i;
                        finalVerb = j;

                        break;
                    }
                }
            }

            Console.WriteLine($"The solution to Part Two Day Two - What is {100 * finalNoun + finalVerb}?");
        }

        private void ResetMemory(int[] instructions, int[] memory)
        {
            for(var i = 0; i < instructions.Length; i++)
            {
                memory[i] = instructions[i];
            }
        }
    }
}
