using Pc.Business.Interfaces.Brands;
using Pc.Core.Entities;
using Pc.Repository.Interface.Brand;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Business.Brands
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepo _brandRepository;
        public BrandService(IBrandRepo brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Task Create(Brand brand)
        {
            return _brandRepository.Insert(brand);
        }

        public Task Delete(string id)
        {
            return _brandRepository.Delete(id);
        }

        public Task<Brand> Details(string id)
        {
            return _brandRepository.GetById(id);
        }

        public Task Edit(Brand brand)
        {
            return _brandRepository.Update(brand);
        }

        public List<Brand> List()
        {
            return _brandRepository.GetAll().Result.OrderByDescending(c=> c.Id).ToList();
        }
        public bool SearchForName(string name)
        {
            return _brandRepository.IsNameExist(name);
        }
        public Task<List<Brand>> GetAllBrandVendorWise(int roleId, int vendorId)
        {
            return _brandRepository.GetAllBrandVendorWise(roleId, vendorId);
        }
    }
}
