﻿
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MatserProject.Controllers
{
    public class DefaultController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        FaqManager faqManager = new FaqManager(new EfFaqDal());
        PersonalManager personalManager = new PersonalManager(new EfPersonalDal());
        ProductManager productManager = new ProductManager(new EfProductDal());
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            using Context context = new Context();

            //PRODUCT
            //1
            ViewBag.pTitle = context.Products.Where(x => x.ProductId == 1).Select(x => x.Title).FirstOrDefault();
            ViewBag.pId = context.Products.Where(x => x.ProductId == 1).Select(x => x.ProductId).FirstOrDefault();
            ViewBag.pImage = context.Products.Where(x => x.ProductId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.pCategory = context.Products.Where(x => x.ProductId == 1).Select(x => x.ProductCategory.Title).FirstOrDefault();
            //2
            ViewBag.pTitle2 = context.Products.Where(x => x.ProductId == 2).Select(x => x.Title).FirstOrDefault();
            ViewBag.pId2 = context.Products.Where(x => x.ProductId == 2).Select(x => x.ProductId).FirstOrDefault();
            ViewBag.pImage2 = context.Products.Where(x => x.ProductId == 2).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.pCategory2 = context.Products.Where(x => x.ProductId == 2).Select(x => x.ProductCategory.Title).FirstOrDefault();
            //4
            ViewBag.pTitle4 = context.Products.Where(x => x.ProductId == 4).Select(x => x.Title).FirstOrDefault();
            ViewBag.pId4 = context.Products.Where(x => x.ProductId == 4).Select(x => x.ProductId).FirstOrDefault();
            ViewBag.pImage4 = context.Products.Where(x => x.ProductId == 4).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.pCategory4 = context.Products.Where(x => x.ProductId == 4).Select(x => x.ProductCategory.Title).FirstOrDefault();
            //5
            ViewBag.pTitle5 = context.Products.Where(x => x.ProductId == 5).Select(x => x.Title).FirstOrDefault();
            ViewBag.pId5 = context.Products.Where(x => x.ProductId == 5).Select(x => x.ProductId).FirstOrDefault();
            ViewBag.pImage5 = context.Products.Where(x => x.ProductId == 5).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.pCategory5 = context.Products.Where(x => x.ProductId == 5).Select(x => x.ProductCategory.Title).FirstOrDefault();
            //6
            ViewBag.pTitle6 = context.Products.Where(x => x.ProductId == 6).Select(x => x.Title).FirstOrDefault();
            ViewBag.pId6 = context.Products.Where(x => x.ProductId == 6).Select(x => x.ProductId).FirstOrDefault();
            ViewBag.pImage6 = context.Products.Where(x => x.ProductId == 6).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.pCategory6 = context.Products.Where(x => x.ProductId == 6).Select(x => x.ProductCategory.Title).FirstOrDefault();

            //BLOG
            //1
            ViewBag.bTitle = context.Blogs.Where(x => x.BlogId == 1).Select(x => x.Title).FirstOrDefault();
            ViewBag.bId = context.Blogs.Where(x => x.BlogId == 1).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.bImage = context.Blogs.Where(x => x.BlogId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.bDesc = context.Blogs.Where(x => x.BlogId == 1).Select(x => x.Description).FirstOrDefault();
            //2
            //1
            ViewBag.bTitle2 = context.Blogs.Where(x => x.BlogId == 2).Select(x => x.Title).FirstOrDefault();
            ViewBag.bId2 = context.Blogs.Where(x => x.BlogId == 2).Select(x => x.BlogId).FirstOrDefault();
            ViewBag.bImage2 = context.Blogs.Where(x => x.BlogId == 2).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.bDesc2 = context.Blogs.Where(x => x.BlogId == 2).Select(x => x.Description).FirstOrDefault();
            return View();
        }
        public PartialViewResult ProductPartial()
        {
            return PartialView();
        }
        public PartialViewResult BlogPartial()
        {
            return PartialView();
        }
        public IActionResult AboutUs()
        {
            var about = aboutManager.TGetList();
            return View(about);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            ContactValidator validations = new ContactValidator();
            ValidationResult result = validations.Validate(contact);
            if (result.IsValid)
            {
                contact.Date = DateTime.Now;
                contactManager.TAdd(contact);
                return RedirectToAction("Contact");
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

        public IActionResult Blog()
        {
            var blogs = blogManager.GetBlogWithBlogCategory();
            return View(blogs);
        }
        public IActionResult BlogDetail(int id)
        {
            Context c = new Context();
            ViewBag.category = c.Blogs.Where(x => x.BlogId == id).Include(x => x.BlogCategory).Select(x => x.BlogCategory.Title).FirstOrDefault();
            ViewBag.blogTitle = c.Blogs.Where(x => x.BlogId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.image = c.Blogs.Where(x => x.BlogId == id).Where(x => x.BlogId == id).Select(x => x.ImageUrl).FirstOrDefault();
            //var values = blogManager.TGetById(id);
            var values = c.Blogs.Include(x => x.BlogCategory).Where(x => x.BlogId == id).ToList();
            return View(values);
        }
        public IActionResult OurTeam()
        {
            var value = personalManager.GetPersonalWithDepartment();
            return View(value);
        }
        public IActionResult Faq()
        {
            var value = faqManager.TGetList();
            return View(value);
        }
        public IActionResult Product()
        {
            var value = productManager.GetProductWithProductCategory();
            return View(value);
        }
        public IActionResult ProductDetail(int id)
        {
            Context c = new Context();
            ViewBag.category = c.Products.Where(x => x.ProductId == id).Include(x => x.ProductCategory).Select(x => x.ProductCategory.Title).FirstOrDefault();
            ViewBag.productTitle = c.Products.Where(x => x.ProductId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.image = c.Products.Where(x => x.ProductId == id).Select(x => x.ImageUrl).FirstOrDefault();
            //var values = productManager.TGetById(id);
            var values = c.Products.Include(x => x.ProductCategory).Where(x => x.ProductId == id).ToList();
            return View(values);
        }
        public IActionResult Service()
        {
            var value = serviceManager.TGetList();
            return View(value);
        }
    }
}
