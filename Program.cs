using System;

namespace AdventOfCode2019
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(input1.Split(Environment.NewLine), int.Parse);
            
            // part 1
            int totalPart1 = 0;
            foreach (int input in inputs) {
                totalPart1 += ((input/3)-2);
            }

            Console.WriteLine($"total Part 1: {totalPart1}");

            // part 2
            long totalPart2 = 0;
            foreach (int input in inputs)
            {
                int tmp = input; // store as variable that gradually decrements
                while (tmp > 0) {
                    int tmp2 = ((tmp / 3) - 2);
                    if (tmp2 > 0)
                    {
                        totalPart2 += tmp2;
                    }
                    tmp = tmp2;
                }
                
                
            }
            Console.WriteLine($"total Part 2: {totalPart2}");
        }


        public static string input1 = @"114106
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
