using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Gateways
{
    public interface IGatewayRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Gateway>> GetAll();
        Task<Gateway> GetById(string id);
        Task Insert(Gateway entity);
        Task Update(Gateway entity);
        Task Upsert(Gateway entity);
    }
}
