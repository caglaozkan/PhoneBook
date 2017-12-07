using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Areas.Admin.Models
{
    public class AddWorkerViewModel
    {
        public int WorkerId { get; set; }

        [Required(ErrorMessage = "Çalışan adı boş geçilemez")]
        public string name { get; set; }
        [Required(ErrorMessage = "Çalışan soyadı boş geçilemez")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Çalışan telefonu boş geçilemez")]
        public string phone { get; set; }
       
        public string email { get; set; }


        public int departmentid { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }     
        public int managerid { get; set; }
        public IEnumerable<SelectListItem> ManagerList { get; set; }
    }
}