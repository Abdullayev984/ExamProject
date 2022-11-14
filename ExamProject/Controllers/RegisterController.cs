using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.UserDTOs;
using ExamProject.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {





        private readonly UserManager<AppUser> _userManager;


        public RegisterController(
            UserManager<AppUser> userManager

           )
        {
            _userManager = userManager;


        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            UserValidatior validationRules = new UserValidatior();
            ValidationResult results = validationRules.Validate(model);


            if (results.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                
                    return RedirectToAction("Index", "Login");
               
                }

                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }


                }

            
            return View();
        }



    }
}

