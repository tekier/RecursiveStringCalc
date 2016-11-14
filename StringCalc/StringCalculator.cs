using System;
using System.Collections.Generic;
using System.Linq;


namespace StringCalc
{
    public class StringCalculator
    {
        private string[] delimiters = {",", "\n"};
        private List<int> errorInts = new List<int>();
        private bool isNegative;
        private string delimiterStartIndicator = "//";
        private int minimumLengthOfCustomDelimiterString = 3;
        private int baseIndexOfString = 0;
        private int lengthOfDelimiterString = 2;
        private int total = 0;

        public int Add(string input)
        {
            foreach (var substringOfInputDelimiters in input.Split(delimiters, StringSplitOptions.None))
            {
                int parsed;
                if (StringContainsCustomDelimiter(input))
                {
                    int indexOfUnit = 2;
                    string delimiterString = String.Empty;
                    if (substringOfInputDelimiters[2].Equals('['))
                    {
                        delimiters = GetMultilengthDelimiter(indexOfUnit, substringOfInputDelimiters+'s');
                    }
                    else
                    {
                        delimiterString = substringOfInputDelimiters[substringOfInputDelimiters.Length - 1].ToString();
                        delimiters = new[] { delimiterString[0].ToString() };
                    }
                    return Add(input.Substring(substringOfInputDelimiters.Length));
                }
                try
                {
                    parsed = Int32.Parse(substringOfInputDelimiters);
                }
                catch (FormatException e)
                {
                    return 0;
                }
                CheckAndHandleNegativeNumbers(parsed);
                
                total += ApplyConditionsToParsedAndAddToTotal(substringOfInputDelimiters);
            }
            CheckIfInputHadNegativeIntegers();
            return total;
        }

        private string[] GetMultilengthDelimiter(int indexOfUnit, string unit)
        {
            indexOfUnit++;
            string delimiterString = string.Empty;
            while (unit[indexOfUnit] != 's')
            {
                delimiterString += unit[indexOfUnit];
                indexOfUnit++;
            }
            string[] delimiterSubstringDelimiters = {"[", "]"};
            return delimiterString.Split(delimiterSubstringDelimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private void CheckIfInputHadNegativeIntegers()
        {
            if (isNegative)
                throw new NegativeComponentException(errorInts);
        }

        private void CheckAndHandleNegativeNumbers(int parsed)
        {
            if (parsed < 0)
            {
                errorInts.Add(parsed);
                isNegative = true;
            }
        }

        private bool StringContainsCustomDelimiter(string input)
        {
            return input.Length > minimumLengthOfCustomDelimiterString &&
                   input.Substring(baseIndexOfString, lengthOfDelimiterString)
                       .Equals(delimiterStartIndicator);
        }

        private int ApplyConditionsToParsedAndAddToTotal(string unit)
        {
            int parsed;
            try
            {
                parsed = Int32.Parse(unit);
            }
            catch (FormatException e)
            {
                return 0;
            }
            if (parsed > 1000)
            {
                return 0;
            }
            
            return parsed;
        }
    }
}
