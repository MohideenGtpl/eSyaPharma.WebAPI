﻿using System;
using System.Collections.Generic;

namespace HCP.Pharma.DL.Entities
{
    public partial class GtEpdrgn
    {
        public GtEpdrgn()
        {
            GtEpdrfr = new HashSet<GtEpdrfr>();
        }

        public int GenericId { get; set; }
        public bool IsCombiDrug { get; set; }
        public string GenericDesc { get; set; }
        public int DrugClassId { get; set; }
        public int PharmacyGroup { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual ICollection<GtEpdrfr> GtEpdrfr { get; set; }
    }
}
