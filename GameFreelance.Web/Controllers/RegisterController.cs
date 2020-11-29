using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
using GameFreelance.Infrastructure.Data.Context;
using GameFreelance.Web.Models;
using GameFreelance.Web.Utils;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserContext _userContext;
        public RegisterController(UserContext userContext)
        {
            this._userContext = userContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequestModel requestModel)
        {
            UserModel user = await _userContext.Users.FirstOrDefaultAsync(u =>
                u.Login == requestModel.Login && PasswordUtils.GetHashPassword(requestModel.Password).Equals(u.Password));
            
            if (user != null)
            {
                return RedirectToAction("Index" , "Home");
            }

            var newUser = await _userContext.Users.AddAsync(requestModel.ConvertToUserModel());
            await _userContext.SaveChangesAsync();
            
            if (requestModel.IsRememberUser)
            {
                await AuthUtils.Authenticate(newUser.Entity.Login , HttpContext);
            }
            
            return RedirectToAction("Index" , "Home");
        }
    }
}
