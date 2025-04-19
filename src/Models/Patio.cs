namespace Src.Models;

public class Patio
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required int MotoQuantity { get; set; }
    public required List<Sector> Sectors { get; set; } = new();
}
