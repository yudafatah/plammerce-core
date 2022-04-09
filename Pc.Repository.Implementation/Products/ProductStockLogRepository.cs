using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities.Product;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Products
{
    public class ProductStockLogRepository : BaseMongoRepository, IProductStockLogRepository
    {
        public ProductStockLogRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.ProductStockLog.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.ProductStockLog.DeleteManyAsync(FilterDefinition<ProductStockLog>.Empty);
        }

        public Task<List<ProductStockLog>> GetAll()
        {
            return Db.ProductStockLog.Find(FilterDefinition<ProductStockLog>.Empty).ToListAsync();
        }

        public Task<ProductStockLog> GetById(string id)
        {
            return Db.ProductStockLog.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(ProductStockLog entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.ProductStockLog.InsertOneAsync(entity);
        }

        public Task Update(ProductStockLog entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.ProductStockLog.FindOneAndReplaceAsync(Builders<ProductStockLog>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(ProductStockLog entity)
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

            return Db.ProductStockLog.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
