using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Vendors
{
    public interface IVendorProfileRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<VendorProfile>> GetAll();
        Task<VendorProfile> GetById(string id);
        Task Insert(VendorProfile entity);
        Task Update(VendorProfile entity);
        Task Upsert(VendorProfile entity);
    }
}
