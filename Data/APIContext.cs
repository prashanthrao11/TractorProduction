using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
           : base(options)
        {
        }

        //Created by to define shadow properties used by all the entity classes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //string[] notmappedentities = new string[] { "Region" };

            //var allEntities = modelBuilder.Model.GetEntityTypes();

            //foreach (var entity in allEntities)
            //{
            //    entity.AddProperty("Created_Date", typeof(DateTime?));
            //    entity.AddProperty("Created_By", typeof(string));
            //    entity.AddProperty("Modified_Date", typeof(DateTime?));
            //    entity.AddProperty("Modified_By", typeof(string));
            //}
        }

        public DbSet<User> User { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<MilestoneDepartment> MilestoneDepartment { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<DepartmentApprover> DepartmentApprover { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }
        public DbSet<LogDetails> LogDetails { get; set; }
        public DbSet<ProductionApproval> ProductionApproval { get; set; }

        public DbSet<ProductionFinalApproval> ProductionFinalApproval { get; set; }
        public DbSet<ProductionMilestoneDepartmentApproval> ProductionMilestoneDepartmentApproval { get; set; }
        public DbSet<ProductPhase> ProductPhase { get; set; }
        public DbSet<ProductionMilestone> ProductionMilestone { get; set; }
        public DbSet<ProductionUserApproval> ProductionUserApproval { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StatusType> StatusType { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Workflow> Workflow { get; set; }
        public DbSet<WorkflowPhaseMilestone> WorkflowPhaseMilestone { get; set; }

        public DbSet<MilestoneManageVM> ManageMilestone { get; set; }
        public DbSet<DepartmentUsers> DepartmentUsers { get; set; }

        public DbSet<UserVM> UserDetails { get; set; }
        public DbSet<AttachmentDetails> AttachmentDetails { get; set; }
        public DbSet<AttachmentHeader> AttachmentHeader { get; set; }
    }
}
