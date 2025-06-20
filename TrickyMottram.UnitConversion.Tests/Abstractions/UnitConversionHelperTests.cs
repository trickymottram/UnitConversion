using Moq;
using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Length.Enums;

namespace TrickyMottram.UnitConversion.Tests.Abstractions.Helpers
{
    public class UnitConversionHelperTests
    {
        [Fact]
        public void Convert_CallsConverterWithCorrectSymbols()
        {
            // Arrange
            var mockConverter = new Mock<IUnitConverter>();
            double input = 1.0;
            string expectedFromSymbol = "m";
            string expectedToSymbol = "ft";
            double expectedResult = 3.28084;

            mockConverter.Setup(c =>
                c.Convert(input, expectedFromSymbol, expectedToSymbol))
                .Returns(expectedResult);

            // Act
            var result = UnitConversionHelper.Convert(
                mockConverter.Object,
                input,
                LengthUnit.Meter,
                LengthUnit.Foot,
                unit => unit switch
                {
                    LengthUnit.Meter => "m",
                    LengthUnit.Foot => "ft",
                    _ => throw new ArgumentException()
                });

            // Assert
            Assert.Equal(expectedResult, result);
            mockConverter.Verify(c => c.Convert(input, expectedFromSymbol, expectedToSymbol), Times.Once);
        }

        [Fact]
        public void Convert_ThrowsIfToSymbolFuncReturnsInvalidSymbol()
        {
            // Arrange
            var mockConverter = new Mock<IUnitConverter>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                UnitConversionHelper.Convert(
                    mockConverter.Object,
                    1.0,
                    LengthUnit.Meter,
                    (LengthUnit)999, // invalid enum value
                    _ => throw new ArgumentException("Invalid symbol")
                ));
        }
    }
}