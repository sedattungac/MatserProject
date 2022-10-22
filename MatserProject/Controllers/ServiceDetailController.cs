using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class ServiceDetailController : Controller
    {
        Context context = new Context();
        public IActionResult List(int id)
        {
            var value = context.ServiceDetails.Include(x => x.Service).Where(x => x.ServiceId == id).OrderByDescending(x => x.ServiceDetailId).ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.Services.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ServiceId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Add(ServiceDetail serviceDetail)
        {
            context.ServiceDetails.Add(serviceDetail);
            context.SaveChanges();
            return RedirectToAction("Index", "Service");
        }

        public IActionResult Delete(int id)
        {
            var valueId = context.ServiceDetails.Where(x => x.ServiceDetailId == id).FirstOrDefault();
            context.ServiceDetails.Remove(valueId);
            context.SaveChanges();
            return RedirectToAction("Index","Service");

        }
    }
}
