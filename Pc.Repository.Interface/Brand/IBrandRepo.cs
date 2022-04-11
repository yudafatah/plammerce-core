using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Brand
{
    public interface IBrandRepo
    {
        Task<List<Core.Entities.Brand>> GetAllBrandVendorWise(int roleId, int vendorId);
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Core.Entities.Brand>> GetAll();
        Task<Core.Entities.Brand> GetById(string id);
        Task Insert(Core.Entities.Brand entity);
        Task Update(Core.Entities.Brand entity);
        Task Upsert(Core.Entities.Brand entity);
        bool IsNameExist(string name);
    }
}