using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("bankdetail")]
    public class BankDetail
    {
        [BsonId]
        public string Id { get; set; }

        public string VendorId { get; set; }

        [Required]
        public long AccountNo { get; set; }

        [Required]
        [MaxLength(200)]
        public string AccountName { get; set; }

        [Required]
        [MaxLength(200)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(200)]
        public string IfscCode { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Aadhar No.")]
        public string AdharNo { get; set; }

        [MaxLength(255)]
        [Display(Name = "Aadhar Front")]
        public string AdharImage { get; set; }

        [MaxLength(255)]
        [Display(Name = "Aadhar Back")]
        public string AdharBack { get; set; }

        [MaxLength(255)]
        public string PanImage { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? VerifiedDate { get; set; }
        public int Status { get; set; }
    }
}
