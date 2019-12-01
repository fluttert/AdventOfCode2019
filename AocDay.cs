using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    interface AocDay
    {
        public string SolvePart1(string input);

        public string SolvePart2(string input);

        public void Tests();
    }
}