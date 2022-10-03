using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Controllers
{
    public class MachineCategoryController : Controller
    {
        MachineCategoryManager machineCategoryManager = new MachineCategoryManager(new EfMachineCategoryDal());
        public IActionResult Index()
        {
            var value = machineCategoryManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MachineCategory machineCategory)
        {

            machineCategoryManager.TAdd(machineCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = machineCategoryManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(MachineCategory machineCategory)
        {


            machineCategoryManager.TUpdate(machineCategory);
            return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var getId = machineCategoryManager.TGetById(id);
            machineCategoryManager.TDelete(getId);
            return RedirectToAction("Index");
        }
    }
}
