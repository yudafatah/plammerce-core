using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Pc.Core.Entities
{
    //[Table("product")]
    public class NewsLetter
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string EmailId { get; set; }

        [MaxLength(100)]
        public string IpAddress { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
    }
}