using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Pharma.IF
{
   public interface IGenericRepository
    {
        #region Generic
        Task<List<DO_DrugCharacteristics>> GetDrugCharacteristicsByTypeList(List<string> l_type);
        Task<List<DO_Generic>> GetGenericByPrefix(string prefix);
        Task<DO_Generic> GetGenericByID(int GenericID);
        Task<DO_ReturnParameter> AddOrUpdateGeneric(DO_Generic obj);
        #endregion
        #region Composition
        Task<List<DO_Composition>> GetCompositionByPrefix(string prefix);
        Task<DO_Composition> GetCompositionByID(int CompositionID);
        Task<DO_ReturnParameter> AddOrUpdateComposition(DO_Composition obj);
        #endregion
        #region Generic/Composition Link
        Task<List<DO_GenericComposition>> GetGenericComposition(string prefix);
        Task<DO_GenericComposition> GetGenericCompositionByID(int GenericID, int CompositionID);
        Task<DO_ReturnParameter> AddOrUpdateGenericComposition(DO_GenericComposition obj);
        #endregion
    }
}
