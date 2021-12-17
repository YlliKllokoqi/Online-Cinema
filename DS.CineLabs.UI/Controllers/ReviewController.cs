using AutoMapper;
using DS.CineLabs.Application.Dtos.Review;
using DS.CineLabs.Application.Services.Movies;
using DS.CineLabs.Application.Services.Reviews;
using DS.CineLabs.Common.Models.Review;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace DS.CineLabs.UI.Controllers
{
    [Authorize(Roles = RolesModel.AdminRole)]
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        private readonly IMapper _mapper;
        public ReviewController(IReviewService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Review")]
        public async Task<IActionResult> GetAllReviews(int? page)
        {
            var reviews = await _service.GetAllReviews();
            var model = _mapper.Map<IEnumerable<GetReviewModel>>(reviews);
            return View(model.ToPagedList(page ?? 1, 2));

        }


        [HttpGet]
        [Route("Review/Delete/{id}")]
        public async Task<IActionResult> DeleteReviewById(int id)
        {
            var review = await _service.GetReviewById(id);
            var modelToReturn = _mapper.Map<GetReviewModel>(review);
            return View(modelToReturn);
        }

        [HttpPost]
        public IActionResult DeleteReviewByIdPost(int id)
        {
            _service.DeleteReview(id);
            return RedirectToAction("GetAllReviews");
        }

    }
}
