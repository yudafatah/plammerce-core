using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("cartconfiguration")]
    public class GatewayConfiguration
    {
        [BsonId]
        public string Id { get; set; }

        [Display(Name = "Gateway Name")]
        public int GatewayName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Secret Key")]
        public string SecretKey { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Salt Key")]
        public string SaltKey { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
    }

}
