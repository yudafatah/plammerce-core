using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("brand")]
    public class Gateway
    {
        [BsonId]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Response { get; set; }

        [Required]
        [MaxLength(700)]
        public string Url { get; set; }
    }

}
