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
    
    public partial class CheckListPriority
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CheckListPriority()
        {
            this.CheckListItem = new HashSet<CheckListItem>();
        }
    
        public int CLPriorityID { get; set; }
        public string CLPriorityDescription { get; set; }
        public string CLPriorityDescriptionTranslation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckListItem> CheckListItem { get; set; }
    }
}
