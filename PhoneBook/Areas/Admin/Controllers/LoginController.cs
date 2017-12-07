using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PhoneBook.Areas.Admin.Models;
using System.Data.Entity;

namespace PhoneBook.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        PhoneBook.Dal.PhoneBookDbContext context = new Dal.PhoneBookDbContext();
        // GET: Admin/Login
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.User.Identity.Name) == false)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel worker)
        {
            if (!ModelState.IsValid)
            {
                return View(worker);
            }
            else
            {
                string md5sifre = Tools.GetMd5Hash(worker.password);
                var loginuser = context.Workers.FirstOrDefault(x => x.email == worker.email && x.password == md5sifre);
                if (loginuser == null)
                {
                    ViewBag.Message = "Hatalı";
                    return View(worker);
                }
                else
                {
                    var authTicket = new FormsAuthenticationTicket(
                       1,                             // version
                       loginuser.email, // user name
                       DateTime.Now,                  // created
                       DateTime.Now.AddMinutes(20),   // expires
                       false,
                       "Admin"


                       );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "AdminHome", new { area = "Admin" });



                }
            }
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            var worker = context.Workers.FirstOrDefault(x => x.email == User.Identity.Name);
            if (worker == null)
                return RedirectToAction("Index");

            var viewModel = new LoginViewModel();
            viewModel.WorkerId = worker.id;
            viewModel.email = worker.email;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string md5sifre = Tools.GetMd5Hash(viewModel.password);
                var worker = context.Workers.Find(viewModel.WorkerId);
                worker.password = md5sifre;

                context.Workers.Attach(worker);
                context.Entry(worker).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(viewModel);

        }
    }
}