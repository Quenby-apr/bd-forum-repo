using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Message = new HashSet<Message>();
        }

        public string Name { get; set; }
        public int Numberofvisitors { get; set; }
        public int Numberofmessages { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
