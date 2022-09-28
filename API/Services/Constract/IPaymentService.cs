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
        Task<Dictionary<string,string>> GenerateMomoPaymentUrl(int orderId, long amount, List<MomoItemRequestDTO> items, MomoUserInfoDTO userInfo);
    }
}
