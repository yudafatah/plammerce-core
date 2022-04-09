using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.Core.Enums;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.Bank;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.Bank
{
    public class BankDetailRepo : BaseMongoRepository, IBankDetailRepo
    {
        public BankDetailRepo(IMarketplacePlantConnection conn) : base(conn) { }

        public async Task<List<BankDetail>> GetAllDetail(int roleId, string vendorId)
        {
            if (roleId == 2)
            {
                return await Db.BankDetail.Find(FilterDefinition<BankDetail>.Empty)
                    .SortByDescending(s => s.Id)
                    .ToListAsync();
            }

            return await Db.BankDetail.Find(c => c.VendorId == vendorId && c.Status != (int)BankStatusType.Deleted)
                .SortByDescending(s => s.Id)
                .ToListAsync();
        }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.BankDetail.DeleteOneAsync(x=> x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.BankDetail.DeleteManyAsync(FilterDefinition<BankDetail>.Empty);
        }

        public Task<List<BankDetail>> GetAll()
        {
            return Db.BankDetail.Find(FilterDefinition<BankDetail>.Empty).ToListAsync();
        }

        public Task<BankDetail> GetById(string id)
        {
            return Db.BankDetail.Find(x=> x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(BankDetail entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.BankDetail.InsertOneAsync(entity);
        }

        public Task Update(BankDetail entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.BankDetail.FindOneAndReplaceAsync(Builders<BankDetail>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(BankDetail entity)
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

            return Db.BankDetail.ReplaceOneAsync(x=> x.Id == entity.Id , entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        public bool IsVendorIdExist(string id)
        {
            return Db.BankDetail.Find(x => x.VendorId == id).Any();
        }
    }
}
