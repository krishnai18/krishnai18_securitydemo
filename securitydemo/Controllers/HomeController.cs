using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDemo2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SecurityDemo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<MyIdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<MyIdentityUser>_userManager)
        {
            _logger = logger;

            userManager = _userManager;

        }

        [Authorize]
        public IActionResult Index()
        {
            MyIdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.Message = $"Welcome {user.FullName}!";

            if(userManager.IsInRoleAsync(user,"NormalUser").Result)
            {
                ViewBag.RoleMessage = "You are an NormalUser.";
            }
            return View();
        }

        [Authorize(Roles ="admin")]

        public IActionResult OnlyAdminAccess()
        {
            ViewBag.role = "Admin";
            MyIdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.Message = $"Welcome {user.FullName}!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
