﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test_Management_System.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Testing_ToolEntity : DbContext
    {
        public Testing_ToolEntity()
            : base("name=Testing_ToolEntity")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AmountOfUsers> AmountOfUsers { get; set; }
        public virtual DbSet<BugPriority> BugPriority { get; set; }
        public virtual DbSet<BugReport> BugReport { get; set; }
        public virtual DbSet<BugReportStatus> BugReportStatus { get; set; }
        public virtual DbSet<BugSeverity> BugSeverity { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<CheckListItem> CheckListItem { get; set; }
        public virtual DbSet<CheckListPriority> CheckListPriority { get; set; }
        public virtual DbSet<CheckListStatus> CheckListStatus { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectDocumentation> ProjectDocumentation { get; set; }
        public virtual DbSet<ProjectUser> ProjectUser { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TestCase> TestCase { get; set; }
        public virtual DbSet<TestCaseBehavior> TestCaseBehavior { get; set; }
        public virtual DbSet<TestCasePriority> TestCasePriority { get; set; }
        public virtual DbSet<TestCaseSeverity> TestCaseSeverity { get; set; }
        public virtual DbSet<TestCaseStatus> TestCaseStatus { get; set; }
        public virtual DbSet<TestCaseType> TestCaseType { get; set; }
        public virtual DbSet<TestSuite> TestSuite { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }
    }
}
