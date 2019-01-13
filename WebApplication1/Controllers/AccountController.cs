using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager) {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index() {
            ViewBag.UserName = User?.Identity?.Name ?? "no data";
            return View();
        }

        [HttpGet]
        public IActionResult SignIn() {
            return View(new SignInViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm]SignInViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null) {
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (result) {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp() {
            return View(new SignUpViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm]SignUpViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = new IdentityUser {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
