﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveFarmWPF.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LiveFarmEntities : DbContext
    {
        public LiveFarmEntities()
            : base("name=LiveFarmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Assortment> Assortment { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Makers> Makers { get; set; }
        public virtual DbSet<MakingStatuses> MakingStatuses { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PickupPoints> PickupPoints { get; set; }
        public virtual DbSet<ProductsInOrder> ProductsInOrder { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
