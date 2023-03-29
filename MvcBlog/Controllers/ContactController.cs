using MvcBlog.Models;
using MvcBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ContactController : Controller
    {
        
        ContactRepository repository = new ContactRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = repository.GetById(x => x.ContactId == id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DetailContact(int id)
        {
            var value = repository.GetById(x => x.ContactId == id);
            return View(value);
        }

        [HttpGet]
        public PartialViewResult AddContact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddContact(TblContact tblContact)
        {
            repository.Add(tblContact);
            return PartialView();
        }
    }
}