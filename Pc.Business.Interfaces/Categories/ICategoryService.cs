using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Business.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task Create(Category category);
        Task Delete(string id);
        Task<Category> Details(string id);
        Task Edit(Category category);
        List<Category> List();
        bool SearchForName(string name);
    }
}
