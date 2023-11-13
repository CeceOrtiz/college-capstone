using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using D424.Models;

namespace D424.Controllers
#nullable disable
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

               if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        // Add in userID cookie

                        return RedirectToAction("Index", "Dashboard", new {area = "User"});
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid email or password");

            return View();
        }
    }
}
