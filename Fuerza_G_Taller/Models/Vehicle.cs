namespace Fuerza_G_Taller.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string? Plate { get; set; }
        public int? ModelId { get; set; }
        public short? Year { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ModifiedByUserId { get; set; }
    }
}
