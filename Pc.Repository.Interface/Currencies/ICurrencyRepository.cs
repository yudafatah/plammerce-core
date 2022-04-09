using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Currencies
{
    public interface ICurrencyRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Currency>> GetAll();
        Task<Currency> GetById(string id);
        Task Insert(Currency entity);
        Task Update(Currency entity);
        Task Upsert(Currency entity);
    }
}
