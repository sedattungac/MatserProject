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
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        Context context = new Context();

        public IActionResult Index()
        {
            var value = blogManager.GetBlogWithBlogCategory().OrderByDescending(x => x.BlogCategoryId);
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.BlogCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.BlogCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogViewModel blogViewModel, Blog blog)
        {
            BlogValidator validations = new BlogValidator();
            ValidationResult result = validations.Validate(blog);
            if (result.IsValid)
            {
                Blog p = new Blog();
                if (blogViewModel.ImageUrl != null)
                {
                    var extension = Path.GetExtension(blogViewModel.ImageUrl.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    blogViewModel.ImageUrl.CopyTo(stream);
                    p.ImageUrl = "/Images/Blog/" + newimagename;
                }
                p.Title = blog.Title;
                p.Description = blogViewModel.Description;
                p.Description2 = blogViewModel.Description2;
                p.BlogCategoryId = blogViewModel.BlogCategoryId;
                blogManager.TAdd(p);
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
            List<SelectListItem> category = (from x in context.BlogCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.BlogCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            var values = blogManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Blog blog, BlogViewModel viewModel)
        {
            var blogValue = context.Blogs.Find(blog.BlogId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blog", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                blog.ImageUrl = "/Images/Blog/" + newimagename;
                blog.CreateDate = DateTime.Now;
                blogManager.TUpdate(blog);
                return RedirectToAction("Index");

            }
            else
            {
                blogValue.Title = blog.Title;
                blogValue.Description = blog.Description;
                blogValue.Description2 = blog.Description2;
                blog.CreateDate = DateTime.Now;
                //context.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index");

            }

        }
        public IActionResult Delete(int id)
        {
            var valueId = blogManager.TGetById(id);
            blogManager.TDelete(valueId);
            //System.IO.File.Delete("wwwroot/" + valueId.ImageUrl);
            return RedirectToAction("Index");
        }
    }
}
