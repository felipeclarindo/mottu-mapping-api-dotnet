namespace MotoMappingApiDotnet.Src.Domain.Entities
{
    public class Moto
    {
        public required long Id { get; set; }
        public required string? Plate { get; set; }
        public required long SectorId { get; set; }
    }
}
