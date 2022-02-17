using Xunit;

namespace StringCalculatorTest
{
    public class StringCalculator_Add
    {
        [Fact]
        public void Given_Empty_string_then_Returns_0()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Given_string_number_then_Returns_number(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void Given_comma_separated_numbers_then_Returns_sum(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}