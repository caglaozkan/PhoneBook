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
    public class DepartmentController : Controller
    {
        PhoneBook.Dal.PhoneBookDbContext context = new Dal.PhoneBookDbContext();
        // GET: Admin/Department
        public ActionResult Index()
        {
            List<Department> departments = context.Departments.ToList();
            return View(departments);
        }

        
        public ActionResult DepartmentAdd()
        {
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DepartmentAdd(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public ActionResult Delete(int departmentId)
        {
           
                var department = context.Departments.Find(departmentId);
                if (department == null)
                    return RedirectToAction("Index");

                if (context.Workers.Any(x => x.departmentid == departmentId))
                {
                    TempData["Status"] = false;
                    TempData["Message"] = "Silmek istediginiz departmanda çalışan oldugundan silinemedi.";
                    return RedirectToAction("Index");
                }

                context.Departments.Attach(department);
                context.Entry(department).State = EntityState.Deleted;
                context.SaveChanges();
                return RedirectToAction("Index");
            
            
        }
        [HttpGet]
        public ActionResult Edit(int DepartmentId)
        {
            var department = context.Departments.Find(DepartmentId);
            if (department == null)
                return RedirectToAction("Index");

            var viewModel = new DepartmentViewModel();
            viewModel.DepartmentId = department.id;
            viewModel.name = department.name;      
      
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var department = context.Departments.Find(viewModel.DepartmentId);

                    department.name = viewModel.name;
                 

                    context.Departments.Attach(department);
                    context.Entry(department).State = EntityState.Modified;
                    context.SaveChanges();
                    TempData["Status"] = true;
                    TempData["Message"] = "Departman bilgileri başarıyla güncellendi";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["Status"] = false;
                TempData["Message"] = ex.Message;
            }
            return View(viewModel);


        }
    }
}