﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestTussentijdsProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestProjectEntities : DbContext
    {
        public TestProjectEntities()
            : base("name=TestProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Klanten> Klantens { get; set; }
        public virtual DbSet<Orderlijnen> Orderlijnens { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Producten> Productens { get; set; }
        public virtual DbSet<Pub_info> Pub_info { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<TitlesAuthor> TitlesAuthors { get; set; }
        public virtual DbSet<Werknemer> Werknemers { get; set; }
        public virtual DbSet<Roysched> Royscheds { get; set; }
        public virtual DbSet<TitleView> TitleViews { get; set; }
    }
}
