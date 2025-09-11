using ProjetoBackEnd.Api.Models;
using System;

namespace ProjetoBackEnd.Api.Models.DTOs
{
    public class VisitDTO
    {
        public string Name { get; set; } = string.Empty;
        public DependentCondition DependentCondition { get; set; }
        public EnvironmentCondition EnvironmentCondition { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SatisfactionNote { get; set; }
        public int DependentId { get; set; }
    }
}
