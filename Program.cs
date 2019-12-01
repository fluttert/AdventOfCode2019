using AdventOfCode2019.Y2019;
using System;
using System.Diagnostics;

namespace AdventOfCode2019
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            var day = new Day01();
            
            stopwatch.Start();
            Console.WriteLine($"Part 1 answer {day.SolvePart1()}, in {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset(); 
            stopwatch.Start();
            Console.WriteLine($"Part 2 answer {day.SolvePart2()}, in {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Stop();
        }
    }
}