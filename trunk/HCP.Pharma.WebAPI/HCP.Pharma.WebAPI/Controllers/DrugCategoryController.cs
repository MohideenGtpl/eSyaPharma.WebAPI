﻿using HCP.Pharma.DL.Repository;
using HCP.Pharma.DO;
using HCP.Pharma.IF;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCP.Pharma.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugCategoryController : ControllerBase
    {
        private readonly IDrugCategoryRepository _drugCategoryRepository;
        public DrugCategoryController(IDrugCategoryRepository DrugCategoryRepository)
        {
            _drugCategoryRepository = DrugCategoryRepository;
        }

        /// <summary>
        /// Getting  Drug Category List.
        /// UI Reffered - Drug Category Grid
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugCategoryListByNamePrefix(string drugCategoryPrefix)
        {
            var store_master = await _drugCategoryRepository.GetDrugCategoryListByNamePrefix(drugCategoryPrefix);
            return Ok(store_master);
        }

        /// <summary>
        /// Insert Or Update Drug Category.
        /// UI Reffered - Drug Category
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateDrugCategory(DO_DrugCategory drugCategory)
        {
            var msg = await _drugCategoryRepository.InsertOrUpdateDrugCategory(drugCategory);
            return Ok(msg);

        }

        [HttpGet]
        public async Task<IActionResult> GetDrugCategory()
        {
            var ds = await _drugCategoryRepository.GetDrugCategory();
            return Ok(ds);
        }
    }
}