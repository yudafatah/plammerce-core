using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Orders
{
    public interface IOrderDetailRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<OrderDetail>> GetAll();
        Task<OrderDetail> GetById(string id);
        Task Insert(OrderDetail entity);
        Task Update(OrderDetail entity);
        Task Upsert(OrderDetail entity);
    }
}
