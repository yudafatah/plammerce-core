using System;

namespace Pc.Core.DTO
{
    public class OrderDetailDTO
    {
     
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public OrderStatusType Status { get; set; }
        public string UserName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string Mobile { get; set; }
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        public int vendorId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CouponDiscount { get; set; }
        public string Feature { get; set; }


    }
}