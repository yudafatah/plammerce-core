using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities.Product
{
    //[Table("brand")]
    public class ProductFeature
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Feature Name")]
        public string Name { get; set; }

        public int VendorId { get; set; } = 1;

        public int Status { get; set; }

        [NotMapped]
        [BsonIgnore]
        public string ProductName { get; set; }

        public List<ProductSize> ProductSize { get; set; }
    }

}
