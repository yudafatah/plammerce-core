using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("orderdetail")]
    public class OrderDetail
    {
        [BsonId]
        public string Id { get; set; }
        [MaxLength(150)]
        public string UserId { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public string Feature { get; set; }
        public int Qty { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Amount { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        public int? AffiliateVendorId { get; set; }

        [Required]
        [Display(Name = "Order")]
        public int OrderId { get; set; }
    }

}
