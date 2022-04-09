using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities.Product
{
    //[Table("productimage")]
    public class ProductImage
    {
        [BsonId]
        public string Id { get; set; }
        [Required]

        [MaxLength(255)]
        [Display(Name ="Browse Image (720x760)")]
        public string ImagePath { get; set; }

        public bool Status { get; set; }

        [NotMapped]
        [BsonIgnore]
        public string ImagePathUrl
        {
            get
            {
                return "/" + ImagePath;
            }
        }

        [NotMapped]
        [BsonIgnore]
        public string ImagePath400Url
        {
            get
            {
                //return ConfigurationManager.AppSettings["AdminUrl"] + ImagePath.Replace("/ProductImage/", "/ProductImage/400x400/");
                return "/" + ImagePath.Replace("/ProductImage/", "/ProductImage/400x400/");
            }
        }

        [NotMapped]
        [BsonIgnore]
        public string ImagePath1024Url
        {
            get
            {
                return "/" + ImagePath.Replace("/ProductImage/", "/ProductImage/1024x1024/");
            }
        }

        [NotMapped]
        [BsonIgnore]
        public string ImagePathMediumUrl
        {
            get
            {
                return "/" + ImagePath.Replace("/ProductImage/", "/ProductImage/178x200/");
            }
        }

    }

}
