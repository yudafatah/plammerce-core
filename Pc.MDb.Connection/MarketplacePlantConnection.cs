using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pc.Core.Configurations;
using Pc.Core.Entities;
using Pc.Core.Entities.Product;
using Pc.MDb.Connection.Interfaces;

namespace Pc.MDb.Connection
{
    public class MarketplacePlantConnection : MongoDbConnection, IMarketplacePlantConnection
    {
        public IMongoCollection<Product> Product { get; set; }
        public IMongoCollection<BankDetail> BankDetail { get; }
        public IMongoCollection<Brand> Brand { get; }
        public IMongoCollection<CartConfiguration> CartConfiguration { get; }
        public IMongoCollection<Category> Category { get; }
        public IMongoCollection<ContactUs> ContactUs { get; }
        public IMongoCollection<Coupon> Coupon { get; }
        public IMongoCollection<Currency> Currency { get; }
        public IMongoCollection<Gateway> Gateway { get; }
        public IMongoCollection<GatewayConfiguration> GatewayConfiguration { get; }
        public IMongoCollection<MailSetting> MailSetting { get; }
        public IMongoCollection<NewsLetter> NewsLetter { get; }
        public IMongoCollection<Order> Order { get; }
        public IMongoCollection<OrderDetail> OrderDetail { get; }
        public IMongoCollection<Otp> Otp { get; }
        public IMongoCollection<PatientReferModel> PatientReferModel { get; }
        public IMongoCollection<PaymentGatewayLog> PaymentGatewayLog { get; }
        public IMongoCollection<PrimiumVendorOrder> PrimiumVendorOrder { get; }
        public IMongoCollection<ProductCart> ProductCart { get; }
        public IMongoCollection<ProductFeature> ProductFeature { get; }
        public IMongoCollection<ProductImage> ProductImage { get; }
        public IMongoCollection<ProductMapping> ProductMapping { get; }
        public IMongoCollection<ProductReview> ProductReview { get; }
        public IMongoCollection<ProductSize> ProductSize { get; }
        public IMongoCollection<ProductStockLog> ProductStockLog { get; }
        public IMongoCollection<ProductWiseShippingCharges> ProductWiseShippingCharges { get; }
        public IMongoCollection<Slider> Slider { get; }
        public IMongoCollection<SliderBackground> SliderBackground { get; }
        public IMongoCollection<SubCategory> SubCategory { get; }
        public IMongoCollection<TrackOrder> TrackOrder { get; }
        public IMongoCollection<ApplicationUser> ApplicationUser { get; }
        public IMongoCollection<UserProductView> UserProductView { get; }
        public IMongoCollection<Vendor> Vendor { get; }
        public IMongoCollection<VendorProfile> VendorProfile { get; }
        public IMongoCollection<VendorSaleAmountTransfer> VendorSaleAmountTransfer { get; }
        public IMongoCollection<VendorSaleLog> VendorSaleLog { get; }
        public IMongoCollection<Wallet> Wallet { get; }
        public IMongoCollection<WalletLog> WalletLog { get; }
        public IMongoCollection<WishList> WishList { get; }

        public MarketplacePlantConnection(IOptions<ConstringConfig> connectionString)
            : base(connectionString.Value.MDbCore, WriteConcern.Acknowledged)
        {
            Product = Db.GetCollection<Product>("mp_product");
            BankDetail = Db.GetCollection<BankDetail>("mp_bank_detail");
            Brand = Db.GetCollection<Brand>("mp_brand");
            CartConfiguration = Db.GetCollection<CartConfiguration>("mp_cart_configuration");
            Category = Db.GetCollection<Category>("mp_category");
            ContactUs = Db.GetCollection<ContactUs>("mp_contact_us");
            Coupon = Db.GetCollection<Coupon>("mp_coupon");
            Currency = Db.GetCollection<Currency>("mp_currency");
            Gateway = Db.GetCollection<Gateway>("mp_gateway");
            GatewayConfiguration = Db.GetCollection<GatewayConfiguration>("mp_gateway_configuration");
            MailSetting = Db.GetCollection<MailSetting>("mp_mail_setting");
            NewsLetter = Db.GetCollection<NewsLetter>("mp_newsletter");
            Order = Db.GetCollection<Order>("mp_order");
            OrderDetail = Db.GetCollection<OrderDetail>("mp_order_detail");
            Otp = Db.GetCollection<Otp>("mp_otp");
            PatientReferModel = Db.GetCollection<PatientReferModel>("mp_patient_refermodel");
            PaymentGatewayLog = Db.GetCollection<PaymentGatewayLog>("mp_payment_gateway_log");
            PrimiumVendorOrder = Db.GetCollection<PrimiumVendorOrder>("mp_primium_vendor_order");
            ProductCart = Db.GetCollection<ProductCart>("mp_product_cart");
            ProductFeature = Db.GetCollection<ProductFeature>("mp_product_feature");
            ProductImage = Db.GetCollection<ProductImage>("mp_product_image");
            ProductMapping = Db.GetCollection<ProductMapping>("mp_product_mapping");
            ProductReview = Db.GetCollection<ProductReview>("mp_product_review");
            ProductSize = Db.GetCollection<ProductSize>("mp_product_size");
            ProductStockLog = Db.GetCollection<ProductStockLog>("mp_product_stock_log");
            ProductWiseShippingCharges = Db.GetCollection<ProductWiseShippingCharges>("mp_product_wise_shipping_charges");
            Slider = Db.GetCollection<Slider>("mp_slider");
            SliderBackground = Db.GetCollection<SliderBackground>("mp_slider_background");
            SubCategory = Db.GetCollection<SubCategory>("mp_sub_category");
            TrackOrder = Db.GetCollection<TrackOrder>("mp_track_order");
            ApplicationUser = Db.GetCollection<ApplicationUser>("mp_application_user");
            UserProductView = Db.GetCollection<UserProductView>("mp_user_product_view");
            Vendor = Db.GetCollection<Vendor>("mp_vendor");
            VendorProfile = Db.GetCollection<VendorProfile>("mp_vendor_profile");
            VendorSaleAmountTransfer = Db.GetCollection<VendorSaleAmountTransfer>("mp_vendor_sale_amount_transfer");
            VendorSaleLog = Db.GetCollection<VendorSaleLog>("mp_vendor_sale_log");
            Wallet = Db.GetCollection<Wallet>("mp_wallet");
            WalletLog = Db.GetCollection<WalletLog>("mp_wallet_log");
            WishList = Db.GetCollection<WishList>("mp_wish_list");
        }
    }
}
