using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities.Product
{
    //[Table("productreview")]
    public class ProductReview
    {
        [BsonId]
        public string Id { get; set; }

        [MaxLength(150)]
        public string UserId { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string ProductId { get; set; }

        [MaxLength(500)]
        [Required]
        public string Message { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(150)]
        public string UserName { get; set; }

        public int Status { get; set; }

        [NotMapped]
        [BsonIgnore]
        public string CreatedDateUtc
        {
            get
            {
                return CreatedDate.ToString("MMMM dd, yyyy");
            }
        }

        [NotMapped]
        [BsonIgnore]
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(UserName))
                {
                    return UserName.Split('@')[0];
                }
                return "";
            }
        }
    }
}
