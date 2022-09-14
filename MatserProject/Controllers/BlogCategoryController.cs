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
    public class BlogCategoryController : Controller
    {
        BlogCategoryManager blogCategoryManager = new BlogCategoryManager(new EfBlogCategoryDal());
        public IActionResult Index()
        {
            var value = blogCategoryManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogCategory blogCategory)
        {
            BlogCategoryValidator validations = new BlogCategoryValidator();
            ValidationResult result = validations.Validate(blogCategory);
            if (result.IsValid)
            {
                blogCategoryManager.TAdd(blogCategory);
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
            var value = blogCategoryManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(BlogCategory blogCategory)
        {
            BlogCategoryValidator validations = new BlogCategoryValidator();
            ValidationResult result = validations.Validate(blogCategory);
            if (result.IsValid)
            {
                blogCategoryManager.TUpdate(blogCategory);
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
            var getId = blogCategoryManager.TGetById(id);
            blogCategoryManager.TDelete(getId);
            return RedirectToAction("Index");
        }
    }
}
