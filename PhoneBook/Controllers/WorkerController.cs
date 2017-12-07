using PhoneBook.Dal;
using PhoneBook.Dal.Entities;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PhoneBook.Controllers
{
    public class WorkerController : Controller
    {
        private PhoneBookDbContext context = new PhoneBookDbContext();
     

        // GET: Worker

        public ActionResult Index()
        {
            List<Worker> workers = context.Workers.ToList();
            return View(workers);
        }

        public ActionResult Detail(int id)
        {
            Worker worker = context.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);            
        }
    }
}