using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Orders
{
    public interface IOrderRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Order>> GetAll();
        Task<Order> GetById(string id);
        Task Insert(Order entity);
        Task Update(Order entity);
        Task Upsert(Order entity);
        Task<List<Order>> GetOrderWithDetailByUserId(string userId);
    }
}
