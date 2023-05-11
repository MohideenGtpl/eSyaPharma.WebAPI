using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Pharma.IF
{
   public interface IDrugCategoryRepository
    {
        Task<List<DO_DrugCategory>> GetDrugCategoryListByNamePrefix(string drugCategoryPrefix);

        Task<DO_ReturnParameter> InsertOrUpdateDrugCategory(DO_DrugCategory drugCategory);

        Task<List<DO_DrugCategory>> GetDrugCategory();

    }
}
