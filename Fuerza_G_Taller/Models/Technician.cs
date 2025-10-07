namespace Fuerza_G_Taller.Models
{
    public class Technician
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Address { get; set; }
        public decimal BaseSalary { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ModifiedByUserId { get; set; }
    }
}
