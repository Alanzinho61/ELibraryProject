using ELibraryProject.Core.Service;
using ELibraryProject.Model.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Security.Claims;

namespace ELibraryProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IDbService<User> _user;

        public LoginController(IDbService<User> user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                var account = _user.GetQuery().Where(s => s.UserEmail == email && s.Password == password && s.isEnabled == true).FirstOrDefault();
                if (account==null)
                {
                    TempData["Mesaj"] = "Hata Olustu";
                }
                else
                {
                    var claims=new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, account.Name),
                        new Claim("Role","Admin")
                    };

                    var userIdentity=new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/admin/book");
                }
            }
            catch (Exception)
            {

                TempData["Mesaj"] = "Hata Olustu";
            }
            return View();
        }

    }
}
