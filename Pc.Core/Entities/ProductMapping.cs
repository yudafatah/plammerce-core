using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace Pc.Core.Entities.Product
{
    //[Table("productmapping")]
    public class ProductMapping
    {
        [BsonId]
        public int Id { get; set; }

        #region Keys

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        //[Required]
        //[Display(Name = "Disease")]
        //public virtual int DiseaseId { get; set; }

        //[ForeignKey("DiseaseId")]
        //public virtual Disease Diseases { get; set; }

        #endregion

        //[NotMapped]
        //public string DiseaseName { get; set; }
        [NotMapped]
        [BsonIgnore]
        public string SubCategoryName { get; set; }


    }

}
