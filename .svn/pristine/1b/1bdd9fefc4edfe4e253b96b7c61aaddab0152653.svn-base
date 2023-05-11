using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Pharma.IF
{
   public interface IDrugBrandRepository
    {
        Task<List<DO_DrugBrand>> GetDrugBrandListByNamePrefix(int ISDCode, int drugFormulaId, string drugBrandPrefix);

        Task<DO_DrugBrand> GetDrugParameterList(int drugCode);

        Task<bool> IsDrugVolumeRequired(int packingID);

        Task<DO_ReturnParameter> InsertOrUpdateDrugBrand(DO_DrugBrand drugBrand);

        Task<List<DO_DrugBusinessLink>> GetGenericDrugList(int businessKey);

        Task<DO_ReturnParameter> InsertUpdateDrugBusinessLink(List<DO_DrugBusinessLink> drugBusinessLink);

        Task<List<DO_DrugReorderLevel>> GetDrugReorderLevel(int BusinessKey, int StoreCode);

        Task<DO_ReturnParameter> InsertOrUpdateDrugReorderLevel(List<DO_DrugReorderLevel> sd);

        Task<List<DO_DrugBinInfo>> GetDrugBinInfoList(int BusinessKey, int StoreCode);

        Task<DO_ReturnParameter> InsertOrUpdateDrugBinInfo(List<DO_DrugBinInfo> sd);

        Task<List<DO_DrugVendorLink>> GetDrugVendorLink(int VendorCode);

        Task<DO_ReturnParameter> InsertOrUpdateVendorDrugLink(DO_DrugVendorLink dvl);
    }
}
