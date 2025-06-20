using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Weight.Registry;

namespace TrickyMottram.UnitConversion.Tests.Weight.Registry
{
    public class WeightUnitRegistryTests
    {
        private readonly IUnitRegistry _registry = new WeightUnitRegistry();

        [Fact]
        public void Category_ReturnsWeight()
        {
            Assert.Equal("Weight", _registry.Category);
        }

        [Fact]
        public void GetAllUnits_ReturnsExpectedUnits()
        {
            var units = _registry.GetAllUnits();
            Assert.Contains("Kilogram", units.Keys);
            Assert.Equal("kg", units["Kilogram"]);
        }

        [Fact]
        public void GetAllUnits_IsCaseInsensitive()
        {
            var units = _registry.GetAllUnits();
            Assert.True(units.ContainsKey("kilogram"));
            Assert.Equal("kg", units["kilogram"]);
        }
    }
}