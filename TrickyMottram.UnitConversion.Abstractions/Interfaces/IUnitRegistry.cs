namespace TrickyMottram.UnitConversion.Abstractions.Interfaces
{
    public interface IUnitRegistry
    {
        string Category { get; }
        IReadOnlyDictionary<string, string> GetAllUnits();
    }
}