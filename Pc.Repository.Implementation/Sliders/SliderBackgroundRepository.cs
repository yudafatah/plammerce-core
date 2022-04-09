using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Sliders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Sliders
{
    public class SliderBackgroundRepository : BaseMongoRepository, ISliderBackgroundRepository
    {
        public SliderBackgroundRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.SliderBackground.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.SliderBackground.DeleteManyAsync(FilterDefinition<SliderBackground>.Empty);
        }

        public Task<List<SliderBackground>> GetAll()
        {
            return Db.SliderBackground.Find(FilterDefinition<SliderBackground>.Empty).ToListAsync();
        }

        public Task<SliderBackground> GetById(string id)
        {
            return Db.SliderBackground.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(SliderBackground entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.SliderBackground.InsertOneAsync(entity);
        }

        public Task Update(SliderBackground entity)
        {
            return Db.SliderBackground.FindOneAndReplaceAsync(Builders<SliderBackground>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(SliderBackground entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.SliderBackground.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
