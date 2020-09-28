using Assgn2.AssetTracking.BLL;
using Assgn2.AssetTracking.Domain;
using Assgn2.AssetTracking.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assgn2.AssetTracking.Presentation.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;
            //OK, this is a "hack" because I want to test if id is 0 (select all)
            if (id == 0)
            {
                //return all assets if id is 0...
                assets = AssetManager.GetAllAsset();
            }
            else
            {
                //...otherwise we will use the id in the query
                assets = AssetManager.GetAllByAssetType(id);
            }

            //Now we can transform whatever asset collection we have to a collection of AssetViewModel objects to pass to the view
            var Assets = assets.
                Select(a => new AssetViewModel
                {
                    Id = a.Id,
                    TagNumber = a.TagNumber,
                    Description = a.Description,
                    SerialNumber = a.SerialNumber,
                    AssetType = a.AssetType.Name
                }).ToList();
            return View(Assets);
        }
    }
}
