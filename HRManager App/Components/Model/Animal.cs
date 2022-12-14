//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRManager_App.Components.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            this.SchedulePerfomance = new HashSet<SchedulePerfomance>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TypeAnimalId { get; set; }
        public int CageId { get; set; }
    
        public virtual Cage Cage { get; set; }
        public virtual TypeAnimal TypeAnimal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchedulePerfomance> SchedulePerfomance { get; set; }
    }
}
