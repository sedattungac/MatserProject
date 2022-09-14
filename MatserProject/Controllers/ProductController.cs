using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MatserProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = productManager.GetProductWithProductCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.ProductCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ProductCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product, Product product1)
        {
            ProductValidator validations = new ProductValidator();
            ValidationResult result = validations.Validate(product1);
            if (result.IsValid)
            {
                Product p = new Product();
                if (product.ImageUrl != null)
                {
                    var extension = Path.GetExtension(product.ImageUrl.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    product.ImageUrl.CopyTo(stream);
                    p.ImageUrl = "/Images/Product/" + newimagename;
                }
                p.Title = product.Title;
                p.Description = product.Description;
                p.ProductCategoryId = product.ProductCategoryId;
                productManager.TAdd(p);
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
            List<SelectListItem> category = (from x in context.ProductCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ProductCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            var values = productManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Product product, ProductViewModel viewModel)
        {
            var productValue = context.Products.Find(product.ProductId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                product.ImageUrl = "/Images/Product/" + newimagename;

                productManager.TUpdate(product);
                return RedirectToAction("Index");

            }
            else
            {
                productValue.Title = product.Title;
                productValue.Description = product.Description;
                //context.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index");

            }

        }
        public IActionResult Delete(int id)
        {
            var valueId = productManager.TGetById(id);
            productManager.TDelete(valueId);
            //System.IO.File.Delete("wwwroot/" + valueId.ImageUrl);
            return RedirectToAction("Index");
        }
    }
}
