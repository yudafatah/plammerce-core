using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Products
{
    public class UserProductViewRepository : BaseMongoRepository, IUserProductViewRepository
    {
        public UserProductViewRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.UserProductView.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.UserProductView.DeleteManyAsync(FilterDefinition<UserProductView>.Empty);
        }

        public Task<List<UserProductView>> GetAll()
        {
            return Db.UserProductView.Find(FilterDefinition<UserProductView>.Empty).ToListAsync();
        }

        public Task<UserProductView> GetById(string id)
        {
            return Db.UserProductView.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(UserProductView entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.UserProductView.InsertOneAsync(entity);
        }

        public Task Update(UserProductView entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.UserProductView.FindOneAndReplaceAsync(Builders<UserProductView>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(UserProductView entity)
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

            return Db.UserProductView.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
