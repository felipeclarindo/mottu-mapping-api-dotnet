namespace Src.Models;

public class Moto
{
    public long Id { get; set; }
    public string? Plate { get; set; }
    public long SectorId { get; set; }
    public Sector? Sector { get; set; }
}
