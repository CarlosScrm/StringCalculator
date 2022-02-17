using System;
using Xunit;

namespace StringCalculatorTest
{
    public class StringCalculator_Add
    {
        private StringCalculator _calculator = new StringCalculator();

        [Fact]
        public void Given_Empty_string_then_Returns_0()
        {
            var result = _calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Given_string_number_then_Returns_number(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void Given_Two_comma_separated_numbers_then_Returns_sum(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("2,3,4", 9)]
        public void Given_Three_comma_separated_numbers_then_Returns_sum(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3", 6)]
        [InlineData("1,2\n3", 6)]
        public void Given_Three_comma_or_new_line_separated_numbers_then_Returns_sum(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        public void Given_Custom_separator_numbers_then_Returns_sum(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("-1,2", "Negative numbers not allowed: -1")]
        [InlineData("-1,-2", "Negative numbers not allowed: -1,-2")]
        public void Given_negative_input_then_Throws_Exception(string numbers, string expectedResult)
        {
            Action action = () => _calculator.Add(numbers);

            var ex = Assert.Throws<Exception>(action);

            Assert.Equal(expectedResult, ex.Message);
        }

        [Theory]
        [InlineData("1,2,3000", 3)]
        [InlineData("1001,2", 2)]
        [InlineData("1000,2", 1002)]
        public void Given_number_over_1000_then_Ignore_values(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}