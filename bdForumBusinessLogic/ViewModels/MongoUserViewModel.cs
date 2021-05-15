using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class MongoUserViewModel
    {
        public string _id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int totaltime { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public int countofmessages { get; set; }
        public int decency { get; set; }
        public int amountofhelp { get; set; }
    }
}
