using Pc.Core.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pc.Core.DTO
{
    public class CheckoutDTO
    {
        public List<CheckoutProductDTO> Products { get; set; }
        public CheckoutProfileDTO Profile { get; set; }
        public string CouponCode { get; set; }
    }


    public class CheckoutProductDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int VendorId { get; set; }
        public decimal Total { get; set; }
        public string AffiliateKey { get; set; }
        public string Feature { get; set; }


        [NotMapped]
        public int? AffiliateVendorId
        {
            get
            {
                if (!string.IsNullOrEmpty(AffiliateKey))
                {
                    string vid = AffiliateKey.Replace(Constant.affiliateSlugHelper, "");
                    _ = int.TryParse(vid, out int vendorId);
                    if (vendorId > 0)
                    {
                        return vendorId;
                    }
                    return null;
                }
                return null;
            }
        }

    }

    public class CheckoutProfileDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PaymentMode { get; set; }
        
    }

    public class CartProductDTO
    {
        public int productId { get; set; }
        public decimal price { get; set; }
        public int qty { get; set; }
        public string name { get; set; }
        public string imagePathUrl { get; set; }
        public string affiliateKey { get; set; }
    }

}