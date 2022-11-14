
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using EntityLayer.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly DatabaseContext _context;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, DatabaseContext context)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Lesson");
                }

                else
                {
                    ViewBag.dgr = "Invalid username or password";
                    return View();
                }

            }

            return View();
        }
       
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult AccessDenied()
        {

            return View();
        }


    }
}