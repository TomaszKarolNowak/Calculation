using Calculation.Models;
using Calculation.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CalculationTests.ServicesTests.CalculationServiceTests
{
    public class CalculateAverageValueAndSumTests
    {
        public CalculationService Service { get; private set; }

        public CalculateAverageValueAndSumTests()
        {
            Service = new CalculationService();
        }

        [Fact]
        public async Task Given_Null_When_CalculateAverageValueAndSumIsCalled_Then_ExceptionIsThrown()
        {
            // Act
            var exception = await Record.ExceptionAsync(() => Service.CalculateAverageValueAndSum(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task Given_NoValues_When_CalculateAverageValueAndSumIsCalled_Then_ZeroValuesAreReturned()
        {
            // Arrange
            var values = new List<double>();
            var expected = new CalculationResult { Avg = 0.0, Sum = 0.0 };

            // Act
            var actual = await Service.CalculateAverageValueAndSum(values);

            // Arrange
            Assert.Equal(expected.Sum, actual.Sum);
            Assert.Equal(expected.Avg, actual.Avg);
        }

        [Theory]
        [InlineData(1.0, 1.0, 1.0)]
        [InlineData(2.0, 1.0, 0.5, 1.5)]
        [InlineData(22.41, 5.6025, 1.1, 2.3, 5.8, 13.21)]
        [InlineData(0.0, 0.0, -10.0, 10.0)]
        public async Task Given_Values_When_CalculateAverageValueAndSumIsCalled_Then_AverageAndSumIsReturned(
            double expectedSum,
            double expectedAvg,
            params double[] values)
        {
            // Act
            var actual = await Service.CalculateAverageValueAndSum(values);

            // Assert
            Assert.Equal(expectedSum, actual.Sum);
            Assert.Equal(expectedAvg, actual.Avg);
        }

    }
}
