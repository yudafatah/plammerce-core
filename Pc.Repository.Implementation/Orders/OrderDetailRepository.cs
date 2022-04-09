using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Orders
{
    public class OrderDetailRepository : BaseMongoRepository, IOrderDetailRepository
    {
        public OrderDetailRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.OrderDetail.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.OrderDetail.DeleteManyAsync(FilterDefinition<OrderDetail>.Empty);
        }

        public Task<List<OrderDetail>> GetAll()
        {
            return Db.OrderDetail.Find(FilterDefinition<OrderDetail>.Empty).ToListAsync();
        }

        public Task<OrderDetail> GetById(string id)
        {
            return Db.OrderDetail.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(OrderDetail entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.OrderDetail.InsertOneAsync(entity);
        }

        public Task Update(OrderDetail entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.OrderDetail.FindOneAndReplaceAsync(Builders<OrderDetail>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(OrderDetail entity)
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

            return Db.OrderDetail.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
