﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallyConnector.Core.Models
{
    public class VoucherUserTypeInfo
    {
        public string VoucherId { get; set; }
        public string BillName { get; set; }
        public string BrokerName { get; set; }
        public decimal? Brokerage { get; set; }  
        public decimal? TotalBrokerCommission { get; set; }  
    }
}
