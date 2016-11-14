using System;
using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using NUnit.Framework;
using StringCalc;

namespace StringCalcTest
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private StringCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new StringCalculator();
        }

        [TestCase("", 0)]
        [TestCase("1", 1)] //simple
        [TestCase("2", 2)] //simple
        [TestCase("1,2", 3)] //simple
        [TestCase("2,2,3", 7)] //default delim
        [TestCase("4,4,4,4,4,4,4,4,4,4,4,4,4,4,4", 60)] //default delim
        [TestCase("1\n2,3", 6)] //default delimS
        [TestCase("1,\n", 0)] //invalid
        [TestCase("1\n3,6\n3", 13)] //default delimS
        [TestCase("1,asdf,3,6\n3", 0)] //invalid
        public void ReturnCorrectResultForDefaultDelimiterInput(string input, int expectedOutput)
        {
            int actualResult = calculator.Add(input);
            actualResult.Should().Be(expectedOutput);
        }

        [TestCase("//;\n1;2", 3)] //custom delim
        [TestCase("//;\n1;2;3;5",11)] //custom delim
        [TestCase("//;\n1;2;3,12", 0)] //invalid
        [TestCase("//;\n4,5,5", 0)] //invalid
        [TestCase("//;4;5;5", 0)] //invalid
        [TestCase("//a\n1a2a3", 6)] //custom delim
        [TestCase("//a\n1,2", 0)] //invalid
        [TestCase("//%\n0%0%1", 1)] //custom delim
        public void ReturnCorrectResultForCustomDelimiterInputs(string input, int expectedOutput)
        {
            int actualResult = calculator.Add(input);
            actualResult.Should().Be(expectedOutput);
        }

        [TestCase("3,1,-3")] //simple neg
        [TestCase("1,9,-4,-5,6,-9,4,1,-3,5,-6,-1")] //complex neg
        [TestCase("//^\n-5^9")] //custom delims neg
        public void ThrowExceptionWhenNegativeNumberInInput(string input)
        {
            Action tryAdd = () => calculator.Add(input);
            tryAdd.ShouldThrow<NegativeComponentException>();
        }

        [TestCase("2,1001", 2)]
        [TestCase("5000,5000,1000,1,5000,999", 2000)]
        public void IgnoreNumbersBiggerThan1000(string input, int expectedResult)
        {
            int acutualResult = calculator.Add(input);
            acutualResult.Should().Be(expectedResult);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[!!!!]\n1!!!!4!!!!2",7)]
        public void AllowDelimitersOfAnyLength(string input, int expectedResult)
        {
            int acutalResult = calculator.Add(input);
            acutalResult.Should().Be(expectedResult);

        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[^][$][!]\n3^2$1!5", 11)]
        public void AllowMutipleDelimtersInInputString(string input, int expectedResult)
        {
            int actualResult = calculator.Add(input);
            actualResult.Should().Be(expectedResult);
        }

        [TestCase("//[**][$$]\n5**3$$0", 8)]
        [TestCase("//[!!][^^][--]\n700!!100^^47--3",850)]
        public void AllMultipleDelimitersWithMultilengthString(string input, int expectedResult)
        {
            int actualResult = calculator.Add(input);
            actualResult.Should().Be(expectedResult);
        }
    }
}
