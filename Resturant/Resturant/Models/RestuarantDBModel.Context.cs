﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resturant.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ResturantDatabase : DbContext
    {
        public ResturantDatabase()
            : base("name=ResturantDatabaseEntities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Branch_Day> Branch_Day { get; set; }
        public DbSet<Branch_Item> Branch_Item { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cousine> Cousines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<ExtraCharge> ExtraCharges { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Food_AddOn> Food_AddOn { get; set; }
        public DbSet<Food_Ingredients> Food_Ingredients { get; set; }
        public DbSet<Food_Size> Food_Size { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodItem_AddOn> FoodItem_AddOn { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_ExtraCharges> Order_ExtraCharges { get; set; }
        public DbSet<Order_Item> Order_Item { get; set; }
        public DbSet<Order_Taxes> Order_Taxes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Postcode> Postcodes { get; set; }
        public DbSet<ResturantDetail> ResturantDetails { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<SpecialOffer_AddOn> SpecialOffer_AddOn { get; set; }
        public DbSet<SpecialOffer_Item> SpecialOffer_Item { get; set; }
        public DbSet<Tax> Taxes { get; set; }
    }
}
