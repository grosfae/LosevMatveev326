﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LosevMatveev326Entities : DbContext
    {
        public LosevMatveev326Entities()
            : base("name=LosevMatveev326Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Cage> Cage { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemEmployee> ItemEmployee { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<SchedulePerfomance> SchedulePerfomance { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TicketSale> TicketSale { get; set; }
        public virtual DbSet<TypeAnimal> TypeAnimal { get; set; }
        public virtual DbSet<TypeItem> TypeItem { get; set; }
    }
}
