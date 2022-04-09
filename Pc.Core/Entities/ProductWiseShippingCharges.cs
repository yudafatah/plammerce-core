using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities.Product
{
    //[Table("slider")]
    public class ProductWiseShippingCharges
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        public int ShippingCharges { get; set; }

    }

}
