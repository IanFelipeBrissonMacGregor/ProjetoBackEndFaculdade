namespace ProjetoBackEnd.Api.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Valor { get; set; }
        public string FeaturesIncluidas { get; set; } = string.Empty;

        public List<Dependent> Dependents { get; set; } = new();
    }
}
