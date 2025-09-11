namespace ProjetoBackEnd.Api.Models.DTOs
{
    public class ElderlyDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsIsolated { get; set; }
        public string HealthStatus { get; set; } = "Good";
    }
}
