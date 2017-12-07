﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Dal.Entities
{
    [Table("Department")]
  public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
