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
    public class FaqController : Controller
    {
        FaqManager faqManager = new FaqManager(new EfFaqDal());
        public IActionResult Index()
        {
            var value = faqManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Faq faq)
        {
            FaqValidator validations = new FaqValidator();
            ValidationResult result = validations.Validate(faq);
            if (result.IsValid)
            {
                faqManager.TAdd(faq);
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
            var value = faqManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Faq faq)
        {
            FaqValidator validations = new FaqValidator();
            ValidationResult result = validations.Validate(faq);
            if (result.IsValid)
            {
                faqManager.TUpdate(faq);
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
            var valueId = faqManager.TGetById(id);
            faqManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
