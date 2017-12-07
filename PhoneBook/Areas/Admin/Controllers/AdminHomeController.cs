using PhoneBook.Areas.Admin.Models;
using PhoneBook.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminHomeController : Controller
    {
        PhoneBook.Dal.PhoneBookDbContext context = new Dal.PhoneBookDbContext();
        // GET: Admin/AdminHome

        public ActionResult Index()
        {
            List<Worker> workers = context.Workers.ToList();
            return View(workers);
        }

        [HttpGet]
        public ActionResult Add()
        {

            AddWorkerViewModel viewModel = new AddWorkerViewModel();
            viewModel.DepartmentList = context.Departments.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();

            viewModel.ManagerList = context.Workers.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddWorkerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Worker newWorker = new Worker();
                    newWorker.name = model.name;
                    newWorker.surname = model.surname;
                    newWorker.email = model.email;
                    newWorker.phone = model.phone;
                    newWorker.departmentid = model.departmentid;
                    newWorker.managerid = model.managerid;


                    context.Workers.Add(newWorker);
                    context.SaveChanges();
                    TempData["Status"] = true;
                    TempData["Message"] = "Çalışan başarıyla eklendi";

                }
            }
            catch (Exception ex)
            {
                TempData["Status"] = false;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("Index");
        
            model.DepartmentList = context.Departments.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();
            model.ManagerList = context.Workers.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();
            return View(model);
        }

        public ActionResult Delete(int WorkerId)
        {
            var worker = context.Workers.Find(WorkerId);
            if (worker == null)
                return RedirectToAction("Index");

            if (context.Workers.Any(x=>x.managerid == WorkerId))
            {
                TempData["Status"] = false;
                TempData["Message"] = "Silmek istediginiz kişi başka bir çalışanın yöneticisi oldugundan silinemedi.";
                return RedirectToAction("Index");
            }
            

            context.Workers.Attach(worker);
            context.Entry(worker).State = EntityState.Deleted;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int WorkerId)
        {
            var worker = context.Workers.Find(WorkerId);
            if (worker == null)
                return RedirectToAction("Index");

            var viewModel = new AddWorkerViewModel();
            viewModel.WorkerId = worker.id;
            viewModel.name = worker.name;
            viewModel.surname = worker.surname;
            viewModel.email = worker.email;
            viewModel.phone = worker.phone;
            viewModel.departmentid = worker.departmentid;
            viewModel.managerid = worker.managerid;
            viewModel.DepartmentList = context.Departments.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();

            viewModel.ManagerList = context.Workers.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddWorkerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var worker = context.Workers.Find(viewModel.WorkerId);

                    worker.name = viewModel.name;
                    worker.surname = viewModel.surname;
                    worker.phone = viewModel.phone;
                    worker.email = viewModel.email;
                    worker.departmentid = viewModel.departmentid;
                    worker.managerid = viewModel.managerid;

                    context.Workers.Attach(worker);
                    context.Entry(worker).State = EntityState.Modified;
                    context.SaveChanges();
                    TempData["Status"] = true;
                    TempData["Message"] = "Çalışan bilgileri başarıyla güncellendi"; 
                   

                }
            }
            catch (Exception ex)
            {
                TempData["Status"] = false;
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("Index");

            viewModel.DepartmentList = context.Departments.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();

            viewModel.ManagerList = context.Workers.Select(x => new SelectListItem()
            {
                Value = x.id.ToString(),
                Text = x.name
            }).ToList();

            return View(viewModel);
        }
    }
}