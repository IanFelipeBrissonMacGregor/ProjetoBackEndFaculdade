using System.Collections.Generic;

namespace ProjetoBackEnd.Api.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
