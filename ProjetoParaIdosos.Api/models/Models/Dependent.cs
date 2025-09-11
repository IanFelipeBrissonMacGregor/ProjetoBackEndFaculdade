using System.Collections.Generic;

namespace ProjetoBackEnd.Api.Models
{
    public class Dependent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string HealthStatus { get; set; } = "Good";
        public string ImportantInfo { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;

        public int PartnerId { get; set; }
        public Partner Partner { get; set; } = null!;
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
