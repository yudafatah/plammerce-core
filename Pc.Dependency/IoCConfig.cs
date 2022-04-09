using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pc.Business.Banks;
using Pc.Business.Interfaces.Banks;
using Pc.Core.Configurations;
using Pc.Mdb.Connection.Interfaces;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Implementation.Bank;
using Pc.Repository.Implementation.Brands;
using Pc.Repository.Implementation.Categories;
using Pc.Repository.Implementation.Configurations;
using Pc.Repository.Implementation.ContactUsx;
using Pc.Repository.Implementation.Coupons;
using Pc.Repository.Implementation.Currencies;
using Pc.Repository.Implementation.Gateways;
using Pc.Repository.Implementation.Mails;
using Pc.Repository.Implementation.News;
using Pc.Repository.Implementation.Orders;
using Pc.Repository.Implementation.Otps;
using Pc.Repository.Implementation.PaymentGateways;
using Pc.Repository.Implementation.Products;
using Pc.Repository.Implementation.Sliders;
using Pc.Repository.Implementation.Vendors;
using Pc.Repository.Implementation.WishLists;
using Pc.Repository.Interface.Bank;
using Pc.Repository.Interface.Brand;
using Pc.Repository.Interface.Category;
using Pc.Repository.Interface.Configurations;
using Pc.Repository.Interface.ContactUsx;
using Pc.Repository.Interface.Coupons;
using Pc.Repository.Interface.Currencies;
using Pc.Repository.Interface.Gateways;
using Pc.Repository.Interface.Mails;
using Pc.Repository.Interface.News;
using Pc.Repository.Interface.Orders;
using Pc.Repository.Interface.Otps;
using Pc.Repository.Interface.PaymentGateways;
using Pc.Repository.Interface.Products;
using Pc.Repository.Interface.Sliders;
using Pc.Repository.Interface.Vendors;
using Pc.Repository.Interface.WishLists;

namespace Pc.Dependency
{
    public class IoCConfig
    {
        private readonly IServiceCollection _container;

        public IoCConfig(IServiceCollection container)
        {
            _container = container;
        }

        public void RegisterCore() { }

        public void RegisterRepositories()
        {
            _container.AddSingleton<IMarketplacePlantConnection, MarketplacePlantConnection>();
            _container.AddSingleton<IMongoDbConnection, MongoDbConnection>();

            _container.AddSingleton<IBankDetailRepo, BankDetailRepo>();
            _container.AddSingleton<IBrandRepo, BrandRepo>();
            _container.AddSingleton<ICategoryRepo, CategoryRepo>();
            _container.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
            _container.AddSingleton<IContactUsRepository, ContactUsRepository>();
            _container.AddSingleton<ICouponRepository, CouponRepository>();
            _container.AddSingleton<ICurrencyRepository, CurrencyRepository>();
            _container.AddSingleton<IGatewayConfigurationRepository, GatewayConfigurationRepository>();
            _container.AddSingleton<IGatewayRepository, GatewayRepository>();
            _container.AddSingleton<IMailSettingRepository, MailSettingRepository>();
            _container.AddSingleton<INewsLetterRepository, NewsLetterRepository>();
            _container.AddSingleton<IOrderDetailRepository, OrderDetailRepository>();
            _container.AddSingleton<IOrderRepository, OrderRepository>();
            _container.AddSingleton<IPrimiumVendorOrderRepository, PrimiumVendorOrderRepository>();
            _container.AddSingleton<IOtpRepository, OtpRepository>();
            _container.AddSingleton<IPaymentGatewayLogRepository, PaymentGatewayLogRepository>();
            _container.AddSingleton<IProductFeatureRepository, ProductFeatureRepository>();
            _container.AddSingleton<IProductRepository, ProductRepository>();
            _container.AddSingleton<IProductReviewRepository, ProductReviewRepository>();
            _container.AddSingleton<IProductStockLogRepository, ProductStockLogRepository>();
            _container.AddSingleton<IUserProductViewRepository, UserProductViewRepository>();
            _container.AddSingleton<ISliderBackgroundRepository, SliderBackgroundRepository>();
            _container.AddSingleton<IVendorProfileRepository, VendorProfileRepository>();
            _container.AddSingleton<IVendorRepository, VendorRepository>();
            _container.AddSingleton<IVendorSaleLogRepository, VendorSaleLogRepository>();
            _container.AddSingleton<IWishlistRepository, WishlistRepository>();
        }

        public void RegisterServices()
        {
            _container.AddSingleton<IBankDetailService, BankDetailService>();
        }

        public void RegisterBusiness() { }

        public void RegisterForClient()
        {
            RegisterCore();
            RegisterRepositories();
            RegisterServices();
            RegisterBusiness();
        }

        public void LoadConfiguration(IConfiguration configuration)
        {
            var constring = configuration.GetSection("Constring");

            _container.Configure<ConstringConfig>(constring);
        }
    }
}
