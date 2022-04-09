using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Coupons
{
    public interface ICouponRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Coupon>> GetAll();
        Task<Coupon> GetById(string id);
        Task Insert(Coupon entity);
        Task Update(Coupon entity);
        Task Upsert(Coupon entity);
    }
}
