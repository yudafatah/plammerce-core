using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities.Product
{
    //[Table("brand")]
    public class ProductSize
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int ProductFeatureId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Size Name")]
        public string Name { get; set; }

        public int VendorId { get; set; } = 1;

        public int Status { get; set; }

        [NotMapped]
        [BsonIgnore]
        public string ProductName { get; set; }
        [NotMapped]
        [BsonIgnore]
        public string ProductFeatureName { get; set; }
    }

}
