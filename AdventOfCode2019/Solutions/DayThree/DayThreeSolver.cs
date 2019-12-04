using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Solutions.DayThree
{
    public class DayThreeSolver : ISolver
    {
        private readonly IEnumerable<string> _input;
        private string[] _wireOne;
        private string[] _wireTwo;
        private Direction _direction = Direction.North;

        public DayThreeSolver()
        {
            var reader = new LineReader();
            _input = reader.ReadLine("Solutions/DayThree/DayThreeInput.txt");
            
            var wires = _input.ToArray();

            _wireOne = wires[0].Split(',');
            _wireTwo = wires[1].Split(',');
        }

        public void Solve()
        {
            SolvePartOne();
        }

        public void SolvePartOne()
        {
            var setOne = new HashSet<Coord>();
            var setTwo = new HashSet<Coord>();
            var wireCoordOne = new Coord(0, 0);
            var wireCoordTwo = new Coord(0, 0);
            var closestIntersection = int.MaxValue;

            foreach (var wire in _wireOne)
            {
                var direction = wire.Substring(0, 1);
                var distance = int.Parse(wire.Substring(1));

                ChangeDirection(direction[0]);
                wireCoordOne = MoveDistance(distance, wireCoordOne, setOne);
            }

            foreach(var wire in _wireTwo)
            {
                var direction = wire.Substring(0, 1);
                var distance = int.Parse(wire.Substring(1));

                ChangeDirection(direction[0]);
                wireCoordTwo = MoveDistance(distance, wireCoordTwo, setTwo);
            }

            foreach(var coord in setOne)
            {
                if(setTwo.Contains(coord))
                {
                    var result = Math.Abs(coord.X) + Math.Abs(coord.Y);
                    if(result < closestIntersection)
                    {
                        closestIntersection = result;
                    }
                }
            }

            Console.WriteLine($"The solution to Part One Day Three is - {closestIntersection}");
            Console.ReadKey();
        }

        public void SolvePartTwo()
        {
            //var wireOne = new Wire(new Coord(0, 0));
            //var wireTwo = new Wire(new Coord(0, 0));

            //for(var i = 0; i < _wireOne.Length; i++)
            //{

            //}
        }

        private void ChangeDirection(char direction)
        {
            switch (direction)
            {
                case 'U':
                    _direction = Direction.North;
                    break;
                case 'D':
                    _direction = Direction.South;
                    break;
                case 'L':
                    _direction = Direction.West;
                    break;
                case 'R':
                    _direction = Direction.East;
                    break;
            }
        }

        private Coord MoveDistance(int distance, Coord coordinate, HashSet<Coord> set)
        {
            switch(_direction)
            {
                case Direction.North:
                    coordinate = MoveUp(distance, coordinate, set);
                    break;
                case Direction.East:
                    coordinate = MoveRight(distance, coordinate, set);
                    break;
                case Direction.South:
                    coordinate = MoveDown(distance, coordinate, set);
                    break;
                case Direction.West:
                    coordinate = MoveLeft(distance, coordinate, set);
                    break;
            }

            return coordinate;
        }

        private Coord MoveUp(int distance, Coord coordinate, HashSet<Coord> set)
        {
            for(int i = 0; i < distance; i++)
            {
                coordinate.Y += 1;

                if(!set.Contains(coordinate))
                {
                    set.Add(new Coord(coordinate.X, coordinate.Y));
                }
            }

            return coordinate;
        }

        private Coord MoveRight(int distance, Coord coordinate, HashSet<Coord> set)
        {
            for(int i = 0; i < distance; i++)
            {
                coordinate.X += 1;

                if(!set.Contains(coordinate))
                {
                    set.Add(new Coord(coordinate.X, coordinate.Y));
                }
            }

            return coordinate;
        }

        private Coord MoveDown(int distance, Coord coordinate, HashSet<Coord> set)
        {
            for(int i = 0; i < distance; i++)
            {
                coordinate.Y -= 1;

                if(!set.Contains(coordinate))
                {
                    set.Add(new Coord(coordinate.X, coordinate.Y));
                }
            }

            return coordinate;
        }

        private Coord MoveLeft(int distance, Coord coordinate, HashSet<Coord> set)
        {
            for(int i = 0; i < distance; i++)
            {
                coordinate.X -= 1;

                if(!set.Contains(coordinate))
                {
                    set.Add(new Coord(coordinate.X, coordinate.Y));
                }
            }

            return coordinate;
        }
    }
}
