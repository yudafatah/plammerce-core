using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("cartconfiguration")]
    public class CartConfiguration
    {
        [BsonId]
        public string Id { get; set; }
        //[Required]
        //public decimal ReferAndEarnAmount { get; set; }
        [Required]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ShippingCharges { get; set; }
        [Required]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ShippingDiscountAtAmount { get; set; }
        [Required]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ShippingDiscountPercentage { get; set; }
        [Required]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal VendorSaleCommission { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal AffiliateCommission { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal PrimiumCharges { get; set; }

        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        public string MobileNo { get; set; }

        [MaxLength(100)]
        [Display(Name = "DTDC Courier Username")]
        public string Username { get; set; }
        [MaxLength(100)]
        [Display(Name = "DTDC Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Browse Image (212x200)")]
        public string Logo { get; set; }
        public bool Status { get; set; }
    }

}
