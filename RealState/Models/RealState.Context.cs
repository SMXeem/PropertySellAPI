﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealState.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RealStateEntities : DbContext
    {
        public RealStateEntities()
            : base("name=RealStateEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<PropertyFile> PropertyFiles { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertySubType> PropertySubTypes { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<vProperty> vProperties { get; set; }
    }
}
