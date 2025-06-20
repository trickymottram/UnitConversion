using Moq;
using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Service;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;

namespace TrickyMottram.UnitConversion.Tests.Service
{
    public class UnitConversionServiceTests
    {
        private readonly Mock<IUnitConverter> _mockConverter;
        private readonly UnitConversionService _service;

        public UnitConversionServiceTests()
        {
            _mockConverter = new Mock<IUnitConverter>();
            var loggerMock = new Mock<ILogger<UnitConversionService>>();

            // Setup CanConvert and Convert behavior
            _mockConverter.Setup(c => c.CanConvert("m", "km")).Returns(true);
            _mockConverter.Setup(c => c.Convert(1000, "m", "km")).Returns(1.0);

            _service = new UnitConversionService(new[] { _mockConverter.Object }, loggerMock.Object);
        }

        [Fact]
        public void Convert_ValidUnits_UsesCorrectConverter()
        {
            // Act
            var result = _service.Convert(1000, "m", "km");

            // Assert
            Assert.Equal(1.0, result);
            _mockConverter.Verify(c => c.CanConvert("m", "km"), Times.Once);
            _mockConverter.Verify(c => c.Convert(1000, "m", "km"), Times.Once);
        }

        [Fact]
        public void Convert_NoMatchingConverter_ThrowsNotSupportedException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<UnitConversionService>>();
            var incompatibleConverter = new Mock<IUnitConverter>();
            incompatibleConverter.Setup(c => c.CanConvert(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            var service = new UnitConversionService(new[] { incompatibleConverter.Object }, loggerMock.Object);

            // Act & Assert
            var ex = Assert.Throws<NotSupportedException>(() => service.Convert(10, "x", "y"));
            Assert.Contains("Conversion from x to y is not supported", ex.Message);
        }

        [Fact]
        public void Convert_ZeroConverters_ThrowsNotSupportedException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<UnitConversionService>>();
            var service = new UnitConversionService(new List<IUnitConverter>(), loggerMock.Object);

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => service.Convert(1.0, "m", "km"));
        }
    }
}