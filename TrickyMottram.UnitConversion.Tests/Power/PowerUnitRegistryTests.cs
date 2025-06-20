using TrickyMottram.UnitConversion.Power.Registry;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;

namespace TrickyMottram.UnitConversion.Tests.Power.Registry
{
    public class PowerUnitRegistryTests
    {
        private readonly IUnitRegistry _registry = new PowerUnitRegistry();

        [Fact]
        public void Category_ReturnsPower()
        {
            Assert.Equal("Power", _registry.Category);
        }

        [Fact]
        public void GetAllUnits_ReturnsExpectedUnits()
        {
            var units = _registry.GetAllUnits();
            Assert.Contains("Watt", units.Keys);
            Assert.Equal("w", units["Watt"]);
        }

        [Fact]
        public void GetAllUnits_IsCaseInsensitive()
        {
            var units = _registry.GetAllUnits();
            Assert.True(units.ContainsKey("watt"));
            Assert.Equal("w", units["watt"]);
        }
    }
}