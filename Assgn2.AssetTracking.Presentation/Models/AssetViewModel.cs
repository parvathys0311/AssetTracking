using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assgn2.AssetTracking.Presentation.Models
{
    public class AssetViewModel
    {
        public int Id { get; set; }
        public string TagNumber { get; set; }
        public string Description { get; set; }
        public String SerialNumber { get; set; }

        [Display(Name = "Asset Type")]
        public string AssetType { get; set; }
        
    }
}
