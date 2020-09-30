using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assgn2.AssetTracking.BLL;
using Assgn2.AssetTracking.Domain;
using Assgn2.AssetTracking.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

/*
 * This is a web-based Asset Tracking Application
 * Author: Parvathy Sudhakaran
 * Date of Submission: September 2020
 */
namespace Assgn2.AssetTracking.Presentation.Controllers
{
    public class AssetsController : Controller
    {
        public IActionResult Index()
        {
            //call a local service to get the collection of rentals as the viewmodel
            var assets = AssetManager.GetAllAsset();
            var viewModels = assets.Select(a => new AssetViewModel
            {
                Description = a.Description,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber
            }).ToList();
            return View(viewModels);
        }

        public IActionResult Search()
        {
            //get all asset types
            var types = GetAssetTypes();
            ViewBag.AssetTypes = types;
            return View();
        }

        protected IEnumerable GetAssetTypes()
        {
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var names = new SelectList(types, "Value", "Text");

            var list = names.ToList();
            //add "all assets" to the list
            list.Insert(0, new SelectListItem
            {
                Text = "All Assets",
                Value = "0"
            });

            return list;
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        public IActionResult Create()
        {
            ViewBag.AssetTypeId = GetAssetTypes();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            try
            {
                AssetManager.addAsset(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
