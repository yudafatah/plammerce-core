using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Vendors
{
    public interface IVendorSaleLogRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<VendorSaleLog>> GetAll();
        Task<VendorSaleLog> GetById(string id);
        Task Insert(VendorSaleLog entity);
        Task Update(VendorSaleLog entity);
        Task Upsert(VendorSaleLog entity);
    }
}
