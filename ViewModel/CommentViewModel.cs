using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating_Comment.ViewModel
{
    public class CommentViewModel
    {
        public int comment_id { get; set; }
        public int platter_id { get; set; }     
        public string comment_description { get; set; }
        public int rating { get; set; }
        public DateTime commentedOn { get; set; }
        
    }
}