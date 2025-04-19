namespace Src.Models;

public class Sector
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string ColorIdentify { get; set; }
    public required int MotoQuantity { get; set; }
    public Patio? Patio { get; set; }
    public required long PatioId { get; set; }
    public List<Moto> Motos { get; set; } = new();
}
