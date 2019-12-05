using System;

namespace AdventOfCode2019.Solutions.DayFour
{
    public class DayFourSolver : ISolver
    {
        public void Solve()
        {
            SolvePartOne();
            SolvePartTwo();
        }

        public void SolvePartOne()
        {
            var initalPassword = 231832;
            var maxRange = 767346;
            var counter = 0;

            for (var i = initalPassword; i <= maxRange; i++)
            {
                if (IsValid(i))
                {
                    counter++;
                }
            }

            Console.WriteLine($"The solution to Part One Day Four is - {counter}");
        }

        public void SolvePartTwo()
        {
            var initalPassword = 231832;
            var maxRange = 767346;
            var counter = 0;

            for (var i = initalPassword; i <= maxRange; i++)
            {
                if (IsValidExtended(i))
                {
                    counter++;
                }
            }

            Console.WriteLine($"The solution to Part Two Day Four is - {counter}");
        }

        private bool IsValid(int input)
        {
            var isDecreased = true;
            var isAdjacent = false;
            var stringyPassword = input.ToString();

            for (var j = 0; j < stringyPassword.Length - 1; j++)
            {
                if (stringyPassword[j] > stringyPassword[j + 1])
                {
                    isDecreased = false;
                }

                if (stringyPassword[j] == stringyPassword[j + 1])
                {
                    isAdjacent = true;
                }
            }

            return isDecreased && isAdjacent;
        }

        private bool IsValidExtended(int input)
        {
            var isDecreased = true;
            var isOnlyAdjacent = false;
            var stringyPassword = input.ToString();

            for (var j = 0; j < stringyPassword.Length - 1; j++)
            {
                if (stringyPassword[j] > stringyPassword[j + 1])
                {
                    isDecreased = false;
                }

                if(!isOnlyAdjacent && stringyPassword[j] == stringyPassword[j + 1])
                {
                    if(j > 0)
                    {
                        if(stringyPassword[j] == stringyPassword[j -1])
                        {
                            continue;
                        }
                    }

                    if(j < stringyPassword.Length - 2)
                    {
                        if(stringyPassword[j] != stringyPassword[j+2])
                        {
                            isOnlyAdjacent = true;
                        } else
                        {
                            continue;
                        }
                    } else
                    {
                        isOnlyAdjacent = true;
                    }
                }
            }

            return isDecreased && isOnlyAdjacent;
        }
    }
}
