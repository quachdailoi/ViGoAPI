using Newtonsoft.Json;

namespace API.Models
{
    public class InvalidRoutineViewModel
    {
        public RouteRoutineViewModel ConflictedRoutine { get; set; }
        [JsonIgnore]
        public TimeOnly ValidTime { get; set; }
        [JsonIgnore]
        public string Compare { get; set; }
    }
}
