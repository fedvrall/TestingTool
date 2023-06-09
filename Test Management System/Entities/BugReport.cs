//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class BugReport
    {
        public int BugReportID { get; set; }
        public string BugReportSummary { get; set; }
        public string BugEnvironment { get; set; }
        public string BugSteps { get; set; }
        public string BugExpectedResult { get; set; }
        public string BugActualResult { get; set; }
        public string BugPreconditions { get; set; }
        public string BugTestData { get; set; }
        public string BugAttachment { get; set; }
        public Nullable<int> BugSeverityID { get; set; }
        public Nullable<int> BugPriorityID { get; set; }
        public Nullable<int> BRStatusID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateOfCreation { get; set; }
        public string BugReportRemark { get; set; }
        public string BugComponentOfSW { get; set; }
        public string BugVersionOfSW { get; set; }
        public Nullable<int> TestCaseID { get; set; }
    
        public virtual BugPriority BugPriority { get; set; }
        public virtual Project Project { get; set; }
        public virtual TestCase TestCase { get; set; }
        public virtual BugReportStatus BugReportStatus { get; set; }
        public virtual BugSeverity BugSeverity { get; set; }
        public virtual Userinfo Userinfo { get; set; }
    }
}
