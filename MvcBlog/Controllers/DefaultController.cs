using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        BlogRepository blogRepository = new BlogRepository();
        AboutRepository aboutRepository = new AboutRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        CommentRepository commentRepository = new CommentRepository();

        public ActionResult Index()
        {
            var values = blogRepository.GetList();
            return View(values);
        }

        public ActionResult About()
        {
            var values = aboutRepository.GetList();
            return View(values);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult PartialComment(int id)
        {
            var values = commentRepository.GetList(x => x.BlogId == id);

            ViewBag.totalComment = commentRepository.GetList().Where(x => x.BlogId == id).Count();

            return PartialView(values);
        }

        public PartialViewResult PartialRecentPost()
        {
            var values = blogRepository.GetList();

            return PartialView(values);
        }

        public PartialViewResult PartialRecentComment()
        {
            var values = commentRepository.GetList();
            return PartialView(values);
        }

        public PartialViewResult PartialCategories()
        {
            var values = categoryRepository.GetList();
            return PartialView(values);
        }
    }
}