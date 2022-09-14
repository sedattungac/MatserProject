using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.ViewComponents.Reference
{
    public class ReferenceList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
