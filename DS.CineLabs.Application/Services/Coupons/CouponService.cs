using AutoMapper;
using DS.CineLabs.Application.Dtos.Coupon;
using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net.Mail;

namespace DS.CineLabs.Application.Services.Coupons
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accesor;
        public CouponService(ICouponRepository repository, IMapper mapper,IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accesor = accessor;
        }
        public void CreateCoupon(CreateCouponDto couponDto)
        {
            var coupon = _mapper.Map<Coupon>(couponDto);
            _repository.CreateCoupon(coupon);
        }

        public async Task<IEnumerable<GetCouponDto>> GetAll()
        {
            var coupons = await _repository.GetAll();
            return _mapper.Map<IEnumerable<GetCouponDto>>(coupons);
        }

        public async Task<GetCouponDto> GetCouponById(Guid id)
        {
            var coupon = await _repository.GetById(id);
            return _mapper.Map<GetCouponDto>(coupon);
        }

        public void UpdateCoupon(UpdateCouponDto couponDto)
        {
            var updatedCoupon = _mapper.Map<Coupon>(couponDto);
            _repository.UpdateCoupon(updatedCoupon);
        }
    }
}
