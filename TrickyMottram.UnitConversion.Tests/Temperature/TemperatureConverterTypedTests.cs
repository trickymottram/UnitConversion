using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Temperature;
using TrickyMottram.UnitConversion.Temperature.Enums;

namespace TrickyMottram.UnitConversion.Tests.Temperature.Converters
{
    public class TemperatureConverterTypedTests
    {
        private readonly TemperatureConverter _converter;

        public TemperatureConverterTypedTests()
        {
            var logger = new Mock<ILogger<TemperatureConverter>>();
            _converter = new TemperatureConverter(logger.Object);
        }

        [Theory]
        [InlineData(0.0, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 32.0)]
        [InlineData(100.0, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 373.15)]
        [InlineData(0.0, TemperatureUnit.Kelvin, TemperatureUnit.Celsius, -273.15)]
        [InlineData(0.0, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -17.7778)]
        [InlineData(0.0, TemperatureUnit.Rankine, TemperatureUnit.Celsius, -273.15)]
        [InlineData(100.0, TemperatureUnit.Celsius, TemperatureUnit.Reaumur, 80.0)]
        public void Convert_TypedEnums_ReturnsExpected(double input, TemperatureUnit from, TemperatureUnit to, double expected)
        {
            var result = _converter.Convert(input, from, to);
            Assert.True(Math.Abs(result - expected) < 0.01, $"Expected {expected}, but got {result}");
        }

        [Fact]
        public void Convert_InvalidEnum_Throws()
        {
            var invalid = (TemperatureUnit)999;

            Assert.Throws<ArgumentException>(() =>
                _converter.Convert(100.0, TemperatureUnit.Celsius, invalid));
        }
    }
}