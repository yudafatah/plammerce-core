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
    public class ProductReviewRepository : BaseMongoRepository, IProductReviewRepository
    {
        public ProductReviewRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.ProductReview.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.ProductReview.DeleteManyAsync(FilterDefinition<ProductReview>.Empty);
        }

        public Task<List<ProductReview>> GetAll()
        {
            return Db.ProductReview.Find(FilterDefinition<ProductReview>.Empty).ToListAsync();
        }

        public Task<ProductReview> GetById(string id)
        {
            return Db.ProductReview.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(ProductReview entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.ProductReview.InsertOneAsync(entity);
        }

        public Task Update(ProductReview entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.ProductReview.FindOneAndReplaceAsync(Builders<ProductReview>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(ProductReview entity)
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

            return Db.ProductReview.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
