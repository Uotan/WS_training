//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Med
{
    using System;
    using System.Collections.Generic;
    
    public partial class provide_services
    {
        public int code { get; set; }
        public Nullable<int> blood { get; set; }
        public Nullable<int> service { get; set; }
        public decimal result { get; set; }
        public int accepted { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> analyzer { get; set; }
        public Nullable<int> user { get; set; }
        public System.DateTime finish_date { get; set; }
        public Nullable<bool> is_deleted { get; set; }
    
        public virtual analyzers analyzers { get; set; }
        public virtual patients_blood patients_blood { get; set; }
        public virtual services services { get; set; }
        public virtual statuses statuses { get; set; }
        public virtual users users { get; set; }
    }
}
