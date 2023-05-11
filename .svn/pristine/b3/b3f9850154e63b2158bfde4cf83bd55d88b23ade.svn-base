using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Pharma.IF
{
   public interface IDrugManufacturerRepository
    {
        Task<List<DO_DrugManufacturer>> GetManufacturerListByNamePrefix(string manufacturerNamePrefix);

        Task<DO_ReturnParameter> InsertOrUpdateManufacturer(DO_DrugManufacturer drugManufacturer);
    }
}
