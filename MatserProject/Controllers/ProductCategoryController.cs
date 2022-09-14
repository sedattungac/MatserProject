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
    public class ProductCategoryController : Controller
    {
        ProductCategoryManager productCategoryManager = new ProductCategoryManager(new EfProductCategoryDal());
        public IActionResult Index()
        {
            var value = productCategoryManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductCategory productCategory)
        {
            ProductCategoryValidator validations = new ProductCategoryValidator();
            ValidationResult result = validations.Validate(productCategory);
            if (result.IsValid)
            {
                productCategoryManager.TAdd(productCategory);
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
            var value = productCategoryManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(ProductCategory productCategory)
        {
            ProductCategoryValidator validations = new ProductCategoryValidator();
            ValidationResult result = validations.Validate(productCategory);
            if (result.IsValid)
            {
                productCategoryManager.TUpdate(productCategory);
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
            var getId = productCategoryManager.TGetById(id);
            productCategoryManager.TDelete(getId);
            return RedirectToAction("Index");
        }
    }
}
