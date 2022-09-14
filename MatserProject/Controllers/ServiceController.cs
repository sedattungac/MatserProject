using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Add(Service service)
        {
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);
            if (result.IsValid)
            {
                serviceManager.TAdd(service);
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
        public IActionResult Edit(Service service)
        {
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);
            if (result.IsValid)
            {
                serviceManager.TUpdate(service);
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
        public IActionResult Delete(int id)
        {
            var valueId = serviceManager.TGetById(id);
            serviceManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
