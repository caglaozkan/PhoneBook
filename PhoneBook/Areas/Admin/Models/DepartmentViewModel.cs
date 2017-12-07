using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Areas.Admin.Models
{
    public class DepartmentViewModel
    {

        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Çalışan adı boş geçilemez")]
        public string name { get; set; }
    }
}