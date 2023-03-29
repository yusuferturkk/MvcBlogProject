using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class TypeController : Controller
    {

        TypeRepository repository = new TypeRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddType(TblType tblType)
        {
            repository.Add(tblType);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteType(int id)
        {
            var value = repository.GetById(x => x.TypeId == id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateType(int id)
        {
            var value = repository.GetById(x => x.TypeId == id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateType(TblType tblType)
        {
            var value = repository.GetById(x => x.TypeId == tblType.TypeId);
            value.TypeName = tblType.TypeName;
            repository.Update(value);
            return RedirectToAction("Index");
        }
    }
}