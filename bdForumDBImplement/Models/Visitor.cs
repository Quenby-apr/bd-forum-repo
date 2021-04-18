using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class Visitor
    {
        public Visitor()
        {
            Like = new HashSet<Like>();
            Message = new HashSet<Message>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int Countmessages { get; set; }
        public int Decency { get; set; }
        public int TotalTime { get; set; }

        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
