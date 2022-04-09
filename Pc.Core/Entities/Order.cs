using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities
{
    //[Table("order")]
    public class Order
    {
        [BsonId]
        public string Id { get; set; }
        [MaxLength(150)]
        public string UserId { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        public int? CouponId { get; set; }
        [MaxLength(100)]
        public string CouponCode { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal SubTotal { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal CouponDiscount { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ShippingCharges { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal WalletDiscount { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalAmount { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public string PaymentMode { get; set; }

        [MaxLength(100)]
        public string TxnId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(45)]
        public string PhoneNumber { get; set; }
        [MaxLength(150)]
        public string EmailId { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(150)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(15)]
        public string PinCode { get; set; }
        [MaxLength(50)]
        public string TrackNo { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<TrackOrder> TrackOrders { get; set; }

        [NotMapped]
        [BsonIgnore]
        public string CreatedDateUtc
        {
            get
            {
                return CreatedDate.ToString("MMMM dd, yyyy");
            }
        }


        [NotMapped]
        [BsonIgnore]
        public string OrderSlug
        {
            get
            {
                return "ORD" + (55555 + Id);
            }
        }

    }
}
