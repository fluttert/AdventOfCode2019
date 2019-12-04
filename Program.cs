using AdventOfCode2019.Y2019;
using System;
using System.Diagnostics;

namespace AdventOfCode2019
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Also display the rough runtime
            Stopwatch stopwatch = new Stopwatch();

            // init day + run tests if available
            //var day = new Day01();
            //var day = new Day02();
            //var day = new Day03();
            var day = new Day04();
            day.Tests();
            
            
            stopwatch.Start();
            Console.WriteLine($"Part 1 answer {day.SolvePart1()}, in {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset(); 
            stopwatch.Start();
            Console.WriteLine($"Part 2 answer {day.SolvePart2()}, in {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Stop();
        }
    }
}