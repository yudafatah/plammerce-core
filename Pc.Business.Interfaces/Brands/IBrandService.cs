using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Business.Interfaces.Brands
{
    public interface IBrandService
    {
        Task Create(Brand brand);
        Task Delete(string id);
        Task<Brand> Details(string id);
        Task Edit(Brand brand);
        List<Brand> List();
        bool SearchForName(string name);
        Task<List<Brand>> GetAllBrandVendorWise(int roleId, int vendorId);
    }
}
