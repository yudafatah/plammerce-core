using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("cartconfiguration")]
    public class Currency
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Currency Name")]
        public string CurrencyName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Currency Sign")]
        public string CurrencySign { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }

        public int Status { get; set; }
    }

}
