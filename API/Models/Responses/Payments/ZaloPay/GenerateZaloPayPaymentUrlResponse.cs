﻿using static Domain.Shares.Enums.Payments;

namespace API.Models.Responses.Payments.ZaloPay
{
    public class GenerateZaloPayPaymentUrlResponse
    {
        public int return_code { get; set; }
        public string return_message { get; set; }
        public int sub_return_code { get; set; }
        public string sub_return_message { get; set; }
        public string order_url { get; set; }
        public string zp_trans_token { get; set; }
    }
}
