using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MatserProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var value = serviceManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Service service, ServiceViewModel serviceViewModel)
        {
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);
            if (result.IsValid)
            {
                Service p = new Service();
                if (serviceViewModel.ImageUrl != null)
                {
                    var extension = Path.GetExtension(serviceViewModel.ImageUrl.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Service", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    serviceViewModel.ImageUrl.CopyTo(stream);
                    p.ImageUrl = "/Images/Service/" + newimagename;
                }
                p.Title = serviceViewModel.Title;
                p.Description = serviceViewModel.Description;
                p.Icon = serviceViewModel.Icon;
                serviceManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = serviceManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Service service, ServiceViewModel viewModel)
        {
            Context c = new Context();
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);
            var serviceValue = c.Services.Find(service.ServiceId);

            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageServices/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                service.ImageUrl = "/Images/Service/" + newimagename;
                serviceManager.TUpdate(service);
                return RedirectToAction("Index");
            }
            else
            {
                serviceValue.Title = service.Title;
                serviceValue.Description = service.Description;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            var valueId = serviceManager.TGetById(id);
            serviceManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
