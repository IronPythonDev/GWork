using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace GameFreelance.Web.Utils
{
    public static class AuthUtils
    {
        public static async Task Authenticate( string login , HttpContext httpContext)
        {
            List<Claim> claims= new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType , login)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims , "ApplicationCookie" , ClaimsIdentity.DefaultNameClaimType , ClaimsIdentity.DefaultRoleClaimType );
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        
        public static async Task Logout(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}