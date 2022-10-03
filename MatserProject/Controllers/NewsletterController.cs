using MailKit.Net.Smtp;
using MimeKit;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class NewsletterController : Controller
    {
        NewsletterManager newsletterManager = new NewsletterManager(new EfNewsletterDal());
        public IActionResult Index()
        {
            var customer = newsletterManager.TGetList();
            return View(customer);
        }
        public ActionResult Convert(int id)
        {
            using Context context = new Context();
            var value = context.Newsletters.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
                newsletterManager.TUpdate(value);
                return RedirectToAction("Index");

            }
            else
            {
                value.Status = true;
                newsletterManager.TUpdate(value);
                return RedirectToAction("Index");

            }
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        public IActionResult SendMessage(Email email)
        {
            using Context _context = new Context();
            var customerList = _context.Newsletters.Where(x => x.Status == true).ToList();
            List<Newsletter> customer = new List<Newsletter>();
            if (email != null)
            {
                foreach (Newsletter newsletter in _context.Newsletters.ToList())
                {                

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("MATSER", "kerimoglumezar@gmail.com"));
                    message.To.Add(new MailboxAddress("", email.EmailAddress.ToString()));
                    message.Subject = email.Subjeft;
                    message.Body = new TextPart("plain")
                    { 
                        Text = "Sayın " + email.EmailAddress+ " ," + email.Message + " " + "sitemize göz atmak için tıklayınız. => https://matser.com.tr/"
                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("kerimoglumezar@gmail.com", "A.sd1234");
                        client.Send(message);
                        client.Disconnect(true);
                    }


                }
                ViewBag.alert = "Yeni Bülten Başarıyla Gönderilmiştir";
            }
            else
            {
                ViewBag.alert = "Hata Oluştu!";
            }

            return View("Index");
        }

    }
}
