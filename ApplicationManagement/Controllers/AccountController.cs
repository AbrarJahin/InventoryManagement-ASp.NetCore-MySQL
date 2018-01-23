using ApplicationManagement.DbModel;
using ApplicationManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _loginManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context, UserManager<User> userManager,
           SignInManager<User> loginManager,
           RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("LogIn", "Account", new { area = "Admin" });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterView regView)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = regView.UserName;
                user.FullName = regView.FullName;

                IdentityResult result = _userManager.CreateAsync(user, regView.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        UserRole role = new UserRole();
                        role.Name = "NormalUser";
                        role.Description = "Perform normal operations.";
                        IdentityResult roleResult = _roleManager.
                        CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("",
                             "Error while creating role!");
                            return View(regView);
                        }
                    }

                    _userManager.AddToRoleAsync(user,
                                 "NormalUser").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(regView);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LoginView lgnView)
        {
            if (ModelState.IsValid)
            {
                var result = _loginManager.PasswordSignInAsync
                (lgnView.UserName, lgnView.Password,
                  lgnView.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login!");
            }
            return View(lgnView);
        }

        [HttpGet,HttpPost]
        public IActionResult LogOut()
        {
            _loginManager.SignOutAsync().Wait();
            return RedirectToAction("LogIn", "Account");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}