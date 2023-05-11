using HCP.Pharma.DL.Repository;
using HCP.Pharma.DO;
using HCP.Pharma.IF;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCP.Pharma.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugFormulationController : ControllerBase
    {
        private readonly IDrugFormulationRepository _drugFormulationRepository;
        public DrugFormulationController(IDrugFormulationRepository DrugFormulationRepository)
        {
            _drugFormulationRepository = DrugFormulationRepository;
        }

        /// <summary>
        /// Getting  Drug Category List.
        /// UI Reffered - Drug Category Grid
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugFormulationListByNamePrefix(string drugFormulationPrefix)
        {
            var store_master = await _drugFormulationRepository.GetDrugFormulationListByNamePrefix(drugFormulationPrefix);
            return Ok(store_master);
        }

        /// <summary>
        /// Insert Or Update Drug Category.
        /// UI Reffered - Drug Category
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDrugFormulation(DO_DrugFormulation drugFormulation)
        {
            var msg = await _drugFormulationRepository.InsertOrUpdateDrugFormulation(drugFormulation);
            return Ok(msg);

        }

        /// <summary>
        /// Get Drug Formulation Details.
        /// UI Reffered - Drug Brand
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDrugFormulationDetails(int DrugFormulaId)
        {
            var drug_form = await _drugFormulationRepository.GetDrugFormulationDetails(DrugFormulaId);
            return Ok(drug_form);
        }
    }
}