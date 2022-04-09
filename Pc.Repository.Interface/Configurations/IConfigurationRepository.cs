using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Configurations
{
    public interface IConfigurationRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<CartConfiguration>> GetAll();
        Task<CartConfiguration> GetById(string id);
        Task Insert(CartConfiguration entity);
        Task Update(CartConfiguration entity);
        Task Upsert(CartConfiguration entity);
    }
}
