using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Business.Interfaces.Banks
{
    public interface IBankDetailService
    {
        Task Create(BankDetail bankDetail);
        Task Delete(string id);
        Task<BankDetail> Details(string id);
        Task Edit(BankDetail bankDetail);
        List<BankDetail> List();
        Task<List<BankDetail>> GetAllDetail(int roleId, string vendorId);
        bool SearchForVendorId(string vendorId);
    }
}
