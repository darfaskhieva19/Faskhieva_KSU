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
    
    public partial class Results
    {
        public int Id { get; set; }
        public string FundMovement { get; set; }
        public Nullable<int> TotalCount { get; set; }
        public Nullable<double> TotalCost { get; set; }
        public string Notes { get; set; }
        public int IdEnclosures { get; set; }
    
        public virtual Enclosures Enclosures { get; set; }
    }
}
