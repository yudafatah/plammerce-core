using Pc.Business.Interfaces.Coupons;
using Pc.Core.Entities;
using Pc.Repository.Interface.Coupons;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pc.Business.Coupons
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public Task<Coupon> ByCouponCode(string couponCode)
        {
            return _couponRepository.ByCouponCode(couponCode);
        }

        public Task Create(Coupon coupon)
        {
            return _couponRepository.Insert(coupon);
        }

        public Task Delete(string id)
        {
            return _couponRepository.Delete(id);
        }

        public Task<Coupon> Details(string id)
        {
            return _couponRepository.GetById(id);
        }

        public Task Edit(Coupon coupon)
        {
            return _couponRepository.Update(coupon);
        }

        public List<Coupon> List()
        {
            return _couponRepository.GetAll().Result.OrderByDescending(x => x.Id).ToList();
        }
        public bool SearchForName(string name)
        {
            return _couponRepository.IsNameExist(name);
        }
    }
}
