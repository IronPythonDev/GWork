using System;
using System.Linq;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
using GameFreelance.Infrastructure.Data.Context;
using GameFreelance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Web.Controllers
{
    public class VacancyController : Controller
    {
        private readonly VacancyContext _vacancyContext;
        private readonly UserContext _userContext;
        public VacancyController(VacancyContext vacancyContext , UserContext userContext)
        {
            _vacancyContext = vacancyContext;
            _userContext = userContext;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _vacancyContext.Vacancies.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VacancyRequestModel model)
        {
            var ownerId =
                await _userContext.Users.FirstOrDefaultAsync(user => user.Login == HttpContext.User.Identity.Name);
            await _vacancyContext.Vacancies.AddAsync(new VacancyModel
            {
                OwnerId = ownerId.Id, VacancyName = model.VacancyName, Description = model.Description,
                Experience = model.Experience, Category = model.Category
            });
            await _vacancyContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}