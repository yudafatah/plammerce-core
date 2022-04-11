using Pc.Business.Interfaces.Categories;
using Pc.Core.Entities;
using Pc.Repository.Interface.Category;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Business.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepository;
        public CategoryService(ICategoryRepo categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task Create(Category category)
        {
            return _categoryRepository.Insert(category);
        }

        public Task Delete(string id)
        {
            return _categoryRepository.Delete(id);
        }

        public Task<Category> Details(string id)
        {
            return _categoryRepository.GetById(id);
        }

        public Task Edit(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public List<Category> List()
        {
            return _categoryRepository.GetAll().Result.OrderByDescending(x => x.Id).ToList();
        }

        public bool SearchForName(string name)
        {
            return _categoryRepository.IsNameExist(name);
        }
    }
}
