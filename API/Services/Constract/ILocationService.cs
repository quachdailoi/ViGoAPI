namespace API.Services.Constract
{
    public interface ILocationService
    {
        public static double CalculateDistanceAsTheCrowFlies(double lat1, double long1, double lat2, double long2)
        {
            var phi1 = lat1 * Math.PI / 180;
            var phi2 = lat2 * Math.PI / 180;

            var delta_phi = (lat2 - lat1) * Math.PI / 180;
            var delta_lambda = (long2 - long1) * Math.PI / 180;

            var a = Math.Sin(delta_phi / 2) * Math.Sin(delta_phi / 2) +
                Math.Cos(phi1) * Math.Cos(phi2) * Math.Sin(delta_lambda / 2) * Math.Sin(delta_lambda / 2);

            double R = 6371e3; // earthRadius

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = R * c;

            return distance;
        }
    }
}
