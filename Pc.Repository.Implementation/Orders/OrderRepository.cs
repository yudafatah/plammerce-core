using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.Core.Enums;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Orders
{
    public class OrderRepository : BaseMongoRepository, IOrderRepository
    {
        public OrderRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Order.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Order.DeleteManyAsync(FilterDefinition<Order>.Empty);
        }

        public Task<List<Order>> GetAll()
        {
            return Db.Order.Find(FilterDefinition<Order>.Empty).ToListAsync();
        }

        public Task<Order> GetById(string id)
        {
            return Db.Order.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Order entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.Order.InsertOneAsync(entity);
        }

        public Task Update(Order entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.Order.FindOneAndReplaceAsync(Builders<Order>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Order entity)
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

            return Db.Order.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        public Task<List<Order>> GetOrderWithDetailByUserId(string userId)
        {
            return Db.Order.Find(x => x.Status != (int)OrderStatusType.Pending
            && x.UserId == userId)
                .SortByDescending(s => s.CreatedDate)
                .ToListAsync();
        }
    }
}
