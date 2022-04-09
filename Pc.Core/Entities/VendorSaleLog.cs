using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pc.Core.Entities
{
    //[Table("vendorsalelog")]
    public class VendorSaleLog
    {
        [BsonId]
        public string Id { get; set; }
        public int VendorId { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Payment { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Received { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        public int Type { get; set; }
    }
}
