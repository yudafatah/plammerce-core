using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities.Product
{
    //[Table("productstocklog")]
    public class ProductStockLog
    {
        [BsonId]
        public string Id { get; set; }
        public int ProductId { get; set; }
        [MaxLength(150)]
        public string UserId { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        public int VendorId { get; set; }
        public int OrderId { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Sale { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Received { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        public int Type { get; set; }

    }

}
