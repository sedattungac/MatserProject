using BusinessLayer.Concrete;
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
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class MachineController : Controller
    {
        MachineManager machineManager = new MachineManager(new EfMachineDal());
        public IActionResult Index()
        {
            var value = machineManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.MachineCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.MachineCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Add(MachineViewModel machine, Machine machine1)
        {

            Machine m = new Machine();
            if (machine.ImageUrl != null)
            {
                var extension = Path.GetExtension(machine.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                machine.ImageUrl.CopyTo(stream);
                m.ImageUrl = "/Images/Machine/" + newimagename;
            }
            if (machine.ImageUrl2 != null)
            {
                var extension = Path.GetExtension(machine.ImageUrl2.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                machine.ImageUrl2.CopyTo(stream);
                m.ImageUrl2 = "/Images/Machine/" + newimagename;
            }
            if (machine.ImageUrl3 != null)
            {
                var extension = Path.GetExtension(machine.ImageUrl3.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                machine.ImageUrl3.CopyTo(stream);
                m.ImageUrl3 = "/Images/Machine/" + newimagename;
            }
            if (machine.ImageUrl4 != null)
            {
                var extension = Path.GetExtension(machine.ImageUrl4.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                machine.ImageUrl4.CopyTo(stream);
                m.ImageUrl4 = "/Images/Machine/" + newimagename;
            }
            m.MachineCategoryId = machine.MachineCategoryId;
            machineManager.TAdd(m);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using Context context = new Context();
            List<SelectListItem> category = (from x in context.MachineCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.MachineCategoryId.ToString()



                                             }).ToList();
            ViewBag.category = category;
            var values = machineManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Machine machine, MachineViewModel viewModel)
        {
            using Context context = new Context();
            var m = context.Machines.Find(machine.MachineId);
            if (viewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl.CopyTo(stream);
                machine.ImageUrl = "/Images/Machine/" + newimagename;
                m.ImageUrl = machine.ImageUrl;
            }
            if (viewModel.ImageUrl2 != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl2.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl2.CopyTo(stream);
                machine.ImageUrl2 = "/Images/Machine/" + newimagename;
                m.ImageUrl2 = machine.ImageUrl2;
            }
            if (viewModel.ImageUrl3 != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl3.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl3.CopyTo(stream);
                machine.ImageUrl3 = "/Images/Machine/" + newimagename;
                m.ImageUrl3 = machine.ImageUrl3;
            }
            if (viewModel.ImageUrl4 != null)
            {
                var extension = Path.GetExtension(viewModel.ImageUrl4.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Machine", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                viewModel.ImageUrl4.CopyTo(stream);
                machine.ImageUrl4 = "/Images/Machine/" + newimagename;
                m.ImageUrl4 = machine.ImageUrl4;
            }
            m.MachineCategoryId = machine.MachineCategoryId;
            m.Name = machine.Name;
            m.DeliveryDate = machine.DeliveryDate;
            m.Description = machine.Description;
            m.ModelYear = machine.ModelYear;
            m.Producer = machine.Producer;
            m.Dimension = machine.Dimension;
            m.Group = machine.Group;
            m.VideoUrl = machine.VideoUrl;
            m.Information = machine.Information;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var valueId = machineManager.TGetById(id);
            machineManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
