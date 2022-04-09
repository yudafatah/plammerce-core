using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Gateways
{
    public interface IGatewayConfigurationRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<GatewayConfiguration>> GetAll();
        Task<GatewayConfiguration> GetById(string id);
        Task Insert(GatewayConfiguration entity);
        Task Update(GatewayConfiguration entity);
        Task Upsert(GatewayConfiguration entity);
    }
}
