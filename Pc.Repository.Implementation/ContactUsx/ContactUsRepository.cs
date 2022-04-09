using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.ContactUsx;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.ContactUsx
{
    public class ContactUsRepository : BaseMongoRepository, IContactUsRepository
    {
        public ContactUsRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.ContactUs.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.ContactUs.DeleteManyAsync(FilterDefinition<ContactUs>.Empty);
        }

        public Task<List<ContactUs>> GetAll()
        {
            return Db.ContactUs.Find(FilterDefinition<ContactUs>.Empty).ToListAsync();
        }

        public Task<ContactUs> GetById(string id)
        {
            return Db.ContactUs.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(ContactUs entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.ContactUs.InsertOneAsync(entity);
        }

        public Task Update(ContactUs entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.ContactUs.FindOneAndReplaceAsync(Builders<ContactUs>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(ContactUs entity)
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

            return Db.ContactUs.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
