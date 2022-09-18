using API.Extensions;
using API.Models.DTO;
using API.Models.Settings;
using API.Services.Constract;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class TrueWayMatrixApiService : ITrueWayMatrixApiService
    {
        private readonly string _baseAddress;
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public TrueWayMatrixApiService(IConfiguration configuration)
        {
            _client = new HttpClient();
            _config = configuration;
            _baseAddress = _config.Get(RapidApiSettings.TrueWayMatrixService_Uri);
        }

        public async Task<List<DistanceStationDTO>> CalculateDrivingMatrix(CoordinatesDTO origin, List<DistanceStationDTO> destinations)
        {
            var originsParam = $"{origin.Latitude},{origin.Longitude}";

            var destinationsParam = this.BuildCoordinateString(destinations);

            var url = $"/CalculateDrivingMatrix?origins={originsParam}&destinations={destinationsParam}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_baseAddress + url),
                Headers =
                {
                    { "X-RapidAPI-Key", _config.Get(RapidApiSettings.TrueWayMatrixService_ApiKey) },
                    { "X-RapidAPI-Host", _config.Get(RapidApiSettings.TrueWayMatrixService_ApiHost) },
                }
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                
                dynamic bodyJson = JToken.Parse(body);

                LoadRealDistanceAndTime(ref destinations, bodyJson.distances[0], bodyJson.durations[0]);

                destinations.Sort();
            }

            return destinations;
        }

        private static List<DistanceStationDTO> LoadRealDistanceAndTime(ref List<DistanceStationDTO> stations, dynamic? distances, dynamic? durations)
        {
            for (var index = 0; index < stations.Count; index++)
            {
                stations[index].Distance = (double) distances[index];
                stations[index].Time = (double) durations[index];
            }

            return stations;
        }

        private string BuildCoordinateString(List<DistanceStationDTO> list)
        {
            var coorStrs = new List<string>();

            foreach (var point in list)
            {
                coorStrs.Add($"{point.Station.Latitude},{point.Station.Longitude}");
            }

            return string.Join(";", coorStrs.ToArray());
        }
    }
}
