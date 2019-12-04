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

            Reset1202Program(intOpCodes);

            for (var i = 0; i < intOpCodes.Length; i += 4)
            {
                if(intOpCodes[i] == 99)
                {
                    break;
                }

                Execute(intOpCodes, i);
            }

            Console.WriteLine($"The solution to Part One Day Two is - {intOpCodes[0]}");
            Console.ReadKey();
        }

        public void SolvePartTwo()
        {
            int noun = 0;
            int verb = 0;

            var opCodes = _input.ToArray()[0].Split(',');
            var intOpCodes = opCodes.Select(x => int.Parse(x)).ToArray();

            var memory = new int[intOpCodes.Length];

            for(var i = 1; i < 99; i++)
            {
                for(var j = 1; j < 99; j++)
                {
                    ResetMemory(intOpCodes, memory);
                    Reset1202Program(memory, i, j);

                    for (var instructionPointer = 0; instructionPointer < memory.Length; instructionPointer += 4)
                    {
                        if (memory[instructionPointer] == 99)
                        {
                            break;
                        }

                        Execute(memory, instructionPointer);
                    }

                    if(memory[0] == 19690720)
                    {
                        noun = i;
                        verb = j;

                        break;
                    }
                }
            }

            Console.WriteLine($"The solution to Part Two Day Two - What is {100 * noun + verb}?");
            Console.ReadKey();
        }

        private void Execute(int[] memory, int instructionPointer)
        {
            var positionOne = memory[instructionPointer + 1];
            var positionTwo = memory[instructionPointer + 2];
            var positionThree = memory[instructionPointer + 3];

            if (memory[instructionPointer] == 1)
            {
                memory[positionThree] = memory[positionOne] + memory[positionTwo];
            }
            else
            {
                memory[positionThree] = memory[positionOne] * memory[positionTwo];
            }
        }

        private void ResetMemory(int[] instructions, int[] memory)
        {
            for(var i = 0; i < instructions.Length; i++)
            {
                memory[i] = instructions[i];
            }
        }

        private void Reset1202Program(int[] memory, int noun, int verb)
        {
            memory[1] = noun;
            memory[2] = verb;
        }

        private void Reset1202Program(int[] opCodes)
        {
            opCodes[1] = 12;
            opCodes[2] = 2;
        }
    }
}
