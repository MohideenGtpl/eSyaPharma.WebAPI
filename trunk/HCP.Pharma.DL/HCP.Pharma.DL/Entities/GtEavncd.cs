﻿using System;
using System.Collections.Generic;

namespace HCP.Pharma.DL.Entities
{
    public partial class GtEavncd
    {
        public int VendorCode { get; set; }
        public string VendorName { get; set; }
        public string CreditType { get; set; }
        public decimal CreditPeriod { get; set; }
        public string PreferredPaymentMode { get; set; }
        public bool ApprovalStatus { get; set; }
        public bool IsBlackListed { get; set; }
        public string ReasonForBlacklist { get; set; }
        public int SupplierScore { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
