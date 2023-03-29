using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class CategoryController : Controller
    {

        CategoryRepository repository = new CategoryRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory tblCategory)
        {
            repository.Add(tblCategory);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = repository.GetById(x => x.CategoryId == id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = repository.GetById(x => x.CategoryId == id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory tblCategory)
        {
            repository.Update(tblCategory);
            return RedirectToAction("Index");
        }
    }
}