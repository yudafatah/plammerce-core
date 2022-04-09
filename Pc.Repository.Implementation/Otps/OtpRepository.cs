using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Otps;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Otps
{
    public class OtpRepository : BaseMongoRepository, IOtpRepository
    {
        public OtpRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Otp.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Otp.DeleteManyAsync(FilterDefinition<Otp>.Empty);
        }

        public Task<List<Otp>> GetAll()
        {
            return Db.Otp.Find(FilterDefinition<Otp>.Empty).ToListAsync();
        }

        public Task<Otp> GetById(string id)
        {
            return Db.Otp.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Otp entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.Otp.InsertOneAsync(entity);
        }

        public Task Update(Otp entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.Otp.FindOneAndReplaceAsync(Builders<Otp>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Otp entity)
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

            return Db.Otp.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
