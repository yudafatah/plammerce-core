using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Category
{
    public interface ICategoryRepo
    {
        Task<List<Core.Entities.Category>> GetAllWithSubCategory();
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Core.Entities.Category>> GetAll();
        Task<Core.Entities.Category> GetById(string id);
        Task Insert(Core.Entities.Category entity);
        Task Update(Core.Entities.Category entity);
        Task Upsert(Core.Entities.Category entity);
        bool IsNameExist(string name);
    }
}
