using Pc.Core.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Products
{
    public interface IProductStockLogRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<ProductStockLog>> GetAll();
        Task<ProductStockLog> GetById(string id);
        Task Insert(ProductStockLog entity);
        Task Update(ProductStockLog entity);
        Task Upsert(ProductStockLog entity);
    }
}
