namespace AdventOfCode2019.Utilities
{
    public class IntCodeComputer
    {
        private int[] _memory;
        private int _programCounter;
        private int _noun = 12;
        private int _verb = 2;

        public IntCodeComputer(int[] memory)
        {
            _memory = memory;
        }

        public IntCodeComputer(int[] memory, int noun, int verb)
        {
            _memory = memory;
            _noun = noun;
            _verb = verb;
        }

        public int[] RunProgram()
        {
            Reset1202Program(_memory, _noun, _verb);

            while(true)
            {
                if (_memory[_programCounter] == 99)
                {
                    break;
                }

                Execute(_memory);
            }

            return _memory;
        }

        private void Execute(int[] memory)
        {
            var positionOne = memory[_programCounter + 1];
            var positionTwo = memory[_programCounter + 2];
            var positionThree = memory[_programCounter + 3];

            if (memory[_programCounter] == 1)
            {
                memory[positionThree] = memory[positionOne] + memory[positionTwo];
            }
            else
            {
                memory[positionThree] = memory[positionOne] * memory[positionTwo];
            }

            _programCounter += 4;
        }

        private void Reset1202Program(int[] memory, int noun, int verb)
        {
            _programCounter = 0;

            memory[1] = noun;
            memory[2] = verb;
        }
    }
}
