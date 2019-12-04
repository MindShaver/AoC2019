using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019.Utilities
{
    public class LineReader
    {
        public IEnumerable<string> ReadLine(string fileName)
        {
            string line;
            using (var reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}