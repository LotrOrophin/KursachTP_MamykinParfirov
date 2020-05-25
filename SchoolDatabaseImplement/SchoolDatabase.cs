using Microsoft.EntityFrameworkCore;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDatabaseImplement
{
    public class SchoolDatabase
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                //optionsBuilder.UseSqlServer(@" ");
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IMFQ926R\SQLEXPRESS;Initial Catalog=RestaurantDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Box> Box { set; get; }
        public virtual DbSet<BoxJewerly> BoxJewerlies { set; get; }
        public virtual DbSet<RequestProduct> RequestProducts { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<Jewerly> Jewerlies { set; get; }
        public virtual DbSet<Request> Requests { set; get; }
        public virtual DbSet<Supplier> Suppliers { set; get; }
    }
}
