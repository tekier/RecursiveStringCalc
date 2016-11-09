using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class NegativeComponentException : Exception
    {
        private List<int> errors;

        public NegativeComponentException(List<int> negInts)
        {
            errors = negInts;
            Print();
        }

        private void Print()
        {
            foreach (var i in errors)
            {
                Console.WriteLine(i.ToString());   
            }
        }
    }
}
