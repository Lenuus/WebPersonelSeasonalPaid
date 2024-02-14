using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPersonelSeasonalPaid.Application.PaidSystem;
using WebPersonelSeasonalPaid.Models;
using WebPersonelSeasonalPaid.Domain;

namespace WebPersonelSeasonalPaid.Controllers
{
    public class PaidSystemController : Controller
    {
        private readonly IPaidSystemService _paidSystem;
        private object _dbContext;

        public PaidSystemController(IPaidSystemService paidSystem)
        {
            _paidSystem = paidSystem;
        }
        public async Task<IActionResult> Index()
        {
            var Personels = await _paidSystem.GetPersonList().ConfigureAwait(false);
            return View(Personels);
        }
        public async Task<IActionResult> Season()
        {
            var Seasons=await _paidSystem.GetSeasonList().ConfigureAwait(false);    
            return View(Seasons);
        }

        public async Task<IActionResult> AddPerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonRequest request)
        {
            var response = await _paidSystem.AddPersonel(new Application.PaidSystem.Dtos.AddPersonelDto
            {
                Name = request.Name,
                Surname = request.Surname,
                StartDate = request.StartDate,
                Salary = request.Salary,
                Prim = request.Prim,
                TC = request.TC,
            });
            return View(request);
        }

        public async Task<IActionResult> AddSeason()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeason(AddSeason request)
        {
            var response = await _paidSystem.AddSeason(new Application.PaidSystem.Dtos.AddSeasonDto
            {
                SeasonStartDate = request.SeasonStartDate,
                SeasonEndDate = request.SeasonEndDate,
                SeasonName = request.SeasonName,

            }).ConfigureAwait(false);
            return View(request);
        }
    }
}
