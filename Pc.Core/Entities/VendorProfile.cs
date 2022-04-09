using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Pc.Core.Entities
{
    //[Table("product")]
    public class VendorProfile
    {
        [BsonId]
        public string Id { get; set; }

        public int VendorId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Education { get; set; }

        [Required]
        [MaxLength(255)]
        public string Skills { get; set; }
        [Required]
        [MaxLength(255)]
        public string Work { get; set; }
        [Required]
        [MaxLength(255)]
        public string Experience { get; set; }
        [MaxLength(255)]
        public string ProfileImage { get; set; }


    }
}
