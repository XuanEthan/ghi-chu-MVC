using BaoCao1.Models;
using BaoCao1.Services.Base;
using BaoCao1.Services.Repos;
using DevExpress.CodeParser;
using Microsoft.AspNetCore.Mvc;

namespace BaoCao1.Controllers
{
    public class AccountsController : Controller
    {
        private IUserService _userService;
        private readonly ILogger<AccountsController> _logger;
        public AccountsController(IUserService userService , ILogger<AccountsController> logger)
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
        public async Task<IActionResult> Login(User_RegisterModel user_Register)
        {
            var result = await _userService.Login(user_Register);
            if (result.IsSuccess)
            {
                UserContext.setUserId((long)result.Id!, HttpContext);
            }
            return Json(result);
        }

        [HttpPost]
        [Route("/Accounts/Register")]
        public async Task<IActionResult> Register(User_RegisterModel user_Register)
        {
            _logger.LogInformation(user_Register.UserName + user_Register.Password + "ok");
            var result = await _userService.Register(user_Register);
            if (result.IsSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }
    }
}
