using Microsoft.EntityFrameworkCore;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDatabaseImplement
{
    public class SchoolDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AIVAGGI\SQLEXPRESS;Initial Catalog=SchoolDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
              // optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2VLTMI2\SQLEXPRESS;Initial Catalog=SchoolDatabaseFirst;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Circle> Circles { set; get; }
        public virtual DbSet<SchoolSupplie> SchoolSupplies { set; get; }
        public virtual DbSet<CircleSchoolSupplie> CircleSchoolSupplies { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<WareHouseSchoolSupplie> WareHouseSchoolSupplies { set; get; }
        public virtual DbSet<WareHouse> WareHouses { set; get; }
        public virtual DbSet<Request> Requests { set; get; }
        public virtual DbSet<RequestSchoolSupplie> RequestsSchoolSupplies { set; get; }
        public virtual DbSet<Supplier> Suppliers { set; get; }
    }
}
