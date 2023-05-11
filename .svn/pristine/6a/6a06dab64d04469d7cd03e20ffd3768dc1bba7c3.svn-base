using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Pharma.IF
{
   public interface IDrugFormulationRepository
    {
        Task<List<DO_DrugFormulation>> GetDrugFormulationListByNamePrefix(string drugFormulationPrefix);

        Task<DO_ReturnParameter> InsertOrUpdateDrugFormulation(DO_DrugFormulation drugFormulation);

        Task<DO_DrugFormulation> GetDrugFormulationDetails(int DrugFormulaId);
    }
}
