using Pc.Core.Enums;
using System;

namespace Pc.Core.DTO
{
    public class VendorSaleDTO
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public decimal Payment { get; set; }
        public decimal Received { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public VendorSaleLogType Type { get; set; }
    }
}