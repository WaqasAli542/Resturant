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
    
    public partial class Branch_Item
    {
        public int Id { get; set; }
        public int BranchID { get; set; }
        public int ItemID { get; set; }
        public int IDType { get; set; }
        public int Aavailibility { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}
