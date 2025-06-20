using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Area;
using TrickyMottram.UnitConversion.Area.Enums;

namespace TrickyMottram.UnitConversion.Tests.Area.Converters
{
    public class AreaConverterTypedTests
    {
        private readonly AreaConverter _converter;

        public AreaConverterTypedTests()
        {
            var logger = new Mock<ILogger<AreaConverter>>();
            _converter = new AreaConverter(logger.Object);
        }

        [Theory]
        [InlineData(1.0, AreaUnit.SquareMeter, AreaUnit.SquareCentimeter, 10_000.0)]
        [InlineData(1.0, AreaUnit.SquareKilometer, AreaUnit.SquareMeter, 1_000_000.0)]
        [InlineData(1.0, AreaUnit.Acre, AreaUnit.SquareMeter, 4046.8564224)]
        [InlineData(1.0, AreaUnit.SquareFoot, AreaUnit.SquareInch, 144.0)]
        [InlineData(1.0, AreaUnit.SquareInch, AreaUnit.SquareFoot, 1.0 / 144.0)]
        [InlineData(1.0, AreaUnit.SquareMile, AreaUnit.SquareKilometer, 2.589988110336)]
        public void Convert_TypedEnums_ReturnsExpected(double input, AreaUnit from, AreaUnit to, double expected)
        {
            var result = _converter.Convert(input, from, to);
            Assert.InRange(result, expected * 0.999, expected * 1.001); // Tolerance
        }

        [Fact]
        public void Convert_InvalidEnum_Throws()
        {
            var invalid = (AreaUnit)999;

            Assert.Throws<ArgumentException>(() =>
                _converter.Convert(1.0, AreaUnit.SquareMeter, invalid));
        }
    }
}