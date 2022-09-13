using API.Models;
using AutoMapper;

namespace API.Mapper.Action
{
    public class AddStationToStepAction : IMappingAction<Domain.Entities.Route, RouteViewModel>
    {
        public void Process(Domain.Entities.Route source, RouteViewModel destination, ResolutionContext context)
        {
            //var stations = destination.Stations.ToDictionary(
            //                    keySelector: station => station.Id,
            //                    elementSelector: station => station
            //                );

            //for (var index = 0; index < destination.Steps.Count; index++)
            //{
            //    var step = destination.Steps[index];
            //    if (step.StationId != null && stations.TryGetValue((int)step.StationId, out StationViewModel? value))
            //    {
            //        destination.Steps[index].Station = value;
            //    }
            //}
        }
    }
}
