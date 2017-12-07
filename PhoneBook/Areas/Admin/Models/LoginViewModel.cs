using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Areas.Admin.Models
{
    public class LoginViewModel
    {
        public int WorkerId { get; set; }
        public string email { get; set; }
       
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}