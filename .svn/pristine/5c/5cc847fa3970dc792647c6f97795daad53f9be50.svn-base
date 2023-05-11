using Microsoft.EntityFrameworkCore;
using HCP.Pharma.DL.Entities;
using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HCP.Pharma.DL
{
    public class CommonMethod
    {
        public static string GetValidationMessageFromException(DbUpdateException ex)
        {
            string msg = ex.InnerException == null ? ex.ToString() : ex.InnerException.Message;

            if (msg.LastIndexOf(',') == msg.Length - 1)
                msg = msg.Remove(msg.LastIndexOf(','));
            return msg;
        }
    }
}
