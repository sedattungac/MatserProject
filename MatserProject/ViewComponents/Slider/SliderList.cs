using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.ViewComponents.Slider
{
    public class SliderList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using Context c = new Context();
            var value = c.Sliders.Where(x=>x.SliderId==1).ToList();
            return View(value);
        }
    }
}
