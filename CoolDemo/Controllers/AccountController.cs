using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolDemo.Models;
using CoolDemo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoolDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager <ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>signInManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
              
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(CreateUserViewModel createUser)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    UserName = createUser.UserName,
                    Email = createUser.Email,
                };

                var createResult = await _userManager.CreateAsync(newUser, createUser.Password);
                if (!createResult.Succeeded)
                    return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user == null)
                    return BadRequest();
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
                if (!result.Succeeded)
                    return BadRequest();
                return RedirectToAction("Index", "Home");

            }
            return BadRequest();
        }

    }
}