//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KSU
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disposals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disposals()
        {
            this.ContentsDisposals = new HashSet<ContentsDisposals>();
            this.ReasonDisposals = new HashSet<ReasonDisposals>();
            this.ViewsDisposals = new HashSet<ViewsDisposals>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int ActNumber { get; set; }
        public int TotalNumber { get; set; }
        public double Cost { get; set; }
        public int IdPlace { get; set; }
        public int IdEnclosures { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentsDisposals> ContentsDisposals { get; set; }
        public virtual Enclosures Enclosures { get; set; }
        public virtual Place Place { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReasonDisposals> ReasonDisposals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViewsDisposals> ViewsDisposals { get; set; }
    }
}