using AutoMapper;
using DS.CineLabs.Application.Dtos.MovieDetails;
using DS.CineLabs.Application.Services.MovieDetails;
using DS.CineLabs.Common.Models.MovieDetails;
using DS.CineLabs.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace DS.CineLabs.UI.Controllers
{
    [Authorize(Roles = RolesModel.AdminRole)]
    public class MovieDetailsController : Controller
    {
        private readonly IMovieDetailsService service;
        private readonly IMapper _mapper;

        public MovieDetailsController(IMovieDetailsService service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;
        }

        [HttpGet]
        [Route("MovieDetails")]
        public async Task<IActionResult> GetAllMovieDetails(int? page)
        {
            var moviedetails = await service.GetMovieDetails();
            var model = _mapper.Map<IEnumerable<GetMovieDetailsModel>>(moviedetails);
            return View(model.ToPagedList(page ?? 1,5));
        }

        [HttpGet]
        [Route("MovieDetails/Create")]
        public IActionResult CreateMovieDetails()
        {
            return View(new CreateMovieDetailsModel());
        }

        [HttpPost]
        public IActionResult CreateMovieDetailsModel(CreateMovieDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                var details = _mapper.Map<CreateMovieDetailsDto>(model);
                service.Create(details);
                return RedirectToAction("GetAllMovieDetails");
            }
            return View("CreateMovieDetails");
        }

        [HttpGet]
        [Route("MovieDetails/Delete/{id}")]
        public async Task<IActionResult> DeleteMovieDetailsById(int id)
        {
            var details = await service.GetMovieDetailsById(id);
            var Returnedmodel = _mapper.Map<GetMovieDetailsModel>(details);
            return View(Returnedmodel);
        }

        [HttpPost]
        public IActionResult DeleteMovieDetailsByIdPost(int id)
        {
            service.Delete(id);
            return RedirectToAction("GetAllMovieDetails");
        }

        [HttpGet]
        [Route("MovieDetails/Edit/{id}")]
        public async Task<IActionResult> UpdateMovieDetailsById(int id)
        {
            var details = await service.GetMovieDetailsById(id);
            var model = _mapper.Map<UpdateMovieDetailsModel>(details);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateMovieDetailsModel(UpdateMovieDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedMovieDetail = _mapper.Map<UpdateMovieDetailsDto>(model);
                service.Update(updatedMovieDetail);
                return RedirectToAction("GetAllMovieDetails");
            }
           return View("UpdateMovieDetailsById");
        }
    }
}
