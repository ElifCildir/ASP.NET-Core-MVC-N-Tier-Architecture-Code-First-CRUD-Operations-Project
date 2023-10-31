using coreData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreData.Data
{
    public class ApplicationDbContext:DbContext 

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Personel> Personels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Unit> Units { get; set; }






    }
}
