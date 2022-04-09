using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Pc.Core.Entities.Product
{
    //[Table("productcart")]
    public class ProductCart
    {
        [BsonId]
        public string Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
    }
}
