using PhoneBook.Dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Dal.Entities
{
    [Table("Worker")]
    public class Worker
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public int managerid { get; set; }
        public int departmentid { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        [ForeignKey("managerid")]
        public virtual Worker Manager { get; set; }

        [ForeignKey("departmentid")]
        public virtual Department Department { get; set; }
    }
}
