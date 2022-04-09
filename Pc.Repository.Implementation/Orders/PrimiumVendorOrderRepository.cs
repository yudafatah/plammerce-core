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
    public class PrimiumVendorOrderRepository : BaseMongoRepository, IPrimiumVendorOrderRepository
    {
        public PrimiumVendorOrderRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.PrimiumVendorOrder.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.PrimiumVendorOrder.DeleteManyAsync(FilterDefinition<PrimiumVendorOrder>.Empty);
        }

        public Task<List<PrimiumVendorOrder>> GetAll()
        {
            return Db.PrimiumVendorOrder.Find(FilterDefinition<PrimiumVendorOrder>.Empty).ToListAsync();
        }

        public Task<PrimiumVendorOrder> GetById(string id)
        {
            return Db.PrimiumVendorOrder.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(PrimiumVendorOrder entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.PrimiumVendorOrder.InsertOneAsync(entity);
        }

        public Task Update(PrimiumVendorOrder entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.PrimiumVendorOrder.FindOneAndReplaceAsync(Builders<PrimiumVendorOrder>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(PrimiumVendorOrder entity)
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

            return Db.PrimiumVendorOrder.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        public Task<List<PrimiumVendorOrder>> GetOrderWithDetailByUserId(int vendorId)
        {
            return Db.PrimiumVendorOrder.Find(x => x.Status != (int)PrimiumVendorStatusType.Pending
            && x.VendorId == vendorId)
                .SortByDescending(s => s.CreatedDate)
                .ToListAsync();
        }
    }
}
