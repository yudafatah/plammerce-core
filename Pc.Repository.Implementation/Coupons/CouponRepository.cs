using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Coupons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Coupons
{
    public class CouponRepository : BaseMongoRepository, ICouponRepository
    {
        public CouponRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Coupon.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Coupon.DeleteManyAsync(FilterDefinition<Coupon>.Empty);
        }

        public Task<List<Coupon>> GetAll()
        {
            return Db.Coupon.Find(FilterDefinition<Coupon>.Empty).ToListAsync();
        }

        public Task<Coupon> GetById(string id)
        {
            return Db.Coupon.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Coupon entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.Coupon.InsertOneAsync(entity);
        }

        public Task Update(Coupon entity)
        {
            return Db.Coupon.FindOneAndReplaceAsync(Builders<Coupon>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Coupon entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
                entity.CreatedDate = DateTime.Now;
            }

            return Db.Coupon.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
