using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pc.Core.Entities
{
    //[Table("slider")]
    public class Slider
    {
        [BsonId]
        public string Id { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name ="Browse Image (555X372)")]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string SubTitle { get; set; }

        [Required]
        [MaxLength(500)]
        public string Link { get; set; }
        
        
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
