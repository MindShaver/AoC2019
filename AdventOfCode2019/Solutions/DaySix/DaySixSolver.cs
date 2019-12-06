using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Solutions.DaySix
{
    public class DaySixSolver : ISolver
    {

        private IEnumerable<string> _input; 

        public DaySixSolver()
        {
            var reader = new LineReader();
            _input = reader.ReadLine("Solutions/DaySix/DaySixInput.txt");
        }

        public void Solve()
        {
            SolvePartOne();
        }

        public void SolvePartOne()
        {
            var planetDict = new Dictionary<Planet, List<Planet>>();

            foreach(var i in _input)
            {
                var parentChild = i.Split(')');
                var a = new Planet(parentChild[0]);
                var b = new Planet(parentChild[1]);

                if(!planetDict.ContainsKey(a))
                {
                    planetDict.Add(a, new List<Planet> { b });
                } else
                {
                    planetDict[a].Add(b);
                }

                if(!planetDict.ContainsKey(b))
                {
                    planetDict.Add(b, new List<Planet>());
                }

            }

            var x = 1;



        }

        public void SolvePartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public struct Planet {
        public string PlanetName;
        public List<Planet> Children;

        public Planet(string name)
        {
            PlanetName = name;
            Children = new List<Planet>();
        }

        public int GetIndirect()
        {
            var count = 0;
            foreach(var c in Children)
            {
                foreach(var cc in c.Children)
                {
                    count++;
                }
            }

            return count; 
        }
    }

}
