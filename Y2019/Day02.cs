using System;
using System.Diagnostics;

namespace AdventOfCode2019.Y2019
{
    internal class Day02 : IAoCDay
    {
        public string SolvePart1(string input = null)
        {
            return this.SolvePart1(-1, -1, input);
        }

        public string SolvePart1(int noun, int verb, string input = null)
        {
            input ??= this.input;
            int[] intcode = Array.ConvertAll(input.Split(','), int.Parse);

            if (noun > 0 && verb > 0) { intcode[1] = noun; intcode[2] = verb; }

            for (int i = 0; i < intcode.Length; i += 4)
            {
                if (intcode[i] == 99) { break; }
                if (intcode[i] == 1) { intcode[intcode[i + 3]] = intcode[intcode[i + 1]] + intcode[intcode[i + 2]]; continue; }
                if (intcode[i] == 2) { intcode[intcode[i + 3]] = intcode[intcode[i + 1]] * intcode[intcode[i + 2]]; continue; }
                Debug.WriteLine($"This went terribly wrong at index {i} with opcode {intcode[i]}");
            }
            //Debug.WriteLine($"Answer == {intcode[0]}");
            return "" + intcode[0];
        }

        public string SolvePart2(string input = null)
        {
            input ??= this.input;
            string desiredOutput = "19690720";
            bool found = false;
            int noun = -1, verb = -1;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (desiredOutput == SolvePart1(i, j, this.input))
                    {
                        found = true;
                        noun = i;
                        verb = j;
                    }
                }
                if (found) { break; }
            }
            Debug.WriteLine($"Verb = {verb}, Noun = {noun}");
            return "" + (100 * noun + verb);
        }

        public void Tests()
        {
            Debug.Assert(SolvePart1("1,0,0,0,99") == "2");
            Debug.Assert(SolvePart1("2,3,0,3,99") == "2");
            Debug.Assert(SolvePart1("2,4,4,5,99,0") == "2");
            Debug.Assert(SolvePart1("1,1,1,4,99,5,6,0,99") == "30");
            Debug.Assert(SolvePart1("1,9,10,3,2,3,11,0,99,30,40,50") == "3500");
        }

        protected string input = @"1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,2,19,6,23,2,13,23,27,1,9,27,31,2,31,9,35,1,6,35,39,2,10,39,43,1,5,43,47,1,5,47,51,2,51,6,55,2,10,55,59,1,59,9,63,2,13,63,67,1,10,67,71,1,71,5,75,1,75,6,79,1,10,79,83,1,5,83,87,1,5,87,91,2,91,6,95,2,6,95,99,2,10,99,103,1,103,5,107,1,2,107,111,1,6,111,0,99,2,14,0,0";
    }
}