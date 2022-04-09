using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.WishLists;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.WishLists
{
    public class WishlistRepository : BaseMongoRepository, IWishlistRepository
    {
        public WishlistRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.WishList.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.WishList.DeleteManyAsync(FilterDefinition<WishList>.Empty);
        }

        public Task<List<WishList>> GetAll()
        {
            return Db.WishList.Find(FilterDefinition<WishList>.Empty).ToListAsync();
        }

        public Task<WishList> GetById(string id)
        {
            return Db.WishList.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(WishList entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.WishList.InsertOneAsync(entity);
        }

        public Task Update(WishList entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.WishList.FindOneAndReplaceAsync(Builders<WishList>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(WishList entity)
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

            return Db.WishList.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
