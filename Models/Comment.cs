//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rating_Comment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int comment_id { get; set; }
        public int platter_id { get; set; }
        public System.Guid guest_id { get; set; }
        public string comment_description { get; set; }
        public int rating { get; set; }
        public System.DateTime commentedOn { get; set; }
    
        public virtual tbl_platter tbl_platter { get; set; }
    }
}
