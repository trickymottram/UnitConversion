using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Temperature.Registry;

namespace TrickyMottram.UnitConversion.Tests.Temperature.Registry
{
    public class TemperatureUnitRegistryTests
    {
        private readonly IUnitRegistry _registry = new TemperatureUnitRegistry();

        [Fact]
        public void Category_ReturnsTemperature()
        {
            Assert.Equal("Temperature", _registry.Category);
        }

        [Fact]
        public void GetAllUnits_ReturnsExpectedUnits()
        {
            var units = _registry.GetAllUnits();
            Assert.Contains("Celsius", units.Keys);
            Assert.Equal("c", units["Celsius"]);
        }

        [Fact]
        public void GetAllUnits_IsCaseInsensitive()
        {
            var units = _registry.GetAllUnits();
            Assert.True(units.ContainsKey("celsius"));
            Assert.Equal("c", units["celsius"]);
        }
    }
}