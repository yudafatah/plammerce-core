using Pc.Core.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Products
{
    public interface IProductReviewRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<ProductReview>> GetAll();
        Task<ProductReview> GetById(string id);
        Task Insert(ProductReview entity);
        Task Update(ProductReview entity);
        Task Upsert(ProductReview entity);
    }
}
