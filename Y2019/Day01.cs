using System;
using System.Diagnostics;

namespace AdventOfCode2019.Y2019
{
    public class Day01 : IAoCDay
    {
        public string SolvePart1(string input = null)
        {
            input = input ?? input1;
            int[] lines = Array.ConvertAll(input.Split(Environment.NewLine), int.Parse);

            // part 1
            int totalPart1 = 0;
            foreach (int fuel in lines)
            {
                totalPart1 += (fuel / 3) - 2;
            }

            return "" + totalPart1;
        }

        public string SolvePart2(string input = null)
        {
            input = input ?? input1;
            // part 2
            int[] lines = Array.ConvertAll(input.Split(Environment.NewLine), int.Parse);
            int totalPart2 = 0;
            int totalIterations = 0;
            foreach (int fuel in lines)
            {
                int recalculatedFuel = fuel; // store as variable that gradually decrements
                while (recalculatedFuel > 0)
                {
                    int newFuel = (recalculatedFuel / 3) - 2;
                    if (newFuel > 0)
                    {
                        totalPart2 += newFuel;
                    }
                    recalculatedFuel = newFuel;
                    totalIterations++;
                }
            }
            Debug.WriteLine($"Day 01 - SolvePart2 had {totalIterations} iterations");
            return ($"{totalPart2}");
        }

        // Tests

        public void Tests()
        {
            // part 01
            Debug.Assert(SolvePart1("12") == "2");
            Debug.Assert(SolvePart1("14") == "2");
            Debug.Assert(SolvePart1("1969") == "654");
            Debug.Assert(SolvePart1("100756") == "33583");

            // part 02
            Debug.Assert(SolvePart2("12") == "2");
            Debug.Assert(SolvePart2("14") == "2");
            Debug.Assert(SolvePart2("1969") == "966");
            Debug.Assert(SolvePart2("100756") == "50346");
        }

        // My personal input
        public string input1 = @"114106
87170
133060
70662
134140
125874
50081
133117
100409
95098
70251
134043
87501
85034
110678
80615
64647
88555
106387
143755
101246
142348
92684
62051
94894
65873
78473
64042
147982
145898
85591
121413
132163
94351
80080
73554
106598
135174
147951
132517
50925
115752
114022
73448
50451
56205
81474
90028
124879
137452
91036
87221
126590
130592
91503
148689
86526
105924
52411
146708
149280
52100
80024
115412
91204
132726
59837
129863
140980
109574
103013
84105
138883
144861
126708
140290
54417
138154
125187
91537
90338
61150
61702
95888
100484
82115
122141
63986
138234
54150
57651
124570
88460
112144
112334
119114
58220
143221
86568
148706";

       
    }
}