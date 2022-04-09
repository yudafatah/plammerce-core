using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("category")]
    public class Category
    {
        [BsonId]
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter Category Name")]
        [MaxLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Enabled")]
        public bool Status { get; set; }

        public List<SubCategory> SubCategory { get; set; }
    }
}
