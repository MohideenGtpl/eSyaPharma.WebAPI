using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.Pharma.DO
{
    public class DO_Generic
    {
        public int GenericId { get; set; }
        public string GenericDesc { get; set; }
        public bool IsCombiDrug { get; set; }
        public int TheraupaticClass { get; set; }
        public int PharmacyGroup { get; set; }
        public int UsedinTreatOf { get; set; }
        public int NoOfManufacturers { get; set; }
        public int NoOfComposition { get; set; }
        public int NoOfBrands { get; set; }
        public int NoOfVendors { get; set; }
        public bool UsageStatus { get; set; }
        public int? DrugClassId { get; set; }
        public bool ActiveStatus { get; set; }

        public string StrTheraupaticClass { get; set; }
        public string StrPharmacyGroup { get; set; }
        public string StrUsedinTreatOf { get; set; }
        public string StrDrugClass { get; set; }

        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string TerminalID { get; set; }

    }
}
