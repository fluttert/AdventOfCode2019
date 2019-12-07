using System;
using System.Diagnostics;

namespace AdventOfCode2019.Y2019
{
    public class Day05 : IAoCDay
    {
        public string SolvePart1(string input = null)
        {
            input ??= this.input;
            int[] intcode = Array.ConvertAll(input.Split(','), int.Parse);

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
                    intcode[intcode[index + 1]] = 5;
                    index += 2; continue;
                }

                // Opcode 4, 1 parameter: output
                if (opcode == 4)
                {
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
                    index += 4;continue;
                }

                Debug.WriteLine($"This went terribly wrong at index {index} with opcode {intcode[index]}");
            }

            return "";
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

        public string SolvePart2(string input = null)
        {
            return string.Empty;
        }

        public void Tests()
        {
            Debug.Assert(true);
        }

        public string input = @"3,225,1,225,6,6,1100,1,238,225,104,0,1102,31,68,225,1001,13,87,224,1001,224,-118,224,4,224,102,8,223,223,1001,224,7,224,1,223,224,223,1,174,110,224,1001,224,-46,224,4,224,102,8,223,223,101,2,224,224,1,223,224,223,1101,13,60,224,101,-73,224,224,4,224,102,8,223,223,101,6,224,224,1,224,223,223,1101,87,72,225,101,47,84,224,101,-119,224,224,4,224,1002,223,8,223,1001,224,6,224,1,223,224,223,1101,76,31,225,1102,60,43,225,1102,45,31,225,1102,63,9,225,2,170,122,224,1001,224,-486,224,4,224,102,8,223,223,101,2,224,224,1,223,224,223,1102,29,17,224,101,-493,224,224,4,224,102,8,223,223,101,1,224,224,1,223,224,223,1102,52,54,225,1102,27,15,225,102,26,113,224,1001,224,-1560,224,4,224,102,8,223,223,101,7,224,224,1,223,224,223,1002,117,81,224,101,-3645,224,224,4,224,1002,223,8,223,101,6,224,224,1,223,224,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,8,226,677,224,102,2,223,223,1005,224,329,1001,223,1,223,1108,677,226,224,102,2,223,223,1006,224,344,101,1,223,223,108,677,226,224,102,2,223,223,1006,224,359,101,1,223,223,7,677,226,224,102,2,223,223,1005,224,374,101,1,223,223,1007,226,677,224,102,2,223,223,1005,224,389,101,1,223,223,8,677,677,224,102,2,223,223,1006,224,404,1001,223,1,223,1007,677,677,224,1002,223,2,223,1006,224,419,101,1,223,223,1108,677,677,224,1002,223,2,223,1005,224,434,1001,223,1,223,1107,226,677,224,102,2,223,223,1005,224,449,101,1,223,223,107,226,226,224,102,2,223,223,1006,224,464,101,1,223,223,1108,226,677,224,1002,223,2,223,1005,224,479,1001,223,1,223,7,677,677,224,102,2,223,223,1006,224,494,1001,223,1,223,1107,677,226,224,102,2,223,223,1005,224,509,101,1,223,223,107,677,677,224,1002,223,2,223,1006,224,524,101,1,223,223,1008,677,677,224,1002,223,2,223,1006,224,539,101,1,223,223,7,226,677,224,1002,223,2,223,1005,224,554,101,1,223,223,108,226,226,224,1002,223,2,223,1006,224,569,101,1,223,223,1008,226,677,224,102,2,223,223,1005,224,584,101,1,223,223,8,677,226,224,1002,223,2,223,1005,224,599,101,1,223,223,1007,226,226,224,1002,223,2,223,1005,224,614,101,1,223,223,1107,226,226,224,1002,223,2,223,1006,224,629,101,1,223,223,107,677,226,224,1002,223,2,223,1005,224,644,1001,223,1,223,1008,226,226,224,1002,223,2,223,1006,224,659,101,1,223,223,108,677,677,224,1002,223,2,223,1005,224,674,1001,223,1,223,4,223,99,226";
    }
}