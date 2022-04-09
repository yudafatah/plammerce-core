using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.WishLists
{
    public interface IWishlistRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<WishList>> GetAll();
        Task<WishList> GetById(string id);
        Task Insert(WishList entity);
        Task Update(WishList entity);
        Task Upsert(WishList entity);
    }
}
