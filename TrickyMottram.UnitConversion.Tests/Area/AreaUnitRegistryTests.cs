using TrickyMottram.UnitConversion.Area.Registry;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;

namespace TrickyMottram.UnitConversion.Tests.Area.Registry
{
    public class AreaUnitRegistryTests
    {
        private readonly IUnitRegistry _registry = new AreaUnitRegistry();

        [Fact]
        public void Category_ReturnsArea()
        {
            Assert.Equal("Area", _registry.Category);
        }

        [Fact]
        public void GetAllUnits_ReturnsExpectedUnits()
        {
            var units = _registry.GetAllUnits();
            Assert.Contains("SquareMeter", units.Keys);
            Assert.Equal("m2", units["SquareMeter"]);
        }

        [Fact]
        public void GetAllUnits_IsCaseInsensitive()
        {
            var units = _registry.GetAllUnits();
            Assert.True(units.ContainsKey("squaremeter"));
            Assert.Equal("m2", units["squaremeter"]);
        }
    }
}