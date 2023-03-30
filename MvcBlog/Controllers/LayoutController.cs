using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult _BlogLayout()
        {
            return View();
        }

        public ActionResult PartialHeader()
        {
            return PartialView();
        }

        public ActionResult PartialNavbar()
        {
            return PartialView();
        }

        public ActionResult PartialFooter()
        {
            return PartialView();
        }

        public ActionResult PartialScript()
        {
            return PartialView();
        }
    }
}