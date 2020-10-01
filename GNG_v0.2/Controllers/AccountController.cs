using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GNG_v0._2.Models;
using GNG_v0._2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GNG_v0._2.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;


        private string fromEmail = "gamengamersregister@gmail.com";
        private string toEmail;
        private string subjectEmail;
        private string bodyEmail;

        private string password = "gngconfirm";

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [HttpGet]
        public ViewResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Name, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                //User newUser = _userRepository.Register(model);

                if(result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var ConfirmationLink = Url.Action("ConfirmEmail", "Account", 
                                                        new { userId = user.Id, token = token }, Request.Scheme);
                   
                    logger.Log(LogLevel.Warning, ConfirmationLink);

                    ViewBag.Title = "Registration successful";
                    ViewBag.Message = "Please confirm your email by clicking on the confirmation link we have emailed you";

                    subjectEmail = "GNG account confirmation";
                    toEmail = user.Email;
                    bodyEmail = "Thank you for your registration, the following link is the account confirmation link." + ConfirmationLink;

                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(fromEmail);
                    mail.To.Add(toEmail);
                    mail.Subject = subjectEmail;
                    mail.Body = bodyEmail;

                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Port = 587;
                    smtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, password) as ICredentialsByHost;
                    smtpServer.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback =
                        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        { return true; };
                    smtpServer.Send(mail);

                    return View("Successful");
                    /*await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "home"); */
                }

                foreach(var error in result.Errors)
                {
                    ViewBag.Message = error.Description;
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail (string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = $"The user ID {userId} is invalid";
                return View("Successful");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                ViewBag.Title = "Confirm email successful";
                ViewBag.Message = "Thank you for confirming the email. You are now redirected to home page";
                //await signInManager.SignInAsync(user, isPersistent: false);
                return View();
            }

            ViewBag.Title = "Error";
            ViewBag.Message = "Email cannot be confirmed";
            return View("Successful");
        }
        [HttpGet]
        public ViewResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var userEmail = await userManager.FindByEmailAsync(loginModel.Email);
                if (userEmail == null)
                {
                    ViewBag.Message = "Email entered is incorrect.";
                    return View(loginModel);
                }
                else if (userEmail != null && userEmail.EmailConfirmed !=true && (await userManager.CheckPasswordAsync(userEmail, loginModel.Password)))
                {
                    ViewBag.Message = "Email entered is not confirmed.";
                    return View(loginModel);
                }

                var result = await signInManager.PasswordSignInAsync(userEmail, loginModel.Password, loginModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }
                ViewBag.Message = "Password entered is incorrect.";

                ModelState.AddModelError("", "Your username or password is not matched.");
            }
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }

        [HttpGet]
        public ViewResult Forgot()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Forgot(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(forgotPasswordViewModel.Forgot_email);
                if(user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = forgotPasswordViewModel.Forgot_email, token = token }, Request.Scheme); ;

                    subjectEmail = "GNG account reset password";
                    toEmail = user.Email;
                    bodyEmail = "The following link will redirect you to reset your password.\n" + passwordResetLink;

                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(fromEmail);
                    mail.To.Add(toEmail);
                    mail.Subject = subjectEmail;
                    mail.Body = bodyEmail;

                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Port = 587;
                    smtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, password) as ICredentialsByHost;
                    smtpServer.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback =
                        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        { return true; };
                    smtpServer.Send(mail);

                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return View("ResetPasswordConfirmation");
                }
                return View("ResetPasswordConfirmation");
            }
            return View();
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult Successful()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if(token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword (ResetPasswordViewModels resetPasswordViewModels)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetPasswordViewModels.Email);

                if(user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModels.Token, resetPasswordViewModels.Password);
                    if(result.Succeeded)
                    {
                        ViewBag.Title = "Reset password successful";
                        ViewBag.Message = "You will be redirected to our homepage.";

                        return View("Successful");
                    }
                    ViewBag.Title = "Reset password failed";
                    ViewBag.Message = "Process failed";
                    return View("Successful");
                }
                return View("ResetPasswordConfirmation");
            }
            return View(resetPasswordViewModels);
        }
    }
}
