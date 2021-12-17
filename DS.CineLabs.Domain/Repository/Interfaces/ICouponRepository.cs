using DS.CineLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Domain.Repository.Interfaces
{
    public interface ICouponRepository
    {
        void CreateCoupon(Coupon coupon);
        Task<IEnumerable<Coupon>> GetAll();
        Task<Coupon> GetById(Guid id);
        void UpdateCoupon(Coupon coupon);
    }
}
