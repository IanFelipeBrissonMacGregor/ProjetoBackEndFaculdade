namespace ProjetoBackEnd.Api.Models
{
    public class Elderly
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool IsIsolated { get; set; }
        public string HealthStatus { get; set; } = "Good";
    }
}
