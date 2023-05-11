using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Pharma.IF
{
    public interface ICommonDataRepository
    {
        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType);

        Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeTypeList(List<int> l_codeType);

        Task<List<DO_BusinessLocation>> GetBusinessKey();

        Task<List<DO_CountryCodes>> GetISDCodes();

        Task<DO_DrugCategory> GetGenericDetails(int drugCategory);

        Task<List<DO_DrugFormulation>> GetDrugFormulationList(int DrugGenerics);

        Task<List<DO_DrugManufacturer>> GetManufacturerList();

        Task<List<DO_StoreMaster>> GetStoreListByBusinessKey(int BusinessKey, int formId);

        Task<List<DO_DrugVendorLink>> GetVendorList();

        Task<List<DO_DrugBrand>> GetDrugList();
    }
}
