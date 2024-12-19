using Banking_E_wallet.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Data_Access_Layer.models;
using Banking_E_Wallet.view_model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Data;
using Business_Access_Layer.interfaces;
namespace Banking_E_Wallet.Controllers
{
    public class usercontroller : Controller
    {
        private readonly UserManager<user> _user;
        private readonly SignInManager<user> _signin;
     

        public usercontroller(UserManager<user> user, SignInManager<user> signin)
        {
            _user = user;
            _signin = signin;
           
        }


        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(registerviewmodel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new user
            {
                UserName = model.email,
               
                PasswordHash = model.password,

            };
            var result = _user.CreateAsync(user, model.password).Result;
            if (result.Succeeded)
                return RedirectToAction(nameof(login));
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(loginviewmodel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = _user.FindByEmailAsync(model.email).Result;
            if (user is not null)
            {
                if (_user.CheckPasswordAsync(user, model.password).Result)
                {
                    var result = _signin.PasswordSignInAsync(user, model.password, model.rememberme, false).Result;
                    if (result.Succeeded) return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", string.Empty));
                }

            }
            ModelState.AddModelError(string.Empty, "in valid email or password");
            return View(model);
        }
        

            
    }
}

