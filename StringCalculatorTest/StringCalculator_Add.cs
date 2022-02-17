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
    }
}