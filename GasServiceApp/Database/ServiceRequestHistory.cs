//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GasServiceApp.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceRequestHistory
    {
        public int RequestHistoryID { get; set; }
        public Nullable<int> RequestID { get; set; }
        public Nullable<int> Status { get; set; }
        public string AssignedTo { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Comment { get; set; }
    
        public virtual ServiceRequests ServiceRequests { get; set; }
        public virtual StatusRequestHistory StatusRequestHistory { get; set; }
    }
}
