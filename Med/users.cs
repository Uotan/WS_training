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
    
    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            this.provide_services = new HashSet<provide_services>();
        }
    
        public int code { get; set; }
        public string full_name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string ip { get; set; }
        public System.DateTime last_enter { get; set; }
        public string services { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<provide_services> provide_services { get; set; }
        public virtual user_types user_types { get; set; }
    }
}
