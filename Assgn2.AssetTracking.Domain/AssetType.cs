using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assgn2.AssetTracking.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //navigation property
        public ICollection<Asset> Assets { get; set; }
    }
}
