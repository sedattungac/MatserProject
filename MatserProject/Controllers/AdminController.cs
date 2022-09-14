using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IActionResult Index()
        {
            var value = adminManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Admin admin)
        {
            AdminValidator validations = new AdminValidator();
            ValidationResult result = validations.Validate(admin);
            if (result.IsValid)
            {
                adminManager.TAdd(admin);
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
            var admin = adminManager.TGetById(id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            AdminValidator validations = new AdminValidator();
            ValidationResult result = validations.Validate(admin);
            if (result.IsValid)
            {
                adminManager.TUpdate(admin);
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
            var valueId = adminManager.TGetById(id);
            adminManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
