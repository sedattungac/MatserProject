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
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
        public IActionResult Index()
        {
            var value = departmentManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            DepartmentValidator validations = new DepartmentValidator();
            ValidationResult result = validations.Validate(department);
            if (result.IsValid)
            {
                departmentManager.TAdd(department);
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
            var value = departmentManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            DepartmentValidator validations = new DepartmentValidator();
            ValidationResult result = validations.Validate(department);
            if (result.IsValid)
            {
                departmentManager.TUpdate(department);
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
            var valueId = departmentManager.TGetById(id);
            departmentManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
