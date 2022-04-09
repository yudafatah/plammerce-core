using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("subcategory")]
    public class SubCategory
    {
        [BsonId]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public bool Status { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }

}
