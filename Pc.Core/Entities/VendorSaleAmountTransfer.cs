using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECart.Models.Enum;

namespace Pc.Core.Entities
{
    //[Table("vendorsaleamounttransfer")]
    public class VendorSaleAmountTransfer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VendorId { get; set; }
        [MaxLength(150)]
        public string YourName { get; set; }
        [MaxLength(150)]
        public string BankName { get; set; }
        [MaxLength(150)]
        public string IfcsCode { get; set; }
        [MaxLength(150)]
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public VendorSaleAmountTransferStatusType Status { get; set; }

    }

}
