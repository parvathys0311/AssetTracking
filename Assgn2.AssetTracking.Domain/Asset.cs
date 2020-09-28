using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Assgn2.AssetTracking.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public String SerialNumber { get; set; }

        //navigation properties
        public AssetType AssetType { get; set; }



    }
}
