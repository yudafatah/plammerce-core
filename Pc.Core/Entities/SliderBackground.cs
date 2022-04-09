using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities
{
    //[Table("sliderbackground")]
    public class SliderBackground
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name ="Browse Image (1920x422)")]
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

    }

}
