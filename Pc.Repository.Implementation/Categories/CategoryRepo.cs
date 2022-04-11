using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Category;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Categories
{
    public class CategoryRepo : BaseMongoRepository, ICategoryRepo
    {
        public CategoryRepo(IMarketplacePlantConnection conn) : base(conn) { }

        public async Task<List<Category>> GetAllWithSubCategory()
        {
            var data = await Db.Category.Find(c => c.Status)
                .SortByDescending(s => s.Id)
                .ToListAsync();

            foreach (var item in data)
            {
                item.SubCategory = item.SubCategory.Where(x => x.Status).ToList();
            }

            return data;
        }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.Category.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.Category.DeleteManyAsync(FilterDefinition<Category>.Empty);
        }

        public Task<List<Category>> GetAll()
        {
            return Db.Category.Find(FilterDefinition<Category>.Empty).ToListAsync();
        }

        public Task<Category> GetById(string id)
        {
            return Db.Category.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(Category entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();

            return Db.Category.InsertOneAsync(entity);
        }

        public Task Update(Category entity)
        {
            return Db.Category.FindOneAndReplaceAsync(Builders<Category>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(Category entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            return Db.Category.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        public bool IsNameExist(string name)
        {
            var filter = Builders<Category>.Filter.Regex(c => c.Name, "/" + name + "/i");

            return Db.Category.Find(filter).Any();
        }
    }
}
