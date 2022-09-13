using Domain.Entities;
using Domain.Shares.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Utils
{
    public class DumpData
    {
        private static double Distance(Location firstLocation, Location secondLocation)
        {
            return Math.Sqrt(Math.Pow(firstLocation.Latitude - secondLocation.Latitude, 2) + Math.Pow(firstLocation.Longitude - secondLocation.Longitude, 2));
        }
        private static Location GetNextPoint(Location startPoint, Station middlePoint, Bound bound)
        {
            Location nextPoint = new();
            var randValue = new Random().NextDouble();

            if (startPoint.Longitude == middlePoint.Longitude)
            {
                if (startPoint.Latitude == middlePoint.Latitude)
                {
                    do
                    {
                        nextPoint = DumpLocationInBound(bound);
                    } while (nextPoint.Longitude == middlePoint.Longitude);
                }
                else
                {
                    nextPoint.Longitude = middlePoint.Longitude;
                    nextPoint.Latitude = startPoint.Latitude > middlePoint.Latitude ?
                                        bound.South + randValue * (middlePoint.Latitude - bound.South) :
                                        middlePoint.Latitude + randValue * (bound.North - middlePoint.Latitude);
                }
            }
            else
            {
                nextPoint.Longitude = startPoint.Longitude < middlePoint.Longitude ?
                    middlePoint.Longitude + randValue * (bound.East - middlePoint.Longitude) :
                    bound.West + randValue * (middlePoint.Longitude - bound.West);

                nextPoint.Latitude = (startPoint.Latitude - middlePoint.Latitude) / (startPoint.Longitude - middlePoint.Longitude) * (nextPoint.Longitude - startPoint.Longitude) + middlePoint.Latitude;

                if (nextPoint.Latitude > bound.North || nextPoint.Latitude < bound.South)
                {
                    nextPoint.Latitude = nextPoint.Latitude > bound.North ? bound.North : bound.South;
                    nextPoint.Longitude = (nextPoint.Latitude - startPoint.Latitude) * (startPoint.Longitude - middlePoint.Longitude) / (startPoint.Latitude - middlePoint.Latitude) + startPoint.Longitude;
                }
            }
            return nextPoint;
        }
        private static Bound GetExtendStationBound(Station station, Bound bound)
        {
            var maxLatitude = station.Latitude + 0.001;
            var minLatitude = station.Latitude - 0.001;

            var maxLongitude = station.Longitude + 0.001;
            var minLongitude = station.Longitude - 0.001;

            return new Bound
            {
                East = maxLongitude > bound.East ? bound.East : maxLongitude,
                West = minLongitude < bound.West ? bound.West : minLongitude,
                North = maxLatitude > bound.North ? bound.North : maxLatitude,
                South = minLatitude < bound.South ? bound.South : minLatitude
            };
        }
        private static Station DumpStationInBound(Bound bound, int index)
        {
            Random random = new();
            var randValue = random.NextDouble();

            var longitude = bound.West + randValue * (bound.East - bound.West);
            var latitude = bound.South + randValue * (bound.North - bound.South);

            return new Station
            {
                Latitude = latitude,
                Longitude = longitude,
                Name = index.ToString(),
                Id = index
            };
        }
        private static Location DumpLocationInBound(Bound bound, string name = "")
        {
            Random random = new();
            var randValue = random.NextDouble();

            var longitude = bound.West + randValue * (bound.East - bound.West);
            var latitude = bound.South + randValue * (bound.North - bound.South);

            return new Location
            {
                Latitude = latitude,
                Longitude = longitude,
                LocationName = name
            };
        }
        private static List<Station> DumpStation(int total, Bound bound)
        {
            List<Station> stations = new();


            for (var stationIndex = 1; stationIndex <= total; stationIndex++)
            {
                stations.Add(DumpStationInBound(bound, stationIndex));
            }

            return stations;
        }

        public static Tuple<List<Domain.Entities.Route>, List<RouteStation>, List<Station>> DumpRoute(int totalRoute, int minStep, int maxStep, int totalStation, Bound? bound = null)
        {
            if (bound == null) bound = new Bound
            {
                South = 10.757931,
                West = 106.599666,
                North = 10.858637,
                East = 106.832535
            };
            var stations = DumpStation(totalStation, bound);
            Random random = new Random();

            List<Domain.Entities.Route> routes = new(totalRoute);
            List<RouteStation> routeStations = new();

            var routeStationId = 1;

            for (var routeIndex = 1; routeIndex <= totalRoute; routeIndex++)
            {
                var route = new Domain.Entities.Route();

                var totalStep = random.Next(minStep, maxStep);

                List<Step> steps = new(totalStep);

                var copyStations = stations.ToList();

                var stationIndex = random.Next(0, copyStations.Count - 1);

                var startPoint = DumpLocationInBound(GetExtendStationBound(copyStations[stationIndex], bound));

                for (var stepIndex = 0; stepIndex < totalStep; stepIndex++)
                {
                    var currentStep = new Step();

                    var _stationIndex = stepIndex == 0 ? stationIndex : random.Next(0, copyStations.Count - 1);

                    var extendStationBound = GetExtendStationBound(copyStations[_stationIndex], bound);

                    var nextPoint = GetNextPoint(startPoint, copyStations[_stationIndex], extendStationBound);

                    currentStep.StartPoint = startPoint;
                    currentStep.EndPoint = nextPoint;

                    var _distance = Distance(currentStep.StartPoint, currentStep.EndPoint);

                    currentStep.Distance = Math.Round(_distance * 100000); // meter
                    currentStep.Duration = Math.Round(_distance * 100000 / 18); // second
                    //currentStep.Station = copyStations[_stationIndex];

                    steps.Add(currentStep);

                    routeStations.Add(new RouteStation
                    {
                        StationId = (int)currentStep.StationId,
                        Index = stepIndex,
                        Id = routeStationId++,
                        RouteId = routeIndex
                    });
                    //route.RouteStations.Add(new RouteStation
                    //{
                    //    Station = currentStep.Station,
                    //    StationId = currentStep.Station.Id,
                    //    Index = stepIndex,
                    //    Id = routeStationId++,
                    //    RouteId = routeIndex
                    //});

                    startPoint = nextPoint;
                    copyStations.RemoveAt(_stationIndex);
                }

                var distance = steps.Select(step => step.Distance).Aggregate((a, b) => a + b);
                var duration = steps.Select(step => step.Distance).Aggregate((a, b) => a + b);

                route.Id = routeIndex;
                route.Steps = steps;
                route.Distance = distance;
                route.Duration = duration;

                routes.Add(route);
            }

            return new Tuple<List<Domain.Entities.Route>, List<RouteStation>, List<Station>>(routes, routeStations, stations);
        }
    }
}
