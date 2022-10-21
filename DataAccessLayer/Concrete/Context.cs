using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BUBEBSC; database=DbMatser;integrated security=true");
            //optionsBuilder.UseSqlServer("Data Source=185.87.254.56;Initial Catalog=matser;User ID=matser;Password=A.sd12345678987654321;persist security info=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MachineCategory> MachineCategories { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Email> Emails { get; set; }


    }
}
