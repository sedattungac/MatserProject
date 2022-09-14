using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.ViewComponents.Slider
{
    public class SliderList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
