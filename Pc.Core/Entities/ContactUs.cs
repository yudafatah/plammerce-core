using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("product")]
    public class ContactUs
    {
        [BsonId]
        public string Id { get; set; }

        //[Required]
        [MaxLength(200)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        [Display(Name = "Your Email")]
        public string EmailId { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Your Phone No.")]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        public string Subject { get; set; }

        [MaxLength(500)]
        [Display(Name = "Your Message")]
        public string Message { get; set; }

        [MaxLength(100)]
        public string IpAddress { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
    }
}