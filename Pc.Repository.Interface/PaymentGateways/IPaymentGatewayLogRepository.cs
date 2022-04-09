using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.PaymentGateways
{
    public interface IPaymentGatewayLogRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<PaymentGatewayLog>> GetAll();
        Task<PaymentGatewayLog> GetById(string id);
        Task Insert(PaymentGatewayLog entity);
        Task Update(PaymentGatewayLog entity);
        Task Upsert(PaymentGatewayLog entity);
    }
}
