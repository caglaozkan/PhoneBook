using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Dal.Entities;
using System.Data.Entity;


namespace PhoneBook.Dal
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext() : base("PhoneBookDbConnection")
        {
            Database.SetInitializer<PhoneBookDbContext>(null);
        }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
