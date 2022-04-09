using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.News;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.News
{
    public class NewsLetterRepository : BaseMongoRepository, INewsLetterRepository
    {
        public NewsLetterRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.NewsLetter.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.NewsLetter.DeleteManyAsync(FilterDefinition<NewsLetter>.Empty);
        }

        public Task<List<NewsLetter>> GetAll()
        {
            return Db.NewsLetter.Find(FilterDefinition<NewsLetter>.Empty).ToListAsync();
        }

        public Task<NewsLetter> GetById(string id)
        {
            return Db.NewsLetter.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(NewsLetter entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.NewsLetter.InsertOneAsync(entity);
        }

        public Task Update(NewsLetter entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.NewsLetter.FindOneAndReplaceAsync(Builders<NewsLetter>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(NewsLetter entity)
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

            return Db.NewsLetter.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
