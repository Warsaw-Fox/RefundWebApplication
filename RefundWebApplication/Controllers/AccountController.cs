using RefundWebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CloudinaryDotNet;


namespace RefundWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        // private readonly IConfiguration configuration;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager/*, IConfiguration configuration*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.configuration = configuration;
        }
        /*   ///powodowao błąd zostawiam to na razie i zdefiniuje inne metody
         [HttpPost("GenerateToken")]   //token JWT na podstawie nazwy użytkownika i hasła.
        public async Task<IActionResult> GenerateToken(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var user = await userManager.FindByNameAsync(loginViewModel.Username);

            if (user == null || !await userManager.CheckPasswordAsync(user, loginViewModel.Password))
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30), //  ważność tokenu
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
         */

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email
                };
                await userManager.CreateAsync(identityUser, registerViewModel.Password);
                await userManager.AddToRoleAsync(identityUser, "Admin");


                // Show success notification
                return RedirectToAction("Register");

            }

            // Show error notification
            return View();
        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username,
                loginViewModel.Password, false, false);

            if (signInResult != null && signInResult.Succeeded)
            {
                if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
                {
                    return Redirect(loginViewModel.ReturnUrl);
                }

                return RedirectToAction("ComplaintList", "ComplaintModels");
            }

            // Show errors
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}