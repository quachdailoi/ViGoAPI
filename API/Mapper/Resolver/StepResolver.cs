using API.Models;
using AutoMapper;

namespace API.Mapper.Resolver
{
    public class StepResolver : IValueResolver<Domain.Entities.Route, RouteViewModel, List<StepViewModel>>
    {
        public List<StepViewModel> Resolve(Domain.Entities.Route source, RouteViewModel destination, List<StepViewModel> destMembers, ResolutionContext context)
        {
            var stations = destination.Stations.ToDictionary(
                    keySelector: station => station.Id,
                    elementSelector: station => station
                );

            destMembers = new(source.Steps.Count);

            for (var index = 0; index < source.Steps.Count; index++)
            {
                var step = source.Steps[index];
                var stepViewModel = new StepViewModel
                {
                    Bound = step.Bound,
                    Distance = step.Distance,
                    Duration = step.Duration,
                    StartPoint = step.StartPoint,
                    EndPoint = step.EndPoint,
                    Maneuver = step.Maneuver
                };
                if (step.StationId != null && stations.TryGetValue((int)destMembers[index].StationId, out StationViewModel value))
                {
                    stepViewModel.Station = value;
                }

                destMembers.Add(stepViewModel);
            }

            return destMembers;
        }
    }
}
