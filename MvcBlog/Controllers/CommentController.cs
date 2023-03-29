using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class CommentController : Controller
    {
        
        CommentRepository repository = new CommentRepository();
        BlogRepository blogRepository = new BlogRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddComment()
        {
            List<SelectListItem> blogs = (from x in blogRepository.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.BlogTitle,
                                                   Value = x.BlogId.ToString()
                                               }).ToList();
            ViewBag.Blogs = blogs;

            return View();
        }

        [HttpPost]
        public ActionResult AddComment(TblComment tblComment)
        {
            repository.Add(tblComment);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteComment(int id)
        {
            var value = repository.GetById(x => x.BlogId == id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateComment(int id)
        {
            var value = repository.GetById(x => x.BlogId == id);

            List<SelectListItem> blogs = (from x in blogRepository.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.BlogTitle,
                                              Value = x.BlogId.ToString()
                                          }).ToList();
            ViewBag.Blogs = blogs;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateComment(TblComment tblComment)
        {
            repository.Update(tblComment);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult DoComment(int id)
        {
            ViewBag.BlogId = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult DoComment(TblComment tblComment)
        {
            repository.Add(tblComment);
            return PartialView();
        }
    }
}