using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.Entities
{
    //[Table("trackorder")]
    public class TrackOrder
    {
        [BsonId]
        public string Id { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public int VendorId { get; set; }
        public int TrackActionType { get; set; }
        [MaxLength(500)]
        public string Remarks { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [NotMapped]
        [BsonIgnore]
        public string CreatedDateUtc
        {
            get
            {
                return CreatedDate.ToString("MMMM dd, yyyy hh:mm tt");
            }
        }
    }
}
