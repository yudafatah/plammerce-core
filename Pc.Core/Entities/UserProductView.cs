using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("userproductview")]
    public class UserProductView
    {
        [BsonId]
        public string Id { get; set; }
        [MaxLength(200)]
        public string UserId { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        public string ProductId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
