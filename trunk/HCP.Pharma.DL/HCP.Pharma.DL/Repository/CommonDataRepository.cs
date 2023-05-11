using Microsoft.EntityFrameworkCore;
using HCP.Pharma.DL.Entities;
using HCP.Pharma.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCP.Pharma.IF;

namespace HCP.Pharma.DL.Repository
{
    public class CommonDataRepository : ICommonDataRepository
    {
        private eSyaEnterprise _context { get; set; }
        public CommonDataRepository(eSyaEnterprise context)
        {
            _context = context;
        }
        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType)
        {
            try
            {
                    var ds = _context.GtEcapcd
                        .Where(w => w.CodeType == codeType && w.ActiveStatus)
                        .Select(r => new DO_ApplicationCodes
                        {
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeTypeList(List<int> l_codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcd
                        .Where(w => w.ActiveStatus
                        && l_codeType.Contains(w.CodeType))
                        .Select(r => new DO_ApplicationCodes
                        {
                            CodeType = r.CodeType,
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_BusinessLocation>> GetBusinessKey()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEcbsln
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            LocationDescription = r.BusinessName + "-" + r.LocationDescription
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_CountryCodes>> GetISDCodes()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEccncd
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_CountryCodes
                        {
                            Isdcode = r.Isdcode,
                            CountryName = r.CountryName
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_DrugCategory> GetGenericDetails(int drugCategory)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var result =  db.GtEpdrgn
                        .Where(w => w.GenericId == drugCategory && w.ActiveStatus)
                        //.GroupJoin(db.GtEcapcd,
                        // r => r.DrugClassId,
                        // y => y.ApplicationCode,
                        //(r, y) => new { r, y = y.FirstOrDefault() })
                        .Select(w => new DO_DrugCategory
                        {
                            //DrugClassId = w.DrugClassId,
                            //DrugClassDesc = w.y.CodeDesc
                        }).FirstOrDefaultAsync();
                    return await result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugFormulation>> GetDrugFormulationList(int DrugGenerics)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEpdrfr
                        .Where(w => w.GenericId == DrugGenerics && w.ActiveStatus)
                        .Select(r => new DO_DrugFormulation
                        {
                            DrugFormulaID = r.DrugFormulaId,
                            DrugFormulation = r.DrugFormulation
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugManufacturer>> GetManufacturerList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEpdrmf
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_DrugManufacturer
                        {
                            ManufacturerID = r.ManufacturerId,
                            ManufacturerName = r.ManufacturerName
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_StoreMaster>> GetStoreListByBusinessKey(int BusinessKey,int formId)
        {
            try
            {
                using (eSyaEnterprise db = new eSyaEnterprise())
                {
                    //var result = db.GtEastbl.Where(x => x.BusinessKey == BusinessKey && x.ActiveStatus == true)
                    //    .GroupJoin(db.GtEcstrm,
                    //     x => x.StoreCode,
                    //     y => y.StoreCode,
                    //    //(x, y) => new { x, y = y.FirstOrDefault() }).DefaultIfEmpty()
                    //    .Select(r => new DO_StoreMaster
                    //    {
                    //        StoreCode = r.x.StoreCode,
                    //        StoreDesc = r.y.StoreDesc,
                    //    }).ToListAsync();

                    //return await result;
                    var result =  db.GtEastbl.Where(k => k.BusinessKey == BusinessKey && k.ActiveStatus)
                        .Join(db.GtEcstrm.Where(l=>l.ActiveStatus),
                        x => x.StoreCode,
                        y => y.StoreCode,
                        (x, y) => new { x, y })
                        .Join(db.GtEcfmst.Where(w => w.FormId == formId),
                        a => a.x.StoreCode,
                        p => p.StoreCode, (a, p) => new { a, p })
                        .Select(r => new DO_StoreMaster
                        {
                            StoreCode = r.a.x.StoreCode,
                            StoreDesc = r.a.y.StoreDesc
                            
                        }).ToList();
                    var DistinctKeys = result.GroupBy(x => x.StoreCode).Select(y => y.First());
                    return  DistinctKeys.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugVendorLink>> GetVendorList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEavncd
                        .Where(w =>  w.ActiveStatus)
                        .Select(r => new DO_DrugVendorLink
                        {
                            VendorCode = r.VendorCode,
                            VendorName = r.VendorName
                        }).OrderBy(o => o.VendorName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DrugBrand>> GetDrugList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEpdrcd
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_DrugBrand
                        {
                            DrugCode = r.DrugCode,
                            DrugBrand = r.DrugBrand
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
