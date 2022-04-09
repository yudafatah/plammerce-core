using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Vendors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Vendors
{
    public class VendorSaleLogRepository : BaseMongoRepository, IVendorSaleLogRepository
    {
        public VendorSaleLogRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.VendorSaleLog.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.VendorSaleLog.DeleteManyAsync(FilterDefinition<VendorSaleLog>.Empty);
        }

        public Task<List<VendorSaleLog>> GetAll()
        {
            return Db.VendorSaleLog.Find(FilterDefinition<VendorSaleLog>.Empty).ToListAsync();
        }

        public Task<VendorSaleLog> GetById(string id)
        {
            return Db.VendorSaleLog.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(VendorSaleLog entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.VendorSaleLog.InsertOneAsync(entity);
        }

        public Task Update(VendorSaleLog entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.VendorSaleLog.FindOneAndReplaceAsync(Builders<VendorSaleLog>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(VendorSaleLog entity)
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

            return Db.VendorSaleLog.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
