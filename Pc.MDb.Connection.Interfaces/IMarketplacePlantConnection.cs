using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.Core.Entities.Product;

namespace Pc.MDb.Connection.Interfaces
{
    public interface IMarketplacePlantConnection
    {
        IMongoCollection<Product> Product { get; set; }
        IMongoCollection<BankDetail> BankDetail { get; }
        IMongoCollection<Brand> Brand { get; }
        IMongoCollection<CartConfiguration> CartConfiguration { get; }
        IMongoCollection<Category> Category { get; }
        IMongoCollection<ContactUs> ContactUs { get; }
        IMongoCollection<Coupon> Coupon { get; }
        IMongoCollection<Currency> Currency { get; }
        IMongoCollection<Gateway> Gateway { get; }
        IMongoCollection<GatewayConfiguration> GatewayConfiguration { get; }
        IMongoCollection<MailSetting> MailSetting { get; }
        IMongoCollection<NewsLetter> NewsLetter { get; }
        IMongoCollection<Order> Order { get; }
        IMongoCollection<OrderDetail> OrderDetail { get; }
        IMongoCollection<Otp> Otp { get; }
        IMongoCollection<PatientReferModel> PatientReferModel { get; }
        IMongoCollection<PaymentGatewayLog> PaymentGatewayLog { get; }
        IMongoCollection<PrimiumVendorOrder> PrimiumVendorOrder { get; }
        IMongoCollection<ProductCart> ProductCart { get; }
        IMongoCollection<ProductFeature> ProductFeature { get; }
        IMongoCollection<ProductImage> ProductImage { get; }
        IMongoCollection<ProductMapping> ProductMapping { get; }
        IMongoCollection<ProductReview> ProductReview { get; }
        IMongoCollection<ProductSize> ProductSize { get; }
        IMongoCollection<ProductStockLog> ProductStockLog { get; }
        IMongoCollection<ProductWiseShippingCharges> ProductWiseShippingCharges { get; }
        IMongoCollection<Slider> Slider { get; }
        IMongoCollection<SliderBackground> SliderBackground { get; }
        IMongoCollection<SubCategory> SubCategory { get; }
        IMongoCollection<TrackOrder> TrackOrder { get; }
        IMongoCollection<ApplicationUser> ApplicationUser { get; }
        IMongoCollection<UserProductView> UserProductView { get; }
        IMongoCollection<Vendor> Vendor { get; }
        IMongoCollection<VendorProfile> VendorProfile { get; }
        IMongoCollection<VendorSaleAmountTransfer> VendorSaleAmountTransfer { get; }
        IMongoCollection<VendorSaleLog> VendorSaleLog { get; }
        IMongoCollection<Wallet> Wallet { get; }
        IMongoCollection<WalletLog> WalletLog { get; }
        IMongoCollection<WishList> WishList { get; }
    }
}
