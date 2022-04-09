using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("brand")]
    public class Brand
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int VendorId { get; set; } = 1;

        public int Status { get; set; }
    }

}
