﻿using System;
using System.Collections.Generic;

namespace HCP.Pharma.DL.Entities
{
    public partial class GtEcbsen
    {
        public GtEcbsen()
        {
            GtEcbssg = new HashSet<GtEcbssg>();
        }

        public int BusinessId { get; set; }
        public string BusinessDesc { get; set; }
        public bool IsMultiSegmentApplicable { get; set; }
        public string BusinessUnitType { get; set; }
        public int NoOfUnits { get; set; }
        public int ActiveNoOfUnits { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual ICollection<GtEcbssg> GtEcbssg { get; set; }
    }
}
