using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
using GameFreelance.Infrastructure.Data.Context;
using GameFreelance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Web.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ResumeContext _resumeContext;
        private readonly UserContext _userContext;

        public ResumeController(ResumeContext resumeContext , UserContext userContext)
        {
            _resumeContext = resumeContext;
            _userContext = userContext;

        }
        // GET
        public async Task<IActionResult> Index()
        {
            List<ResumeModel> resumeModels = await _resumeContext.Resumes.ToListAsync();
            return View(resumeModels);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ResumeRequestModel requestModel)
        {
            var ownerId = 
                await _userContext.Users.FirstOrDefaultAsync(user => user.Login == HttpContext.User.Identity.Name);
            await _resumeContext.Resumes.AddAsync(new ResumeModel()
            {
                OwnerId = ownerId.Id , 
                Salary = requestModel.Salary , 
                Experience = requestModel.Experience , 
                Category = requestModel.Category ,
                Position = requestModel.Position ,
                ExperienceText = requestModel.ExperienceText , 
                Attainment = requestModel.Attainment
            });
            await _resumeContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}