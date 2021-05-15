using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class MongoMessageViewModel
    {
        public string _id { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
        public string userlogin { get; set; }
        public string topicname { get; set; }
        public string[] Likelists { get; set; }
    }
}
