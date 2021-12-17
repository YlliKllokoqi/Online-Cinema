using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Infrastructure.Persistence.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CinelabsDbContext _db;
        public CouponRepository(CinelabsDbContext db)
        {
            _db = db;
        }
        public void CreateCoupon(Coupon coupon)
        {
            _db.Coupon.Add(coupon);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Coupon>> GetAll()
        {
            return await _db.Coupon
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Movie)
                .ToListAsync();
        }

        public async Task<Coupon> GetById(Guid id)
        {
            return await _db.Coupon
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateCoupon(Coupon coupon)
        {
            _db.Coupon.Update(coupon);
            _db.SaveChanges();
        }
    }
}
