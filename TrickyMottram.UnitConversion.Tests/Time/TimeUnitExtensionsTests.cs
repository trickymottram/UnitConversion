using TrickyMottram.UnitConversion.Time.Enums;
using TrickyMottram.UnitConversion.Time.Extensions;

namespace TrickyMottram.UnitConversion.Tests.Time.Extensions
{
    public class TimeUnitExtensionsTests
    {
        [Theory]
        [InlineData(TimeUnit.Nanosecond, "ns")]
        [InlineData(TimeUnit.Microsecond, "µs")]
        [InlineData(TimeUnit.Millisecond, "ms")]
        [InlineData(TimeUnit.Second, "s")]
        [InlineData(TimeUnit.Minute, "min")]
        [InlineData(TimeUnit.Hour, "h")]
        [InlineData(TimeUnit.Day, "d")]
        [InlineData(TimeUnit.Week, "wk")]
        [InlineData(TimeUnit.Month, "mo")]
        [InlineData(TimeUnit.Year, "yr")]
        public void ToSymbol_ValidEnum_ReturnsCorrectSymbol(TimeUnit unit, string expected)
        {
            var result = unit.ToSymbol();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ns", TimeUnit.Nanosecond)]
        [InlineData("µs", TimeUnit.Microsecond)]
        [InlineData("ms", TimeUnit.Millisecond)]
        [InlineData("s", TimeUnit.Second)]
        [InlineData("min", TimeUnit.Minute)]
        [InlineData("h", TimeUnit.Hour)]
        [InlineData("d", TimeUnit.Day)]
        [InlineData("wk", TimeUnit.Week)]
        [InlineData("mo", TimeUnit.Month)]
        [InlineData("yr", TimeUnit.Year)]
        public void FromSymbol_ValidSymbol_ReturnsEnum(string symbol, TimeUnit expected)
        {
            var result = TimeUnitExtensions.FromSymbol(symbol);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromSymbol_InvalidSymbol_Throws()
        {
            Assert.Throws<ArgumentException>(() => TimeUnitExtensions.FromSymbol("invalid"));
        }
    }
}