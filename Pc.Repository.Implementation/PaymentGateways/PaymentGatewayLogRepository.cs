using MongoDB.Bson;
using MongoDB.Driver;
using Pc.Core.Entities;
using Pc.MDb.Connection;
using Pc.MDb.Connection.Interfaces;
using Pc.Repository.Interface.PaymentGateways;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Implementation.PaymentGateways
{
    public class PaymentGatewayLogRepository : BaseMongoRepository, IPaymentGatewayLogRepository
    {
        public PaymentGatewayLogRepository(IMarketplacePlantConnection conn) : base(conn) { }

        #region BASIC CRUD
        public Task Delete(string id)
        {
            return Db.PaymentGatewayLog.DeleteOneAsync(x => x.Id == id);
        }

        public Task DeleteAll()
        {
            return Db.PaymentGatewayLog.DeleteManyAsync(FilterDefinition<PaymentGatewayLog>.Empty);
        }

        public Task<List<PaymentGatewayLog>> GetAll()
        {
            return Db.PaymentGatewayLog.Find(FilterDefinition<PaymentGatewayLog>.Empty).ToListAsync();
        }

        public Task<PaymentGatewayLog> GetById(string id)
        {
            return Db.PaymentGatewayLog.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Insert(PaymentGatewayLog entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.CreatedDate = DateTime.Now;

            return Db.PaymentGatewayLog.InsertOneAsync(entity);
        }

        public Task Update(PaymentGatewayLog entity)
        {
            entity.UpdatedDate = DateTime.Now;

            return Db.PaymentGatewayLog.FindOneAndReplaceAsync(Builders<PaymentGatewayLog>.Filter.Eq(c => c.Id, entity.Id), entity);
        }

        public Task Upsert(PaymentGatewayLog entity)
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

            return Db.PaymentGatewayLog.ReplaceOneAsync(x => x.Id == entity.Id, entity, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
