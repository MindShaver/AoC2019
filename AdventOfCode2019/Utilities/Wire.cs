namespace AdventOfCode2019.Utilities
{
    public struct Wire
    {
        Coord Coordinates;
        int Steps;

        public Wire(Coord coord)
        {
            Coordinates = coord;
            Steps = 0;
        }

        public void ResetSteps()
        {
            Steps = 0;
        }

        public int GetSteps()
        {
            return Steps;
        }

        public void Step()
        {
            Steps++;
        }

        public void SetCoord(Coord coord)
        {
            Coordinates = coord;
        }
    }
}
