using Cibertec.Mvc2.Models;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IUnitOfWork _unit = new NorthwindUnitOfWork(
            ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new UserViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var validUser = _unit.Users.ValidateUser(user.Email, user.Password);
            if (validUser == null)
            {
                ModelState.AddModelError("Error", "Email o contraseña invalida");
                return View(user);
            }

            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, validUser.Email),
                new Claim(ClaimTypes.Role, validUser.Roles),
                new Claim(ClaimTypes.Name, $"{validUser.FirstName} {validUser.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, validUser.Id.ToString())
            }, "ApplicationCookie");

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignIn(identity);
            return RedirectToLocal(user.ReturnUrl);
        }

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}