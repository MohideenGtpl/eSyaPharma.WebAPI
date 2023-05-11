using HCP.Pharma.DL.Repository;
using HCP.Pharma.DO;
using HCP.Pharma.IF;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCP.Pharma.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugManufacturerController : ControllerBase
    {
        private readonly IDrugManufacturerRepository _drugManufacturerRepository;
        public DrugManufacturerController(IDrugManufacturerRepository DrugManufacturerRepository)
        {
            _drugManufacturerRepository = DrugManufacturerRepository;
        }

        /// <summary>
        /// Getting  Manufacturers List.
        /// UI Reffered - Drug Manufacturer Grid
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetManufacturerListByNamePrefix(string manufacturerNamePrefix)
        {
            var store_master = await _drugManufacturerRepository.GetManufacturerListByNamePrefix(manufacturerNamePrefix);
            return Ok(store_master);
        }

        /// <summary>
        /// Insert Or Update Manufacturers.
        /// UI Reffered - Drug Manufacturer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateManufacturer(DO_DrugManufacturer drugManufacturer)
        {
            var msg = await _drugManufacturerRepository.InsertOrUpdateManufacturer(drugManufacturer);
            return Ok(msg);

        }
    }
}