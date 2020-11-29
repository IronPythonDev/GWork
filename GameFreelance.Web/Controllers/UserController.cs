using System;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
using GameFreelance.Infrastructure.Data.Context;
using GameFreelance.Web.Models;
using GameFreelance.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _userContext;
        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserModel user = await _userContext.Users.FirstOrDefaultAsync(u => u.Login == HttpContext.User.Identity.Name);

            return View(user);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(RegisterRequestModel model)
        {
            UserModel user = model.ConvertToUserModel();
            _userContext.Users.Update(user);
            await _userContext.SaveChangesAsync();
            await AuthUtils.Authenticate(user.Login, HttpContext);
            return View("Index" , user);
        }
    }
}