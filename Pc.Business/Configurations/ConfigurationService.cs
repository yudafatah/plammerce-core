using Pc.Business.Interfaces.Configurations;
using Pc.Core.Entities;
using Pc.Repository.Interface.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Business.Configurations
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task Create(CartConfiguration cartConfiguration)
        {
            return _configurationRepository.Insert(cartConfiguration);
        }

        public Task Delete(string id)
        {
            return _configurationRepository.Delete(id);
        }

        public Task<CartConfiguration> Details(string id)
        {
            return _configurationRepository.GetById(id);
        }

        public Task Edit(CartConfiguration cartConfiguration)
        {
            return _configurationRepository.Update(cartConfiguration);
        }

        public Task<List<CartConfiguration>> List()
        {
            return _configurationRepository.GetAll();
        }
    }
}
