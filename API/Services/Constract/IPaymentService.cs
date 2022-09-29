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
        Task<string> GenerateMomoPaymentUrl(int orderId, long amount, List<MomoItemRequestDTO>? items = null, MomoUserInfoDTO? userInfo = null);
        Task<string> GenerateMomoPaymentUrl(MomoCollectionLinkRequestDTO dto);
        string GetMomoSignature(string text);
    }
}
