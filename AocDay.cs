namespace AdventOfCode2019
{
    /// <summary>
    /// Default implementation of a Advent of Code challenge day
    /// </summary>
    internal interface AocDay
    {
        /// <summary>
        /// Solve part 1
        /// </summary>
        /// <param name="input">Input for this part</param>
        /// <returns>string - Answer</returns>
        public string SolvePart1(string input);

        /// <summary>
        /// Solve part 2
        /// </summary>
        /// <param name="input">Input for this part</param>
        /// <returns>string - Answer</returns>
        public string SolvePart2(string input);

        /// <summary>
        /// Low-tech test cases using Debug.Assert
        /// </summary>
        public void Tests();
    }
}