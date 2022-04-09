using Pc.Core.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Products
{
    public interface IProductFeatureRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<ProductFeature>> GetAll();
        Task<ProductFeature> GetById(string id);
        Task Insert(ProductFeature entity);
        Task Update(ProductFeature entity);
        Task Upsert(ProductFeature entity);
        Task<List<ProductFeature>> GetAllProductFeature(int productId, int vendorId);
        Task<List<ProductFeature>> GetAllWithProductId(int productId);
    }
}
