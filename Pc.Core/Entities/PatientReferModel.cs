using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    public class PatientReferModel
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Disease { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Vendorid { get; set; }
    }
}
