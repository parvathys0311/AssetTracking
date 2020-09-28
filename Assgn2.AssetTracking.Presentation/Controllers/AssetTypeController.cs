using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assgn2.AssetTracking.BLL;
using Assgn2.AssetTracking.Domain;
using Assgn2.AssetTracking.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assgn2.AssetTracking.Presentation.Controllers
{
    public class AssetTypeController : Controller
    {
        public IActionResult Index()
        {
            var types = AssetTypeManager.GetAllAssetType();
            var viewModels = types.Select(t => new AssetTypeViewModel
            {
                Id = t.Id,
                Name = t.Name,
            }).ToList();
            return View(viewModels);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(AssetType type)
        {
            try
            {
                AssetTypeManager.addAssetType(type);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


    }
}
