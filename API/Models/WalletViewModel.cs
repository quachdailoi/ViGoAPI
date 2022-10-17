using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class WalletViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public double Balance { get; set; }
        [JsonIgnore]
        public Wallets.Status Status { get; set; }
        public string StatusName { get; set; }
        public List<AffiliateAccountViewModel> AffiliateAccounts { get; set; }
        //public List<WalletTransactionViewModel> WalletTransactions { get; set; }
        //public int TotalPage { get; set; }
        //public int PageSize { get; set; }
        //public int Page { get; set; }
    }
}
