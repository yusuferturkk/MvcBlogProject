using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AdminController : Controller
    {

        GenericRepository<TblAdmin> repository = new GenericRepository<TblAdmin> ();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(TblAdmin tblAdmin)
        {
            repository.Add(tblAdmin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = repository.GetById(x => x.AdminId == id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = repository.GetById(x => x.AdminId == id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin tblAdmin)
        {
            repository.Update(tblAdmin);
            return RedirectToAction("Index");
        }
    }
}