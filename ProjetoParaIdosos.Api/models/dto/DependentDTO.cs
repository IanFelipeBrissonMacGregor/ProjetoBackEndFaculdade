namespace ProjetoBackEnd.Api.Models.DTOs
{
    public class DependentDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string HealthStatus { get; set; } = "Good";
        public string ImportantInfo { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public int PartnerId { get; set; }
    }
}
