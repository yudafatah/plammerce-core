using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities.Product;
using Pc.Core.Enums;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Products
{
    public class ProductFeatureRepository : BaseMongoRepository, IProductFeatureRepository
    {
        public ProductFeatureRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.ProductFeature.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.ProductFeature.DeleteManyAsync(FilterDefinition<ProductFeature>.Empty);
        }

        public Task<List<ProductFeature>> GetAll()
        {
            return Db.ProductFeature.Find(FilterDefinition<ProductFeature>.Empty).ToListAsync();
        }

        public Task<ProductFeature> GetById(string id)
        {
            return Db.ProductFeature.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(ProductFeature entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.ProductFeature.InsertOneAsync(entity);
        }

        public Task Update(ProductFeature entity)
        {
            return Db.ProductFeature.FindOneAndReplaceAsync(Builders<ProductFeature>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(ProductFeature entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.ProductFeature.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        public Task<List<ProductFeature>> GetAllProductFeature(int productId, int vendorId)
        {
            return Db.ProductFeature.Find(c => c.VendorId == vendorId
            && c.ProductId == productId
            && c.Status != (int)SizeStatusType.Deleted)
                .SortByDescending(s => s.Id)
                .ToListAsync();
        }

        public Task<List<ProductFeature>> GetAllWithProductId(int productId)
        {
            return Db.ProductFeature.Find(c =>
            c.ProductId == productId
            && c.Status != (int)SizeStatusType.Deleted)
                .SortByDescending(s => s.Id)
                .ToListAsync();
        }
    }
}
