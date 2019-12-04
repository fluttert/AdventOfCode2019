using System;
using System.Diagnostics;

namespace AdventOfCode2019.Y2019
{
    public class Day04 : IAoCDay
    {
        public string SolvePart1(string input = null)
        {
            input ??= this.input;
            int[] range = Array.ConvertAll(input.Split('-'), int.Parse);

            int possiblePassword = 0;
            for (int i = range[0]; i <= range[1]; i++)
            {
                // instead of 5 modulos.. just cast to chars, which is different integers but compares the same
                char[] digits = new String("" + i).ToCharArray();

                // ascending order
                if (digits[0] <= digits[1] && digits[1] <= digits[2] && digits[2] <= digits[3] && digits[3] <= digits[4] && digits[4] <= digits[5])
                {
                    // check for double digit
                    for (int j = 1; j < digits.Length; j++)
                    {
                        if (digits[j - 1] == digits[j])
                        {
                            possiblePassword++;
                            break; // one count is all we need
                        }
                    }
                }
            }
            return "" + possiblePassword;
        }

        public string SolvePart2(string input = null)
        {
            input ??= this.input;
            int[] range = Array.ConvertAll(input.Split('-'), int.Parse);

            int possiblePassword = 0;
            for (int i = range[0]; i <= range[1]; i++)
            {
                // instead of 5 modulos.. just cast to chars, which is different integers but compares the same
                char[] digits = new String("" + i).ToCharArray();

                // ascending order
                if (digits[0] <= digits[1] && digits[1] <= digits[2] && digits[2] <= digits[3] && digits[3] <= digits[4] && digits[4] <= digits[5])
                {
                    // check for double digit
                    for (int j = 1; j < digits.Length; j++)
                    {
                        // left edge
                        if (j == 1) {
                            if (digits[j - 1] == digits[j] && digits[j] != digits[j + 1])
                            { possiblePassword++; break; }
                            else { continue; }
                        }
                        // right edge
                        if (j == digits.Length - 1)
                        {
                            if (digits[j - 1] == digits[j] && digits[j - 2] != digits[j - 1]) { possiblePassword++; break; }
                            else { continue; }
                        }

                        if (digits[j - 2] != digits[j - 1] && digits[j - 1] == digits[j] && digits[j] != digits[j + 1])
                        {
                            possiblePassword++;
                            break; // one count is all we need
                        }
                    }
                }
            }
            return "" + possiblePassword;
        }

        public void Tests()
        {
            //
            Debug.Assert(SolvePart1("333333-333334") == "2");
        }

        public string input = @"265275-781584";
    }
}