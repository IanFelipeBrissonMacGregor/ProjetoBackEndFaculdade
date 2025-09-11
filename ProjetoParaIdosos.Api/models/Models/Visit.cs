using System;

namespace ProjetoBackEnd.Api.Models
{
    public enum DependentCondition
    {
        Good,
        Medium,
        Bad
    }

    public enum EnvironmentCondition
    {
        Safe,
        Normal,
        Risky
    }

    public class Visit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DependentCondition DependentCondition { get; set; }
        public EnvironmentCondition EnvironmentCondition { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SatisfactionNote { get; set; }

        public int DependentId { get; set; }
        public Dependent Dependent { get; set; } = null!;
    }
}
