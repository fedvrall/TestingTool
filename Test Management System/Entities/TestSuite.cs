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
    
    public partial class TestSuite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestSuite()
        {
            this.TestCase = new HashSet<TestCase>();
            this.TestSuite1 = new HashSet<TestSuite>();
        }
    
        public int TestSuiteID { get; set; }
        public string TestSuiteSummary { get; set; }
        public string TestSuiteDescription { get; set; }
        public string TestSuiteLabel { get; set; }
        public string TestSuitePreconditions { get; set; }
        public Nullable<int> TestSuiteParentID { get; set; }
        public int ProjectID { get; set; }
    
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestCase> TestCase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestSuite> TestSuite1 { get; set; }
        public virtual TestSuite TestSuite2 { get; set; }
    }
}
