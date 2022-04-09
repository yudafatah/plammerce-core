using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Gateways;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Gateways
{
    public class GatewayConfigurationRepository : BaseMongoRepository, IGatewayConfigurationRepository
    {
        public GatewayConfigurationRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.GatewayConfiguration.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.GatewayConfiguration.DeleteManyAsync(FilterDefinition<GatewayConfiguration>.Empty);
        }

        public Task<List<GatewayConfiguration>> GetAll()
        {
            return Db.GatewayConfiguration.Find(FilterDefinition<GatewayConfiguration>.Empty).ToListAsync();
        }

        public Task<GatewayConfiguration> GetById(string id)
        {
            return Db.GatewayConfiguration.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(GatewayConfiguration entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.GatewayConfiguration.InsertOneAsync(entity);
        }

        public Task Update(GatewayConfiguration entity)
        {
            return Db.GatewayConfiguration.FindOneAndReplaceAsync(Builders<GatewayConfiguration>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(GatewayConfiguration entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
                entity.CreatedDate = DateTime.Now;
            }

            return Db.GatewayConfiguration.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
