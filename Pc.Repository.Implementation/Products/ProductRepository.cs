using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities.Product;
using Pc.Core.Enums;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Products
{
    public class ProductRepository : BaseMongoRepository, IProductRepository
    {
        public ProductRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Product.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Product.DeleteManyAsync(FilterDefinition<Product>.Empty);
        }

        public Task<List<Product>> GetAll()
        {
            return Db.Product.Find(FilterDefinition<Product>.Empty).ToListAsync();
        }

        public Task<Product> GetById(string id)
        {
            return Db.Product.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Product entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.Product.InsertOneAsync(entity);
        }

        public Task Update(Product entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.Product.FindOneAndReplaceAsync(Builders<Product>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Product entity)
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

            return Db.Product.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        public List<Product> GetAllProduct(int roleId, int vendorId, int status)
        {
            if (roleId == 2)
            {
                if (status == 0)
                {
                    return Db.Product.Find(x => x.Status == (int)ProductStatusType.Pending).SortByDescending(x => x.Id).ToList();
                }
                else if (status == 1)
                {
                    return Db.Product.Find(x => x.Status == (int)ProductStatusType.Published).SortByDescending(x => x.Id).ToList();
                }
                else if (status == 2)
                {
                    return Db.Product.Find(x => x.Status == (int)ProductStatusType.Deleted).SortByDescending(x => x.Id).ToList();
                }
                return Db.Product.Find(FilterDefinition<Product>.Empty).SortByDescending(s=> s.Id).ToList();
            }
            else if (roleId == 3)
            {
                return Db.Product.Find(x => x.Status == (int)ProductStatusType.Published).SortByDescending(x => x.Id).ToList();
            }
            return Db.Product.Find(x => x.VendorId == vendorId && x.Status != (int)ProductStatusType.Deleted).SortByDescending(x => x.Id).ToList();
        }

        public async Task<List<ProductFeature>> GetAllProductFeature(string productId, int vendorId)
        {
            var data = await GetById(productId);

            return data.ProductFeatures.Where(c => c.VendorId == vendorId
            && c.Status != (int)SizeStatusType.Deleted)
                .OrderByDescending(s => s.Id)
                .ToList();
        }

        public async Task<List<ProductFeature>> GetAllWithProductId(string productId)
        {
            var data = await GetById(productId);

            return data.ProductFeatures.Where(c =>
            c.Status != (int)SizeStatusType.Deleted)
                .OrderByDescending(s => s.Id)
                .ToList();
        }

        public async Task<int> GetProductImageCount(string productId)
        {
            var data = await GetById(productId);

            return data.ProductImages.Count;
        }
    }
}
