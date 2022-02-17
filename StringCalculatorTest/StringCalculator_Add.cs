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
    }
}