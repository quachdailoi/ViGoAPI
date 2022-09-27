using API.Models.DTO;
using API.Services.Constract;

namespace API.Services
{
    public class PaymentService : IPaymentService
    {
        private HttpClient _client;
        public PaymentService()
        {
            _client = new HttpClient();
        }
        public async Task<string> GeneratePaymentUrl(CollectionLinkRequestDTO request)
        {
            return String.Empty;
        }
    }
}
