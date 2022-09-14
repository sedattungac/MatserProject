using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var values = contactManager.TGetList().OrderByDescending(x => x.ContactId);
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var valueId = contactManager.TGetById(id);
            contactManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
