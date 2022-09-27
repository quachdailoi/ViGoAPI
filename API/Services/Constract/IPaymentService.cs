using API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Constract
{
    public interface IPaymentService
    {
        Task<string> GeneratePaymentUrl(CollectionLinkRequestDTO request);
    }
}
