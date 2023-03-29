using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        DbBlogEntities db = new DbBlogEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin tblAdmin)
        {
            var value = db.TblAdmin.FirstOrDefault(x => x.Username == tblAdmin.Username && x.Password == tblAdmin.Password);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = value.Username.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.errorMessage = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}