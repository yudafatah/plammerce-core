using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Business.Interfaces.Coupons
{
    public interface ICouponService
    {
        Task<Coupon> ByCouponCode(string couponCode);
        Task Create(Coupon coupon);
        Task Delete(string id);
        Task<Coupon> Details(string id);
        Task Edit(Coupon coupon);
        List<Coupon> List();
        bool SearchForName(string name);
    }
}
