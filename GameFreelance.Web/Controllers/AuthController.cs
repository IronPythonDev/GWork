using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
using GameFreelance.Infrastructure.Data.Context;
using GameFreelance.Web.Models;
using GameFreelance.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserContext _userContext;

        public AuthController(UserContext userContext)
        {
            _userContext = userContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userContext.Users.FirstOrDefaultAsync(u =>
                    u.Login == model.Login && PasswordUtils.GetHashPassword(model.Password).Equals(u.Password));
                if (user != null)
                {
                    await AuthUtils.Authenticate(model.Login , HttpContext);

                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("" , "Некорректные логин и(или) пароль");
                
            }

            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await AuthUtils.Logout(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
