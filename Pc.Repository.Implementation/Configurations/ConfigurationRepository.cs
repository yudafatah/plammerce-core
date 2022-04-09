using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Configurations
{
    public class ConfigurationRepository : BaseMongoRepository, IConfigurationRepository
    {
        public ConfigurationRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.CartConfiguration.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.CartConfiguration.DeleteManyAsync(FilterDefinition<CartConfiguration>.Empty);
        }

        public Task<List<CartConfiguration>> GetAll()
        {
            return Db.CartConfiguration.Find(FilterDefinition<CartConfiguration>.Empty).ToListAsync();
        }

        public Task<CartConfiguration> GetById(string id)
        {
            return Db.CartConfiguration.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(CartConfiguration entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.CartConfiguration.InsertOneAsync(entity);
        }

        public Task Update(CartConfiguration entity)
        {
            return Db.CartConfiguration.FindOneAndReplaceAsync(Builders<CartConfiguration>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(CartConfiguration entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.CartConfiguration.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
