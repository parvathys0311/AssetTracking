using Assgn2.AssetTracking.Data;
using Assgn2.AssetTracking.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assgn2.AssetTracking.BLL
{
    public class AssetTypeManager
    {
        public static List<AssetType> GetAllAssetType()
        {
            var context = new AssetContext();
            var assetTypes = context.AssetTypes.ToList();
            return assetTypes;
        }

        public static void addAssetType(AssetType type)
        {
            var context = new AssetContext();
            context.AssetTypes.Add(type);
            context.SaveChanges();
        }
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetContext();
            var types = context.AssetTypes.Select(t => new
            {
                Value = t.Id,
                Text = t.Name
            }).ToList();
            return types;
        }


    }
}
