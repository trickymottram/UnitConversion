using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Time.Registry;

namespace TrickyMottram.UnitConversion.Tests.Time.Registry
{
    public class TimeUnitRegistryTests
    {
        private readonly IUnitRegistry _registry = new TimeUnitRegistry();

        [Fact]
        public void Category_ReturnsTime()
        {
            Assert.Equal("Time", _registry.Category);
        }

        [Fact]
        public void GetAllUnits_ReturnsExpectedUnits()
        {
            var units = _registry.GetAllUnits();
            Assert.Contains("Second", units.Keys);
            Assert.Equal("s", units["Second"]);
        }

        [Fact]
        public void GetAllUnits_IsCaseInsensitive()
        {
            var units = _registry.GetAllUnits();
            Assert.True(units.ContainsKey("second"));
            Assert.Equal("s", units["second"]);
        }
    }
}