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
    
    public partial class ReasonDisposals
    {
        public int Id { get; set; }
        public int IdReason { get; set; }
        public int IdDisposals { get; set; }
        public Nullable<int> Counts { get; set; }
    
        public virtual Disposals Disposals { get; set; }
        public virtual Reason Reason { get; set; }
    }
}
