using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("coupon")]
    public class Coupon
    {

        [BsonId]
        public string Id { get; set; }

        public int VendorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CouponName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CouponCode { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Discount { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }

        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }

        public bool Status { get; set; }
    }

}
