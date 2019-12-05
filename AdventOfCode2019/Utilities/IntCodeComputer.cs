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
                var opCode = _memory[_programCounter] % 1000;
                if (opCode == 99)
                {
                    break;
                }

                Execute(_memory, opCode);
            }

            return _memory;
        }

        private void Execute(int[] memory, int opCode)
        {
            switch(opCode)
            {
                case 1:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var positionThree = memory[_programCounter + 3];

                        memory[positionThree] = memory[positionOne] + memory[positionTwo];

                        _programCounter += 4;
                    }
                    break;
                case 2:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var positionThree = memory[_programCounter + 3];

                        memory[positionThree] = memory[positionOne] * memory[positionTwo];

                        _programCounter += 4;
                    }
                    break;
                case 3:
                    {
                        _programCounter += 1;
                    }
                    break;
                case 4:
                    {
                        _programCounter += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Reset1202Program(int[] memory, int noun, int verb)
        {
            _programCounter = 0;

            memory[1] = noun;
            memory[2] = verb;
        }
    }
}
