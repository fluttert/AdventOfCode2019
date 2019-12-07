using System;
using System.Diagnostics;

namespace AdventOfCode2019.Y2019
{
    public class Intcode
    {
        public int input = 0; // opcode 3
        public int output = 0; // opcode 4
        protected int[] intcode;
        

        public Intcode(string input) {
            intcode = Array.ConvertAll(input.Split(',', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        public void Run() {
            int index = 0;
            while (intcode[index] != 99)
            {
                // determine opcode and mode
                int opcode = intcode[index];
                bool modeParam1Immediate = false, modeParam2Immediate = false;
                if (opcode >= 100)
                {
                    int tmp = opcode;
                    opcode = tmp % 10;
                    modeParam1Immediate = ((tmp / 100) % 10) == 1;
                    modeParam2Immediate = ((tmp / 1000) % 10) == 1;
                }

                // Opcode 1, 3 parameters: Addition
                if (opcode == 1)
                {
                    intcode = Add(index, intcode, modeParam1Immediate, modeParam2Immediate);
                    index += 4; continue;
                }

                // Opcode 2, 3 parameters: Multiplication
                if (opcode == 2)
                {
                    intcode = Multiply(index, intcode, modeParam1Immediate, modeParam2Immediate);
                    index += 4; continue;
                }

                // Opcode 3, 1 parameter: input
                if (opcode == 3)
                {
                    intcode[intcode[index + 1]] = input;
                    index += 2; continue;
                }

                // Opcode 4, 1 parameter: output
                if (opcode == 4)
                {
                    output = intcode[intcode[index + 1]];
                    Console.WriteLine($"Opcode4, pos: {intcode[index + 1]} = {intcode[intcode[index + 1]]}");
                    index += 2; continue;
                }

                // opcode 5, 2 parameters: jump-if-true
                if (opcode == 5)
                {
                    index = JumpIfTrue(index, intcode, modeParam1Immediate, modeParam2Immediate);
                    continue;
                }

                // opcode 6, 2 parameters: jump-if-false
                if (opcode == 6)
                {
                    index = JumpIfFalse(index, intcode, modeParam1Immediate, modeParam2Immediate);
                    continue;
                }

                // opcode 7, 3 parameters: Less than
                if (opcode == 7)
                {
                    intcode = LessThan(index, intcode, modeParam1Immediate, modeParam2Immediate);
                    index += 4; continue;
                }

                // opcode 8, 3 paramters: equal to
                if (opcode == 8)
                {
                    intcode = EqualTo(index, intcode, modeParam1Immediate, modeParam2Immediate);
                    index += 4; continue;
                }

                Debug.WriteLine($"This went terribly wrong at index {index} with opcode {intcode[index]}");
                break;
            }
        }

        public int[] Add(int index, int[] intcode, bool param1ModeImmediate = false, bool param2ModeImmediate = false)
        {
            int firstNumber = param1ModeImmediate ? intcode[index + 1] : intcode[intcode[index + 1]];
            int secondNumber = param2ModeImmediate ? intcode[index + 2] : intcode[intcode[index + 2]];
            intcode[intcode[index + 3]] = firstNumber + secondNumber;
            return intcode;
        }

        public int[] Multiply(int index, int[] intcode, bool param1ModeImmediate = false, bool param2ModeImmediate = false)
        {
            int firstNumber = param1ModeImmediate ? intcode[index + 1] : intcode[intcode[index + 1]];
            int secondNumber = param2ModeImmediate ? intcode[index + 2] : intcode[intcode[index + 2]];
            intcode[intcode[index + 3]] = firstNumber * secondNumber;
            return intcode;
        }

        public int JumpIfTrue(int index, int[] intcode, bool param1ModeImmediate = false, bool param2ModeImmediate = false)
        {
            int firstNumber = param1ModeImmediate ? intcode[index + 1] : intcode[intcode[index + 1]];
            int secondNumber = param2ModeImmediate ? intcode[index + 2] : intcode[intcode[index + 2]];
            return firstNumber != 0 ? secondNumber : index + 3;
        }

        public int JumpIfFalse(int index, int[] intcode, bool param1ModeImmediate = false, bool param2ModeImmediate = false)
        {
            int firstNumber = param1ModeImmediate ? intcode[index + 1] : intcode[intcode[index + 1]];
            int secondNumber = param2ModeImmediate ? intcode[index + 2] : intcode[intcode[index + 2]];
            return firstNumber == 0 ? secondNumber : index + 3;
        }

        public int[] LessThan(int index, int[] intcode, bool param1ModeImmediate = false, bool param2ModeImmediate = false)
        {
            int firstNumber = param1ModeImmediate ? intcode[index + 1] : intcode[intcode[index + 1]];
            int secondNumber = param2ModeImmediate ? intcode[index + 2] : intcode[intcode[index + 2]];
            intcode[intcode[index + 3]] = firstNumber < secondNumber ? 1 : 0;
            return intcode;
        }

        public int[] EqualTo(int index, int[] intcode, bool param1ModeImmediate = false, bool param2ModeImmediate = false)
        {
            int firstNumber = param1ModeImmediate ? intcode[index + 1] : intcode[intcode[index + 1]];
            int secondNumber = param2ModeImmediate ? intcode[index + 2] : intcode[intcode[index + 2]];
            intcode[intcode[index + 3]] = firstNumber == secondNumber ? 1 : 0;
            return intcode;
        }
    }
}