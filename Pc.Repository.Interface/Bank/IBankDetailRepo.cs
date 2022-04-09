using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Bank
{
    public interface IBankDetailRepo
    {
        Task<List<BankDetail>> GetAllDetail(int roleId, string vendorId);
        Task Delete(string id);
        Task DeleteAll();
        Task<List<BankDetail>> GetAll();
        Task<BankDetail> GetById(string id);
        Task Insert(BankDetail entity);
        Task Update(BankDetail entity);
        Task Upsert(BankDetail entity);
        bool IsVendorIdExist(string id);
    }
}
