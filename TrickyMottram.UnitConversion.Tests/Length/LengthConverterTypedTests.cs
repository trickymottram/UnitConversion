using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Length;
using TrickyMottram.UnitConversion.Length.Enums;

namespace TrickyMottram.UnitConversion.Tests.Length.Converters
{
    public class LengthConverterTypedTests
    {
        private readonly LengthConverter _converter;

        public LengthConverterTypedTests()
        {
            var logger = new Mock<ILogger<LengthConverter>>();
            _converter = new LengthConverter(logger.Object);
        }

        [Theory]
        [InlineData(1.0, LengthUnit.Meter, LengthUnit.Centimeter, 100.0)]
        [InlineData(2.54, LengthUnit.Centimeter, LengthUnit.Inch, 1.0)]
        [InlineData(3.28084, LengthUnit.Foot, LengthUnit.Meter, 1.0)]
        [InlineData(1.0, LengthUnit.Mile, LengthUnit.Kilometer, 1.609344)]
        public void Convert_TypedEnums_ReturnsExpectedResult(double input, LengthUnit from, LengthUnit to, double expected)
        {
            var result = _converter.Convert(input, from, to);

            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void Convert_InvalidEnum_Throws()
        {
            var invalid = (LengthUnit)999;

            Assert.Throws<ArgumentException>(() =>
                _converter.Convert(1.0, LengthUnit.Meter, invalid));
        }
    }
}