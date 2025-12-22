using BaoCao1.Models;
using BaoCao1.Services.Base;
using BaoCao1.Services.Repos;
using DevExpress.CodeParser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaoCao1.Controllers
{
    public class AccountsController : Controller
    {
        private IUserService _userService;
        private readonly ILogger<AccountsController> _logger;
        public AccountsController(IUserService userService, ILogger<AccountsController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/Accounts/Login")]
        public async Task<IActionResult> Login(User_LoginModel user_Login)
        {
            var result = await _userService.Login(user_Login);
            if (result.IsSuccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user_Login.UserName),
                   new Claim(ClaimTypes.NameIdentifier , result.Id.ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }

            return Json(result);
        }

        [HttpPost]
        [Route("/Accounts/Register")]
        public async Task<IActionResult> Register(User_RegisterModel user_Register)
        {
            var result = await _userService.Register(user_Register);
            if (result.IsSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }


        [Route("/Accounts/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");
        }
    }
}
