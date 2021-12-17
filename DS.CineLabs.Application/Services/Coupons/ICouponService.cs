using DS.CineLabs.Application.Dtos.Coupon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Application.Services.Coupons
{
    public interface ICouponService
    {
        void CreateCoupon(CreateCouponDto couponDto);
        Task<GetCouponDto> GetCouponById(Guid id);
        Task<IEnumerable<GetCouponDto>> GetAll();
        void UpdateCoupon(UpdateCouponDto couponDto);
    }
}
