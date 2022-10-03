using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MatserProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class SliderController : Controller
    {
        SliderManager slider = new SliderManager(new EfSliderDal());

        [HttpGet]
        public IActionResult Index(int id = 1)
        {
            using Context c = new Context();
            var value = slider.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Slider slider, SliderViewModel sliderViewModel)
        {
            using Context c = new Context();
            var s = c.Sliders.Find(slider.SliderId);

            if (sliderViewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(sliderViewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                sliderViewModel.ImageUrl.CopyTo(stream);
                slider.ImageUrl = "/Images/Slider/" + newimagename;
                s.ImageUrl = slider.ImageUrl;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
