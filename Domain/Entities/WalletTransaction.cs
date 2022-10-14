﻿using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WalletTransaction : BaseEntity
    {
        public double Amount { get; set; }
        public string TxnId { get; set; }
        public WalletTransactions.Types Type { get; set; }
        public WalletTransactions.Status Status { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
