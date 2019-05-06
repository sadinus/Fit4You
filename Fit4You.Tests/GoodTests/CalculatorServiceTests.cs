using System;
using Fit4You.Core.Services;
using Xunit;

namespace Fit4You.Tests.GoodTests
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        [InlineData(-1, -1)]
        [InlineData(1, 1)]
        public void CalculateBMI_NegativeParameters_ReturnsPositiveResult(int weight, int height)
        {
            var calculator = new CalculatorService();

            var actual = calculator.CalculateBMI(weight, height);

            Assert.True(actual > 0);
        }

        [Fact]
        public void CalculateBMI_HeightIsZero_ReturnsZero()
        {
            var expected = 0;
            var calculator = new CalculatorService();

            var actual = calculator.CalculateBMI(20, 0);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void CalculateBMR_ForMale_ShouldWork()
        {
            var calculator = new CalculatorService();
            var expected = 1876.25;
            const int WEIGHT = 82;
            const int HEIGHT = 189;
            const int AGE = 26;
            const bool ISMALE = true;

            var actual = calculator.CalculateBMR(WEIGHT, HEIGHT, AGE, ISMALE);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateBMR_ForFemale_ShouldWork()
        {
            var calculator = new CalculatorService();
            var expected = 1279;

            var actual = calculator.CalculateBMR(55, 160, 22, false);

            Assert.Equal(expected, actual);
        }
    }
}
