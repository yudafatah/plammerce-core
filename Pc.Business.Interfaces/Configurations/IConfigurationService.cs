using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Business.Interfaces.Configurations
{
    public interface IConfigurationService
    {
        Task Create(CartConfiguration cartConfiguration);
        Task Delete(string id);
        Task<CartConfiguration> Details(string id);
        Task Edit(CartConfiguration cartConfiguration);
        Task<List<CartConfiguration>> List();
    }
}
