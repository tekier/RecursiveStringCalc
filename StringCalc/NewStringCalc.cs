using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class NewStringCalc
    {
        private char[] delimiters = { ',', '\n' };
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
                total = ActuallyAdd(input, unit);
            }
        }

        public bool IsCustomDelimiter(string input)
        {
            return input.Length > minimumLengthOfCustomDelimiterString &&
                   input.Substring(baseIndexOfString, lengthOfDelimiterString)
                       .Equals(delimiterStartIndicator);
        }

        public int CalculateValueOfCustomDelimitedString(string unit, string input)
        {
            delimiters = new[] { unit[unit.Length - 1] };
            return ActuallyAdd(input.Substring(unit.Length));
        }
    }
}
