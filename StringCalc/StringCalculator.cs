using System;
using System.Collections.Generic;


namespace StringCalc
{
    public class StringCalculator
    {
        private char[] delimiters = {',', '\n'};
        private List<int> errorInts = new List<int>();
        private bool isNegative;
        private string delimiterStartIndicator = "//";
        private int minimumLengthOfCustomDelimiterString = 3;
        private int baseIndexOfString = 0;
        private int lengthOfDelimiterString = 2;

        public int Add(string input)
        {
            int total = 0;
            foreach (var unit in input.Split(delimiters))
            {
                int parsed;
                if (input.Length > minimumLengthOfCustomDelimiterString &&
                    input.Substring(baseIndexOfString, lengthOfDelimiterString)
                        .Equals(delimiterStartIndicator))
                {
                    delimiters = new[] {unit[unit.Length - 1]};
                    return Add(input.Substring(unit.Length));
                }
                try
                {
                    parsed = Int32.Parse(unit);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
                if (parsed < 0)
                {
                    errorInts.Add(parsed);
                    isNegative = true;
                }
                total += parsed;
            }
            if (isNegative)
                throw new NegativeComponentException(errorInts);
            return total;
        }
    }
}
