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
        public void Given_string_1_then_Returns_1(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}