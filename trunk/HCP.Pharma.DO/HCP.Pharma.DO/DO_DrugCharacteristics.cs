using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.Pharma.DO
{
    public class DO_DrugCharacteristics
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public bool ActiveStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
