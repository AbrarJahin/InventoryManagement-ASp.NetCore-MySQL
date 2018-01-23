using System.Threading.Tasks;
using ApplicationManagement.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = _userManager.GetUserAsync
                         (HttpContext.User).Result;

            ViewData["Message"] = $"Welcome {user.FullName}!";

            if (_userManager.IsInRoleAsync(user, "NormalUser").Result)
            {
                ViewData["Message"] = ViewData["Message"]+" You are a NormalUser.";
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Date passed from Controller";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Message passed from Controller";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
