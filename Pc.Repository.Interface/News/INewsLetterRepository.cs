using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.News
{
    public interface INewsLetterRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<NewsLetter>> GetAll();
        Task<NewsLetter> GetById(string id);
        Task Insert(NewsLetter entity);
        Task Update(NewsLetter entity);
        Task Upsert(NewsLetter entity);
    }
}
