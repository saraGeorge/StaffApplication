using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationEndpoints.ApplicationDBContext
{
    public class StaffDBContext : DbContext
    {
        public StaffDBContext(DbContextOptions context) : base(context)
        {

        }
        public DbSet<Staff> Staffs { get; set; }

       
    }
}
