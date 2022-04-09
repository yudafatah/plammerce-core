using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities
{
    //[Table("order")]
    public class PrimiumVendorOrder
    {
        [BsonId]
        public string Id { get; set; }
        public int VendorId { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalAmount { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

        [MaxLength(100)]
        public string TxnId { get; set; }

        [MaxLength(500)]
        public string EmailId { get; set; }

        [MaxLength(150)]
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
        public string PrimiumOrderSlug
        {
            get
            {
                return "ORD" + (55555 + Id);
            }
        }

    }
}
