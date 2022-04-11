using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Enums;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Brand;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Brand = Pc.Core.Entities.Brand;

namespace Pc.Repository.Implementation.Brands
{
    public class BrandRepo : BaseMongoRepository, IBrandRepo
    {
        public BrandRepo(IMarketplacePlantConnection conn) : base(conn) { }

        public Task<List<Brand>> GetAllBrandVendorWise(int roleId, int vendorId)
        {
            if (roleId == 2)
            {
                return Db.Brand.Find(FilterDefinition<Brand>.Empty)
                    .SortByDescending(s => s.Id)
                    .ToListAsync();
            }

            return Db.Brand.Find(c => c.VendorId == vendorId && c.Status != (int)BrandStatusType.Deleted)
                .SortByDescending(s => s.Id)
                .ToListAsync();
        }

        public bool IsNameExist(string name)
        {
            var filter = Builders<Brand>.Filter.Regex(c => c.Name, "/" + name + "/i");

            return Db.Brand.Find(filter).Any();
        }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Brand.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Brand.DeleteManyAsync(FilterDefinition<Brand>.Empty);
        }

        public Task<List<Brand>> GetAll()
        {
            return Db.Brand.Find(FilterDefinition<Brand>.Empty).ToListAsync();
        }

        public Task<Brand> GetById(string id)
        {
            return Db.Brand.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Brand entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.Brand.InsertOneAsync(entity);
        }

        public Task Update(Brand entity)
        {
            return Db.Brand.FindOneAndReplaceAsync(Builders<Brand>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Brand entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.Brand.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
