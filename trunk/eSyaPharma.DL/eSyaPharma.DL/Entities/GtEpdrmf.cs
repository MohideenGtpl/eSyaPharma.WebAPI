using System;
using System.Collections.Generic;

namespace HCP.Pharma.DL.Entities
{
    public partial class GtEpdrmf
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManfShortName { get; set; }
        public string OriginCode { get; set; }
        public string MarketedBy { get; set; }
        public int Isdcode { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
