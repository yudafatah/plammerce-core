using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Orders
{
    public interface IPrimiumVendorOrderRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<PrimiumVendorOrder>> GetAll();
        Task<PrimiumVendorOrder> GetById(string id);
        Task Insert(PrimiumVendorOrder entity);
        Task Update(PrimiumVendorOrder entity);
        Task Upsert(PrimiumVendorOrder entity);
        Task<List<PrimiumVendorOrder>> GetOrderWithDetailByUserId(int vendorId);
    }
}
