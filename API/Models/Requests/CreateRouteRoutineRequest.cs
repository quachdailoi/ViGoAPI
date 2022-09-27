using API.Extensions;
using API.Validators;
using FluentValidation;
using System.Text.Json.Serialization;

namespace API.Models.Requests
{
    public class CreateRouteRoutineRequest
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string RouteCode { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public string StartTime { get; set; }

        [JsonIgnore]
        public Domain.Entities.Route Route { get; set; } = new();
        [JsonIgnore]
        public DateOnly StartAtParsed { get; set; }
        [JsonIgnore]
        public DateOnly EndAtParsed { get; set; }
        [JsonIgnore]
        public TimeOnly StartTimeParsed { get; set; }
        [JsonIgnore]
        public TimeOnly EndTimeParsed { get; set; }
    }
}
