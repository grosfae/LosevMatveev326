//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LosevMatveev326.Components.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketSale
    {
        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public int ClientId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
