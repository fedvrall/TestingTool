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
    
    public partial class CheckListItem
    {
        public string CheckListItemID { get; set; }
        public string CheckListItemDescription { get; set; }
        public int CLStatusID { get; set; }
        public string CLComment { get; set; }
        public string CheckListID { get; set; }
        public string CLAttachment { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> DataOfExecution { get; set; }
        public Nullable<int> CLPriorityID { get; set; }
    
        public virtual CheckList CheckList { get; set; }
        public virtual CheckListPriority CheckListPriority { get; set; }
        public virtual CheckListStatus CheckListStatus { get; set; }
        public virtual Userinfo Userinfo { get; set; }
    }
}
