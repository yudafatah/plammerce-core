using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Mails;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Mails
{
    public class MailSettingRepository : BaseMongoRepository, IMailSettingRepository
    {
        public MailSettingRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.MailSetting.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.MailSetting.DeleteManyAsync(FilterDefinition<MailSetting>.Empty);
        }

        public Task<List<MailSetting>> GetAll()
        {
            return Db.MailSetting.Find(FilterDefinition<MailSetting>.Empty).ToListAsync();
        }

        public Task<MailSetting> GetById(string id)
        {
            return Db.MailSetting.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(MailSetting entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.MailSetting.InsertOneAsync(entity);
        }

        public Task Update(MailSetting entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.MailSetting.FindOneAndReplaceAsync(Builders<MailSetting>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(MailSetting entity)
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

            return Db.MailSetting.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
