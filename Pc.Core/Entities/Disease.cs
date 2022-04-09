using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("disease")]
    public class Disease
    {
        [BsonId]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Sno { get; set; }
        public bool Status { get; set; }
    }

}
