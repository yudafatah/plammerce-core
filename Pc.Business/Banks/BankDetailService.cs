using Pc.Business.Interfaces.Banks;
using Pc.Core.Entities;
using Pc.Repository.Interface.Bank;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Business.Banks
{
    public class BankDetailService : IBankDetailService
    {
        private readonly IBankDetailRepo _bankDetailRepository;
        public BankDetailService(IBankDetailRepo bankDetailRepository)
        {
            _bankDetailRepository = bankDetailRepository;
        }

        public Task Create(BankDetail bankDetail)
        {
            return _bankDetailRepository.Insert(bankDetail);
        }

        public Task Delete(string id)
        {
            return _bankDetailRepository.Delete(id);
        }

        public Task<BankDetail> Details(string id)
        {
            return _bankDetailRepository.GetById(id);
        }

        public Task Edit(BankDetail bankDetail)
        {
            return _bankDetailRepository.Update(bankDetail);
        }

        public List<BankDetail> List()
        {
            return _bankDetailRepository.GetAll().Result?.OrderByDescending(x => x.Id).ToList();
        }
        public Task<List<BankDetail>> GetAllDetail(int roleId, string vendorId)
        {
            return _bankDetailRepository.GetAllDetail(roleId, vendorId);
        }
        public bool SearchForVendorId(string vendorId)
        {
            return _bankDetailRepository.IsVendorIdExist(vendorId);
        }
    }
}
