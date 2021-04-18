using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class Message
    {
        public Message()
        {
            Like = new HashSet<Like>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string Visitorlogin { get; set; }
        public string Topicname { get; set; }

        public virtual Topic TopicnameNavigation { get; set; }
        public virtual Visitor VisitorloginNavigation { get; set; }
        public virtual ICollection<Like> Like { get; set; }
    }
}
