﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.Pharma.DO
{
   public class DO_BusinessLocation
    {
        public int BusinessId { get; set; }
        public int SegmentId { get; set; }
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string LocationDescription { get; set; }
        public string BusinessName { get; set; }
        public int BusinessKey { get; set; }
        public bool ActiveStatus { get; set; }
        public int UserID { get; set; }
        public string FormID { get; set; }
        public string TerminalID { get; set; }
        
    }
}
