using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Products
{
    public interface IUserProductViewRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<UserProductView>> GetAll();
        Task<UserProductView> GetById(string id);
        Task Insert(UserProductView entity);
        Task Update(UserProductView entity);
        Task Upsert(UserProductView entity);
    }
}
