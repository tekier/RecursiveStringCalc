using System;
using System.Collections.Generic;


namespace StringCalc
{
    public class StringCalculator
    {
        public char[] delimiters = {',', '\n'};
        public List<int> errorInts = new List<int>();
        public bool isNegative;
        public int Add(string input)
        {
            int total = 0;
            foreach (var unit in input.Split(delimiters))
            {
                int parsed;
                if (input.Length > 3 && input.Substring(0,2).Equals("//"))
                {
                    delimiters = new[] {unit[unit.Length-1]};
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
