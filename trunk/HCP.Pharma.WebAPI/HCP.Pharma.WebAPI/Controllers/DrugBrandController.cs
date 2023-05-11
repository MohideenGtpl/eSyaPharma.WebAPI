using HCP.Pharma.DL.Repository;
using HCP.Pharma.DO;
using HCP.Pharma.IF;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HCP.Pharma.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugBrandController : ControllerBase
    {
        private readonly IDrugBrandRepository _drugBrandRepository;
        public DrugBrandController(IDrugBrandRepository DrugBrandRepository)
        {
            _drugBrandRepository = DrugBrandRepository;
        }

        /// <summary>
        /// Getting  Drug Category List.
        /// UI Reffered - Drug Category Grid
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandListByNamePrefix(int ISDCode, int drugFormulaId, string drugBrandPrefix)
        {
            var store_master = await _drugBrandRepository.GetDrugBrandListByNamePrefix(ISDCode, drugFormulaId, drugBrandPrefix);
            return Ok(store_master);
        }

        /// <summary>
        /// Getting  Drug Parameter List.
        /// UI Reffered - Drug Brans
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugParameterList(int drugCode)
        {
            var sp_Param = await _drugBrandRepository.GetDrugParameterList(drugCode);
            return Ok(sp_Param);
        }

        /// <summary>
        /// Is Drug Volumn Required
        /// UI Reffered - Drug Volumn
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> IsDrugVolumeRequired(int packingID)
        {
            var sp_Param = await _drugBrandRepository.IsDrugVolumeRequired(packingID);
            return Ok(sp_Param);
        }

        /// <summary>
        /// Insert Or Update Drug Brand.
        /// UI Reffered - Drug Brand
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDrugBrand(DO_DrugBrand drugBrand)
        {
            var msg = await _drugBrandRepository.InsertOrUpdateDrugBrand(drugBrand);
            return Ok(msg);

        }

        /// <summary>
        /// Getting  Drug Business Link List.
        /// UI Reffered - Drug Business Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetGenericDrugList(int businessKey)
        {
            var sp_Param = await _drugBrandRepository.GetGenericDrugList(businessKey);
            return Ok(sp_Param);
        }

        /// <summary>
        /// Insert / Update into Drug Business Link
        /// UI Reffered - Drug Business Link
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertUpdateDrugBusinessLink(List<DO_DrugBusinessLink> obj)
        {
            var msg = await _drugBrandRepository.InsertUpdateDrugBusinessLink(obj);
            return Ok(msg);
        }

        #region Drug Reorder Level
        /// <summary>
        /// Getting  Item Reorder Level By Business Key & Store Code.
        /// UI Reffered - Item Reorder Level
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugReorderLevel(int BusinessKey, int StoreCode)
        {
            var i_Codes = await _drugBrandRepository.GetDrugReorderLevel(BusinessKey, StoreCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Item Reorder Level.
        /// UI Reffered - Item Reorder Level
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDrugReorderLevel(List<DO_DrugReorderLevel> sd)
        {
            var msg = await _drugBrandRepository.InsertOrUpdateDrugReorderLevel(sd);
            return Ok(msg);
        }
        #endregion Item Reorder Level

        #region Drug Bin Info
        /// <summary>
        /// Getting  Drug Bin Info By Business Key & Store Code.
        /// UI Reffered - Item Reorder Level
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBinInfo(int BusinessKey, int StoreCode)
        {
            var i_Codes = await _drugBrandRepository.GetDrugBinInfoList(BusinessKey, StoreCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Drug Bin Info
        /// UI Reffered - Drug Bin Info
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDrugBinInfo(List<DO_DrugBinInfo> sd)
        {
            var msg = await _drugBrandRepository.InsertOrUpdateDrugBinInfo(sd);
            return Ok(msg);
        }
        #endregion Item Bin Info

        #region Vendor Drug Link
        /// <summary>
        /// Getting Drug List by Vendor Name.
        /// UI Reffered - Vendor Drug Link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugVendorLink(int VendorCode)
        {
            var i_Codes = await _drugBrandRepository.GetDrugVendorLink(VendorCode);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Vendor Drug Link.
        /// UI Reffered - Vendor Drug Link
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateVendorDrugLink(DO_DrugVendorLink dvl)
        {
            var msg = await _drugBrandRepository.InsertOrUpdateVendorDrugLink(dvl);
            return Ok(msg);
        }
        #endregion Vendor Drug Link
    }
}