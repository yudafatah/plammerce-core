using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using Pc.Core.Constants;

namespace Pc.Core.Entities
{
    //[Table("vendor")]
    public class Vendor
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string EmailId { get; set; }

        [MaxLength(45)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [MaxLength(45)]
        [Display(Name = "GST Number")]
        public string GstNumber { get; set; }

        public int Status { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(200)]
        public string State { get; set; }

        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(20)]
        public string Pincode { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public int ReferedBy { get; set; }

        public string AffiliateSlug
        {
            get
            {
                return Constant.affiliateSlugHelper + Id;
            }
        }
        public string EmailMobile { get; set; }
        public string AffiliateReferKey { get; set; }

        public string Password { get; set; }

        public VendorProfile VendorProfile { get; set; }
    }
}
