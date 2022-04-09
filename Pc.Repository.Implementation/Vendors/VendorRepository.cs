using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Vendors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Vendors
{
    public class VendorRepository : BaseMongoRepository, IVendorRepository
    {
        public VendorRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Vendor.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Vendor.DeleteManyAsync(FilterDefinition<Vendor>.Empty);
        }

        public Task<List<Vendor>> GetAll()
        {
            return Db.Vendor.Find(FilterDefinition<Vendor>.Empty).ToListAsync();
        }

        public Task<Vendor> GetById(string id)
        {
            return Db.Vendor.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Vendor entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.Vendor.InsertOneAsync(entity);
        }

        public Task Update(Vendor entity)
        {
            return Db.Vendor.FindOneAndReplaceAsync(Builders<Vendor>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Vendor entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.Vendor.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
