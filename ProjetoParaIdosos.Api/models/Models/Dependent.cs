using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Partner? Partner { get; set; }  // <- agora é opcional

        public List<Visit> Visits { get; set; } = new();
    }
}
