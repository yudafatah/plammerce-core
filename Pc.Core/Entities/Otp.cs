using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("disease")]
    public class Otp
    {
        [BsonId]
        public string Id { get; set; }
        public int Pin { get; set; }
        [MaxLength(200)]
        public string EmailId { get; set; }
        [MaxLength(45)]
        public string PhoneNumber { get; set; }
        public int VendorId { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? VerifiedDate { get; set; }
        public bool Status { get; set; }
    }

}
