using System;
using System.Collections.Generic;

namespace HCP.Pharma.DL.Entities
{
    public partial class GtEpdrco
    {
        public int CompositionId { get; set; }
        public string CompositionDesc { get; set; }
        public int DrugForm { get; set; }
        public int Dosage { get; set; }
        public bool ActiveStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
