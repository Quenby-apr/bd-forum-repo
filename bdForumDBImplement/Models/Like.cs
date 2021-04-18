using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class Like
    {
        public string Visitorlogin { get; set; }
        public int Messageid { get; set; }

        public virtual Message Message { get; set; }
        public virtual Visitor VisitorloginNavigation { get; set; }
    }
}
