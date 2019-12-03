using NorthWestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorthWestLabs.DAL
{
    public class NorthWestLabsContext : DbContext
    {
        public NorthWestLabsContext() : base("NorthWestLabsContext") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assay> Assays { get; set; }
        public DbSet<Test_Has_Employee> AssayEmployees { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_Has_Material> TestMaterials { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Assay_Has_TestType> AssayTestTypes { get; set; }
        public DbSet<CompoundType> CompoundTypes { get; set; }
    }
}