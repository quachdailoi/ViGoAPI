using API.Models.DTO;
using Domain.Entities;
using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace API.Helpers
{
    public class Mapping
    {
        //public const int MAXIMUM_WAITING_TIME = 60 * 8; 
        //public static List<List<BookingDTO>> GetSharingMapping(List<BookingDTO> bookings, int k)
        //{
        //    //sort by pick-up time
        //    bookings = bookings.OrderBy(booking => booking.Time).ToList();
        //    List<Tuple<Bound, List<BookingDTO>, List<Step>>> sharingBookings = new(bookings.Count());
        //    for(var i = 1; i < bookings.Count()-1; i++)
        //    {
        //        var booking = bookings[i];
        //        var sharingBooking = sharingBookings[i];

        //        for (var j = 1; j < i-1; j++)
        //        {
        //            //remove the passengers who arrive destinations from sharingBookings[j]
        //            var _sharingBooking = sharingBookings[j];

        //            RemoveArrivePassengers(booking.Time, sharingBookings[j].Item2);
                    
        //            // if trip is full, continue
        //            if(_sharingBooking.Item2.Count() == k)
        //            {
        //                continue;
        //            }

        //            // if next booking is satisfied current trip condition, add passenser to trip

        //            if(IsSatisfiedConditions(_sharingBooking, booking))
        //            {
        //                sharingBookings[j].Item2.Add(booking);

        //                var bound = CombineBounds(sharingBookings[j].Item1,booking.Bound);

        //                var steps = sharingBookings[j].Item3;
        //                // combine steps

        //            }

        //            // if f[j] is empty, append passenger[j]
        //            if (!_sharingBooking.Item2.Any())
        //            {
        //                sharingBookings[j] = new Tuple<Bound, List<BookingDTO>, List<Step>>
        //                (
        //                    bookings[j].Bound,
        //                    new List<BookingDTO> { bookings[j]},
        //                    bookings[j].Steps
        //                );
        //            }
        //        }
        //    }

        //    return null;
        //}

        //private static bool IsSatisfiedConditions(Tuple<Bound, List<BookingDTO>, List<Step>> trip, BookingDTO booking)
        //{
        //    var bound = trip.Item1;
        //    var sharingBookings = trip.Item2;
        //    var steps = trip.Item3;

        //    var isStartPointBelongToBound = Math.Abs(bound.East - bound.West) >= Math.Abs(bound.East - booking.StartPoint.Latitude) &&
        //                          Math.Abs(bound.North - bound.South) >= Math.Abs(bound.North - booking.StartPoint.Longitude);

        //    if(!isStartPointBelongToBound)
        //    {
        //        return false;
        //    }

        //    //Step containStep = null;
        //    //var containBookingInTrip = new BookingDTO();

        //    //var containBookingInTrip
        //    //    = sharingBookings.Where(bookingInTrip =>
        //    //    {
        //    //        containStep = bookingInTrip.Steps.Where(step =>
        //    //                        IsBetweenPoint(step.StartPoint, step.EndPoint, booking.StartPoint)).FirstOrDefault();
        //    //        return containStep != null;
        //    //    }).FirstOrDefault();

        //    var containStep = steps.Select((step,index) => new {step, index}).Where(item => IsBetweenPoint(item.step.StartPoint, item.step.EndPoint, booking.StartPoint)).FirstOrDefault();
        //    var lastSharingBookingStartStep = steps.Select((step,index) => new {step, index}).Where(item => item.step.Equals(sharingBookings[sharingBookings.Count -1])).FirstOrDefault();

        //    if(containStep == null || lastSharingBookingStartStep.index > containStep.index)
        //    {
        //        return false;
        //    }

        //    //var isEndPointBelongToBound = Math.Abs(bound.East - bound.West) >= Math.Abs(bound.East - booking.EndPoint.Latitude) &&
        //    //          Math.Abs(bound.North - bound.South) >= Math.Abs(bound.North - booking.EndPoint.Longitude);


        //    var isSatisfiedEndPoint = booking.Steps.ToHashSet().IsSubsetOf(steps) || 
        //        booking.Steps.TakeLast(steps.Count - 1).ToHashSet().IsSupersetOf(steps.TakeLast(steps.Count - containStep.index));

        //    if (!isSatisfiedEndPoint)
        //    {
        //        return false;
        //    }

        //    var arriveStartPointTime = sharingBookings[sharingBookings.Count - 1].Time;
        //    var rangeStep = steps.GetRange(lastSharingBookingStartStep.index, containStep.index - lastSharingBookingStartStep.index + 1);
        //    for(var index = 0; index <= rangeStep.Count; index++)
        //    {
        //        if(index == rangeStep.Count - 1)
        //        {
        //            arriveStartPointTime.AddMinutes((rangeStep[index].Duration - booking.Steps[0].Duration) / 60);
        //        }
        //        arriveStartPointTime.AddMinutes(rangeStep[index].Duration / 60);
        //    }
        //    return Math.Abs(arriveStartPointTime.ToTimeSpan().Subtract(booking.Time.ToTimeSpan()).TotalSeconds) <= MAXIMUM_WAITING_TIME; 
        //} 

        //private static bool IsBetweenPoint(Location startPoint, Location endPoint, Location point)
        //{
        //    return (endPoint.Longitude - startPoint.Longitude) / (endPoint.Latitude - startPoint.Latitude) ==
        //           (endPoint.Longitude - point.Longitude) / (endPoint.Latitude - point.Latitude) &&
        //           (Math.Abs(endPoint.Longitude - startPoint.Longitude) >= Math.Abs(endPoint.Longitude - point.Longitude));
        //}

        //private static Bound CombineBounds(Bound bound1, Bound bound2)
        //{
        //    var bound = new Bound();
        //    bound.North = bound1.North >= bound2.North ? bound1.North : bound2.North;
        //    bound.South = bound1.South <= bound2.South ? bound1.South : bound2.South;
        //    bound.East = bound1.East >= bound2.East ? bound1.East : bound2.East;
        //    bound.West = bound1.West <= bound2.West ? bound1.West : bound2.West;

        //    return bound;
        //}
        //private static void RemoveArrivePassengers(TimeOnly pickUpTime, in List<BookingDTO> bookings)
        //{
        //    if (bookings.Any())
        //    {
        //        for(var index = 0; index < bookings.Count; index++)
        //        {
        //            if (bookings[index].EndTime.CompareTo(pickUpTime) < 0)
        //            {
        //                bookings.RemoveAt(index);
        //                index--;
        //            }
        //        }
        //    }
        //}


        public static Graph<Station> InitialGraph(List<RouteStation> routeStations)
        {
            var routeStationInGroups = 
                routeStations
                .GroupBy(routeStation => routeStation.RouteId)
                .Where(group => group.Key > 1 || group.ElementAt(0).Index == 0 || group.ElementAt(0).Index == -1)
                .ToList();

            var graph = new Graph<Station>();

            routeStationInGroups.ForEach(_routeStations =>
            {
                Station prevStation = null;

                double prevDistance = 0;

                foreach(var routeStation in _routeStations.OrderBy(_routeStation => _routeStation.Index))
                {
                    var station = routeStation.Station;
                    graph.Add(station);
                    if(prevStation != null)
                    {
                        graph.AddEdge(prevStation, station, routeStation.DistanceFromFirstStationInRoute - prevDistance, true, routeStation.RouteId);
                    }
                    else
                    {
                        prevDistance = routeStation.DistanceFromFirstStationInRoute;
                    }

                    prevStation = station;
                }
            });

            return graph;
        }
    }
}
