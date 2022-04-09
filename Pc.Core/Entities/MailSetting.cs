using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("brand")]
    public class MailSetting
    {
        [BsonId]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FromEmail { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Host { get; set; }
        [MaxLength(100)]
        public string Port { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
    }

}
