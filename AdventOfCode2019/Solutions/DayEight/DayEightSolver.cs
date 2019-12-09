using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Solutions.DayEight
{
    public class DayEightSolver : ISolver
    {
        private IEnumerable<string> _input;
        private List<int[,]> _layers = new List<int[,]>();
        private int _width;
        private int _height;

        public DayEightSolver(int width, int height)
        {
            var reader = new LineReader();
            _input = reader.ReadLine("Solutions/DayEight/DayEightInput.txt");

            _width = width;
            _height = height;
        }

        public void Solve()
        {
            SolvePartOne();
        }

        public void SolvePartOne()
        {
            var layerInput = _input.ToArray()[0];
            var layer = new int[_height, _width];
            var counter = 0;

            while(counter < layerInput.Length - 1)
            {
                for (var i = 0; i < _height; i++)
                {
                    for (var j = 0; j < _width; j++)
                    {
                        var value = layerInput[counter].ToString();
                        layer[i, j] = int.Parse(value);
                        counter++;
                    }
                }

                _layers.Add(layer);
            }

            Console.WriteLine("x");
        }

        public void SolvePartTwo()
        {
            throw new NotImplementedException();
        }
    }
}
