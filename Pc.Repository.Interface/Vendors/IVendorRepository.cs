using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Vendors
{
    public interface IVendorRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Vendor>> GetAll();
        Task<Vendor> GetById(string id);
        Task Insert(Vendor entity);
        Task Update(Vendor entity);
        Task Upsert(Vendor entity);
    }
}
