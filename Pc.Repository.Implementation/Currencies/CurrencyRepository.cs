using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Currencies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Currencies
{
    public class CurrencyRepository : BaseMongoRepository, ICurrencyRepository
    {
        public CurrencyRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Currency.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Currency.DeleteManyAsync(FilterDefinition<Currency>.Empty);
        }

        public Task<List<Currency>> GetAll()
        {
            return Db.Currency.Find(FilterDefinition<Currency>.Empty).ToListAsync();
        }

        public Task<Currency> GetById(string id)
        {
            return Db.Currency.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Currency entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.Currency.InsertOneAsync(entity);
        }

        public Task Update(Currency entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.Currency.FindOneAndReplaceAsync(Builders<Currency>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Currency entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
                entity.CreatedDate = DateTime.Now;
            }
            else
            {
                entity.UpdatedDate = DateTime.Now;
            }

            return Db.Currency.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
