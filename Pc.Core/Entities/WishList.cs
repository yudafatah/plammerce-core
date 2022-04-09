using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("wishlist")]
    public class WishList
    {
        [BsonId]
        public string Id { get; set; }

        [MaxLength(150)]
        public string UserId { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }

        [Required]
        public int ProductId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
    }
}
