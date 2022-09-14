using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class LoginController : Controller
    {
        Context _context = new Context();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Admin p)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);

            if (admin != null)
            {
                HttpContext.Session.SetInt32("id", admin.AdminId);
                HttpContext.Session.SetString("email", admin.Email);
                HttpContext.Session.SetString("fullname", admin.FullName);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.alert = "Hatalı Giriş! Lütfen tekrar deneyiniz!";

            }
            return View("Index");
        }
        [AllowAnonymous]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
