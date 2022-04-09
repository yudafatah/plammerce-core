using Pc.Core.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Products
{
    public interface IProductRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Product>> GetAll();
        Task<Product> GetById(string id);
        Task Insert(Product entity);
        Task Update(Product entity);
        Task Upsert(Product entity);
        List<Product> GetAllProduct(int roleId, int vendorId, int status);
        Task<List<ProductFeature>> GetAllProductFeature(string productId, int vendorId);
        Task<List<ProductFeature>> GetAllWithProductId(string productId);
        Task<int> GetProductImageCount(string productId);
    }
}
