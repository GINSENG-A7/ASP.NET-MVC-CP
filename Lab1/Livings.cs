//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Livings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livings()
        {
            this.AditionServices = new HashSet<AditionServices>();
        }
    
        public int Id { get; set; }
        public int ValueOfGuests { get; set; }
        public int ValueOfKids { get; set; }
        public System.DateTime Settling { get; set; }
        public System.DateTime Eviction { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> ApartmentsId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AditionServices> AditionServices { get; set; }
        public virtual Apartments Apartments { get; set; }
        public virtual Clients Clients { get; set; }
    }
}