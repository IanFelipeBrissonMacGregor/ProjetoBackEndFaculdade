using System;
using System.Text.Json.Serialization;

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
        private DateTime _startTime = DateTime.UtcNow;
        private DateTime _endTime = DateTime.UtcNow;

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DependentCondition DependentCondition { get; set; }
        public EnvironmentCondition EnvironmentCondition { get; set; }

        public DateTime StartTime
        {
            get => _startTime;
            set => _startTime = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value.ToUniversalTime();
        }

        public DateTime EndTime
        {
            get => _endTime;
            set => _endTime = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value.ToUniversalTime();
        }

        public int SatisfactionNote { get; set; }
        public int DependentId { get; set; }

        [JsonIgnore]
        public Dependent? Dependent { get; set; }
    }
}