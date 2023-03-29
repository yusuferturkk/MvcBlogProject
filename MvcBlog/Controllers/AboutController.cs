using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AboutController : Controller
    {
        
        AboutRepository aboutRepository = new AboutRepository();

        public ActionResult Index()
        {
            var values = aboutRepository.GetList();
            return View(values);
        }
    }
}