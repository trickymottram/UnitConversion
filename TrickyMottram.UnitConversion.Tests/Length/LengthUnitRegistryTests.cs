using TrickyMottram.UnitConversion.Length.Registry;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;

namespace TrickyMottram.UnitConversion.Tests.Length.Registry
{
    public class LengthUnitRegistryTests
    {
        private readonly IUnitRegistry _registry = new LengthUnitRegistry();

        [Fact]
        public void Category_ReturnsLength()
        {
            Assert.Equal("Length", _registry.Category);
        }

        [Fact]
        public void GetAllUnits_ReturnsExpectedUnits()
        {
            var units = _registry.GetAllUnits();
            Assert.Contains("Meter", units.Keys);
            Assert.Equal("m", units["Meter"]);
        }

        [Fact]
        public void GetAllUnits_IsCaseInsensitive()
        {
            var units = _registry.GetAllUnits();
            Assert.True(units.ContainsKey("meter"));
            Assert.Equal("m", units["meter"]);
        }
    }
}