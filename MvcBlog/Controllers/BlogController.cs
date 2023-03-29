using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {

        BlogRepository repository = new BlogRepository();
        TypeRepository typeRepository = new TypeRepository();
        CategoryRepository categoryRepository = new CategoryRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            List<SelectListItem> categories = (from x in categoryRepository.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> types = (from x in typeRepository.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.TypeName,
                                              Value = x.TypeId.ToString()
                                          }).ToList();
            ViewBag.Types = types;
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(TblBlog tblBlog)
        {
            tblBlog.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            repository.Add(tblBlog);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var value = repository.GetById(x => x.BlogId == id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var value = repository.GetById(x => x.BlogId == id);

            List<SelectListItem> categories = (from x in categoryRepository.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> types = (from x in typeRepository.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.TypeName,
                                              Value = x.TypeId.ToString()
                                          }).ToList();
            ViewBag.Types = types;
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBlog(TblBlog tblBlog)
        {
            repository.Update(tblBlog);
            return RedirectToAction("Index");
        }

        public ActionResult BlogDetail(int id)
        {
            var value = repository.GetById(x => x.BlogId == id);
            ViewBag.BlogId = value.BlogId;
            return View(value);
        }
    }
}