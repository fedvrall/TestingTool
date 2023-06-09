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
    
    public partial class TestCase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestCase()
        {
            this.BugReport = new HashSet<BugReport>();
        }
    
        public int TestCaseID { get; set; }
        public string TestCaseSummary { get; set; }
        public string TestCaseDescription { get; set; }
        public string TestCaseSteps { get; set; }
        public string TestCaseExpectedResult { get; set; }
        public string TestCaseActualResult { get; set; }
        public int TCStatusID { get; set; }
        public string TestCaseTestData { get; set; }
        public int TestSuiteID { get; set; }
        public int CreatorUserID { get; set; }
        public System.DateTime TestCaseCreationDate { get; set; }
        public Nullable<int> ExecutorUserID { get; set; }
        public Nullable<System.DateTime> TestCaseExecutionDate { get; set; }
        public string TestCaseEnvironment { get; set; }
        public Nullable<int> TCTypeID { get; set; }
        public Nullable<int> TCBehaviorID { get; set; }
        public Nullable<int> TCPriorityID { get; set; }
        public Nullable<int> TCSeverityID { get; set; }
        public string TestCaseAttachment { get; set; }
        public string TestCasePrecondition { get; set; }
        public string TestCasePostcondition { get; set; }
        public string TestCaseVisibleID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugReport> BugReport { get; set; }
        public virtual TestSuite TestSuite { get; set; }
        public virtual TestCaseBehavior TestCaseBehavior { get; set; }
        public virtual TestCasePriority TestCasePriority { get; set; }
        public virtual TestCaseSeverity TestCaseSeverity { get; set; }
        public virtual TestCaseStatus TestCaseStatus { get; set; }
        public virtual TestCaseType TestCaseType { get; set; }
        public virtual Userinfo Userinfo { get; set; }
        public virtual Userinfo Userinfo1 { get; set; }
    }
}
