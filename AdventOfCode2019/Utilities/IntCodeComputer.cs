using System;

namespace AdventOfCode2019.Utilities
{
    public class IntCodeComputer
    {
        private int[] _memory;
        private int _programCounter;
        private int _noun = 12;
        private int _verb = 2;
        private int[] _modes = new int[] { 0, 0, 0 };
        private int _input = 0;
        private bool _shouldReset = false;

        public IntCodeComputer(int[] memory)
        {
            _memory = memory;
        }

        public IntCodeComputer(int[] memory, int input)
        {
            _memory = memory;
            _input = input;
        }

        public IntCodeComputer(int[] memory, int noun, int verb, bool shouldReset)
        {
            _memory = memory;
            _noun = noun;
            _verb = verb;
            _shouldReset = shouldReset;
        }

        public int[] RunProgram()
        {
            if(_shouldReset)
                Reset1202Program(_memory, _noun, _verb);

            while(true)
            {
                ResetModes();

                var opCode = _memory[_programCounter] % 100;
                var modeOne = Math.Floor((decimal)(_memory[_programCounter] % 1000 / 100));
                var modeTwo = Math.Floor((decimal)(_memory[_programCounter] % 10000 / 1000));
                var modeThree = Math.Floor((decimal)(_memory[_programCounter] % 100000 / 10000));

                _modes[0] = (int)modeThree;
                _modes[1] = (int)modeTwo;
                _modes[2] = (int)modeOne;

                if (opCode == 99)
                {
                    break;
                }

                Execute(_memory, opCode);
            }

            return _memory;
        }

        private void ResetModes()
        {
            for(var i = 0; i < 3; i++)
            {
                _modes[i] = 0;
            }
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

                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        var paramTwo = _modes[1] == 1 ? positionTwo : memory[positionTwo];

                        memory[positionThree] = paramOne + paramTwo;

                        _programCounter += 4;
                    }
                    break;
                case 2:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var positionThree = memory[_programCounter + 3];

                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        var paramTwo = _modes[1] == 1 ? positionTwo : memory[positionTwo];

                        memory[positionThree] = paramOne * paramTwo;

                        _programCounter += 4;
                    }
                    break;
                case 3:
                    {
                        var positionOne = memory[_programCounter + 1];

                        memory[positionOne] = _input;
                        _programCounter += 2;
                    }
                    break;
                case 4:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        Console.WriteLine(paramOne);
                        _programCounter += 2;
                    }
                    break;
                case 5:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        var paramTwo = _modes[1] == 1 ? positionTwo : memory[positionTwo];

                        if(paramOne != 0)
                        {
                            _programCounter = paramTwo;
                        } else
                        {
                            _programCounter += 3;
                        }
                        break;
                    }
                case 6:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        var paramTwo = _modes[1] == 1 ? positionTwo : memory[positionTwo];

                        if (paramOne == 0)
                        {
                            _programCounter = paramTwo;
                        }
                        else
                        {
                            _programCounter += 3;
                        }
                        break;
                    }
                case 7:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var positionThree = memory[_programCounter + 3];
                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        var paramTwo = _modes[1] == 1 ? positionTwo : memory[positionTwo];
                        var paramThree = _modes[0] == 1 ? positionThree : memory[positionThree];

                        if (paramOne < paramTwo)
                        {
                            memory[paramThree] = 1;
                            _programCounter += 4;
                        } else
                        {
                            memory[paramThree] = 0;
                            _programCounter += 4;
                        }
                        break;
                    }
                case 8:
                    {
                        var positionOne = memory[_programCounter + 1];
                        var positionTwo = memory[_programCounter + 2];
                        var positionThree = memory[_programCounter + 3];
                        var paramOne = _modes[2] == 1 ? positionOne : memory[positionOne];
                        var paramTwo = _modes[1] == 1 ? positionTwo : memory[positionTwo];
                        var paramThree = _modes[0] == 1 ? positionThree : memory[positionThree];

                        if (paramOne == paramTwo)
                        {
                            memory[paramThree] = 1;
                            _programCounter += 4;
                        }
                        else
                        {
                            memory[paramThree] = 0;
                            _programCounter += 4;
                        }
                        break;
                    }
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
