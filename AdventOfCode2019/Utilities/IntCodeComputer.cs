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

                Execute(_memory, _programCounter);
            }

            return _memory;
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
