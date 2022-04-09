using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECart.Models.Enum;

namespace Pc.Core.Entities
{
    //[Table("walletlog")]
    public class WalletLog
    {
        [Key]
        public int Id { get; set; }
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public decimal Payment { get; set; }
        public decimal Received { get; set; }
        public DateTime CreatedDate { get; set; }
        public WalletLogType Type { get; set; }
    }
}
