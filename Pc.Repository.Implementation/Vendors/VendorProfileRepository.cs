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
    public class VendorProfileRepository : BaseMongoRepository, IVendorProfileRepository
    {
        public VendorProfileRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.VendorProfile.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.VendorProfile.DeleteManyAsync(FilterDefinition<VendorProfile>.Empty);
        }

        public Task<List<VendorProfile>> GetAll()
        {
            return Db.VendorProfile.Find(FilterDefinition<VendorProfile>.Empty).ToListAsync();
        }

        public Task<VendorProfile> GetById(string id)
        {
            return Db.VendorProfile.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(VendorProfile entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.VendorProfile.InsertOneAsync(entity);
        }

        public Task Update(VendorProfile entity)
        {
            return Db.VendorProfile.FindOneAndReplaceAsync(Builders<VendorProfile>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(VendorProfile entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.VendorProfile.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
