using System;
using Fit4You.Core.Services;
using Xunit;

namespace Fit4You.Tests
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

        //[Fact]
        //public void CalculateBMR_UserIsMale_WorksFine()
        //{
        //    var calculator = new CalculatorService();

        //    var result = calculator.CalculateBMR();

        //    Assert.
        //}
    }
}
