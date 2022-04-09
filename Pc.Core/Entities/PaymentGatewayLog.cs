using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities
{
    //[Table("paymentgatewaylog")]
    public class PaymentGatewayLog
    {
        [BsonId]
        public string Id { get; set; }

        [MaxLength(100)]
        public string UserId { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string TxnId { get; set; }
        public int OrderId { get; set; }
        [MaxLength(500)]
        public string PostedData { get; set; }
        public int GatewayType { get; set; }
        public int Status { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }

        public int? VendorId { get; set; } = 0;

    }
}
