using Rating_Comment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rating_Comment.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(tbl_user model)
        {
            using (var context = new SampleEntities())
            {
                bool isValid = context.tbl_user.Any(x => x.name == model.name && x.password == model.password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.name, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid User Email and Password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}