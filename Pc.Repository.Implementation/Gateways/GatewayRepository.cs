using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Gateways;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Gateways
{
    public class GatewayRepository : BaseMongoRepository, IGatewayRepository
    {
        public GatewayRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Gateway.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Gateway.DeleteManyAsync(FilterDefinition<Gateway>.Empty);
        }

        public Task<List<Gateway>> GetAll()
        {
            return Db.Gateway.Find(FilterDefinition<Gateway>.Empty).ToListAsync();
        }

        public Task<Gateway> GetById(string id)
        {
            return Db.Gateway.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Gateway entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.Gateway.InsertOneAsync(entity);
        }

        public Task Update(Gateway entity)
        {
            return Db.Gateway.FindOneAndReplaceAsync(Builders<Gateway>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Gateway entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.Gateway.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
