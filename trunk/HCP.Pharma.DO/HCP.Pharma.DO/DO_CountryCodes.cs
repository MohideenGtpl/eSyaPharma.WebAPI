﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.Pharma.DO
{
    public class DO_CountryCodes
    {
        public int Isdcode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
        public string CurrencyCode { get; set; }
        public string MobileNumberPattern { get; set; }
        public string Uidlabel { get; set; }
        public string Uidpattern { get; set; }
        public string Nationality { get; set; }
        public bool IsPoboxApplicable { get; set; }
        public string PoboxPattern { get; set; }
        public bool IsPinapplicable { get; set; }
        public string PincodePattern { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string CurrencyName { get; set; }
    }

    public class DO_StoreMaster
    {
        public string StoreType { get; set; }
        public int StoreCode { get; set; }
        public int CustodianStore { get; set; }
        public string StoreDesc { get; set; }
        public bool IsMaterial { get; set; }
        public bool IsPharmacy { get; set; }
        public bool IsStationary { get; set; }
        public bool IsCafeteria { get; set; }
        public bool IsFandB { get; set; }
        public bool IsCustodianStore { get; set; }
        public bool IsAccountingStore { get; set; }
        public bool IsConsumptionStore { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
