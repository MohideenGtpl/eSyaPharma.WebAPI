using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCP.Pharma.DL;
using HCP.Pharma.DL.Entities;
using HCP.Pharma.DO;
using HCP.Pharma.DL.Repository;
using HCP.Pharma.IF;
using Microsoft.EntityFrameworkCore;

namespace HCP.Pharma.DL.Repository
{
    public class DrugCategoryRepository : IDrugCategoryRepository
    {
        public async Task<List<DO_DrugCategory>> GetDrugCategoryListByNamePrefix(string drugCategoryPrefix)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var result = await db.GtEpdrgn
                        .Where(w => w.GenericDesc.StartsWith(drugCategoryPrefix != "All" ? drugCategoryPrefix : ""))
                        .Join(db.GtEcapcd,
                        t => new { ApplicationCode = t.DrugClassId },
                        b => new { b.ApplicationCode },
                        (t, b) => new { t, b })
                         .Join(db.GtEcapcd,
                        tb => new { ApplicationCode = tb.t.PharmacyGroup },
                        d => new { d.ApplicationCode },
                        (tb, d) => new { tb, d })
                         
                        .Select(a => new DO_DrugCategory
                        {
                            GenericId = a.tb.t.GenericId,
                            GenericDesc = a.tb.t.GenericDesc,
                            IsCombiDrug = a.tb.t.IsCombiDrug,
                            DrugClassId = a.tb.t.DrugClassId,
                            DrugClassDesc = a.tb.b.CodeDesc,
                            PharmacyGroup = a.tb.t.PharmacyGroup,
                            PharmacyGroupDesc = a.d.CodeDesc,
                            UsageStatus = a.tb.t.UsageStatus,
                            ActiveStatus = a.tb.t.ActiveStatus
                        }).ToListAsync();
                    return result;

                    //var result = await db.GtEpdrgn
                    //    .Where(w => w.GenericDesc.StartsWith(drugCategoryPrefix != "All" ? drugCategoryPrefix : ""))
                    //    .Join(db.GtEcapcd,
                    //     r => r.DrugClassId,
                    //     y => y.ApplicationCode,
                    //    (r, y) => new DO_DrugCategory
                    //    {
                    //        GenericId = r.GenericId,
                    //        GenericDesc = r.GenericDesc,
                    //        IsCombiDrug = r.IsCombiDrug,
                    //        DrugClassId = r.DrugClassId,
                    //        DrugClassDesc = y.CodeDesc,
                    //        PharmacyGroup = r.PharmacyGroup,
                    //        PharmacyGroupDesc = "Medicine",
                    //        UsageStatus = r.UsageStatus,
                    //        ActiveStatus = r.ActiveStatus
                    //    }).ToListAsync();

                    //foreach (var obj in result)
                    //{
                    //    GtEcapcd pgcodeDesc = db.GtEcapcd.Where(x => x.ApplicationCode == obj.PharmacyGroup).FirstOrDefault();
                    //    if (pgcodeDesc != null)
                    //    {
                    //        obj.PharmacyGroupDesc = pgcodeDesc.CodeDesc;
                    //    }
                    //}

                    //return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateDrugCategory(DO_DrugCategory drugCategory)
        {
            try
            {
                if (drugCategory.GenericId != 0)
                {
                    return await UpdateDrugCategory(drugCategory);
                }
                else
                {
                    return await InsertDrugCategory(drugCategory);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DO_ReturnParameter> InsertDrugCategory(DO_DrugCategory drugCategory)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEpdrgn isManufacturerExists = db.GtEpdrgn.FirstOrDefault(c => c.GenericDesc.ToUpper().Replace(" ", "") == drugCategory.GenericDesc.ToUpper().Replace(" ", ""));

                        if (isManufacturerExists == null)
                        {
                            int genId = db.GtEpdrgn.Select(c => c.GenericId).DefaultIfEmpty().Max();
                            genId = genId + 1;
                            var Epdrgn = new GtEpdrgn
                            {
                                GenericId = genId,
                                DrugClassId = drugCategory.DrugClassId,
                                GenericDesc = drugCategory.GenericDesc,
                                IsCombiDrug = drugCategory.IsCombiDrug,
                                PharmacyGroup = drugCategory.PharmacyGroup,
                                UsageStatus = false,
                                ActiveStatus = drugCategory.ActiveStatus,
                                CreatedBy = drugCategory.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = drugCategory.TerminalID
                            };
                            db.GtEpdrgn.Add(Epdrgn);

                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Generics created Successfully." };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Generics is already in use." };
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateDrugCategory(DO_DrugCategory drugCategory)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEpdrgn ismnfcExists = db.GtEpdrgn.FirstOrDefault(c => c.GenericId != drugCategory.GenericId && c.GenericDesc.ToUpper().Replace(" ", "") == drugCategory.GenericDesc.ToUpper().Replace(" ", ""));
                        if (ismnfcExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Generics is already exist." };
                        }

                        GtEpdrgn dc_Id = db.GtEpdrgn.Where(s => s.GenericId == drugCategory.GenericId).FirstOrDefault();
                        if (dc_Id == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Generics Code does not exist" };
                        }

                        dc_Id.GenericDesc = drugCategory.GenericDesc;
                        dc_Id.DrugClassId = drugCategory.DrugClassId;
                        dc_Id.IsCombiDrug = drugCategory.IsCombiDrug;
                        dc_Id.PharmacyGroup = drugCategory.PharmacyGroup;
                        dc_Id.ActiveStatus = drugCategory.ActiveStatus;
                        dc_Id.ModifiedBy = drugCategory.UserID;
                        dc_Id.ModifiedOn = DateTime.Now;
                        dc_Id.ModifiedTerminal = drugCategory.TerminalID;
                        
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, Message = "Generics Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_DrugCategory>> GetDrugCategory()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEpdrgn
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_DrugCategory
                        {
                            GenericId = r.GenericId,
                            GenericDesc = r.GenericDesc
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
