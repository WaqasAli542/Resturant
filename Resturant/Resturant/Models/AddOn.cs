//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class AddOn
    {
        public AddOn()
        {
            this.Food_AddOn = new HashSet<Food_AddOn>();
            this.SpecialOffer_AddOn = new HashSet<SpecialOffer_AddOn>();
            this.FoodItem_AddOn = new HashSet<FoodItem_AddOn>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
    
        public virtual ICollection<Food_AddOn> Food_AddOn { get; set; }
        public virtual ICollection<SpecialOffer_AddOn> SpecialOffer_AddOn { get; set; }
        public virtual ICollection<FoodItem_AddOn> FoodItem_AddOn { get; set; }
    }
}
