using Assgn2.AssetTracking.Data;
using Assgn2.AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assgn2.AssetTracking.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAllAsset()
        {
            var context = new AssetContext();
            var assets = context.Assets.Include(a => a.AssetType).ToList();
            return assets;
        }

        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetContext();
            var assets = context.Assets.Where(a => a.AssetTypeId == id).Include(t => t.AssetType).ToList();
            return assets;
        }

        public static void addAsset(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
    }
}
