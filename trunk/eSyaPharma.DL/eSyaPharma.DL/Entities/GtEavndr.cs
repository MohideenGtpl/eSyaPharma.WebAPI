﻿using System;
using System.Collections.Generic;

namespace HCP.Pharma.DL.Entities
{
    public partial class GtEavndr
    {
        public int VendorCode { get; set; }
        public int DrugCode { get; set; }
        public decimal BusinessShare { get; set; }
        public decimal MinimumSupplyQty { get; set; }
        public string RateType { get; set; }
        public decimal Rate { get; set; }
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
