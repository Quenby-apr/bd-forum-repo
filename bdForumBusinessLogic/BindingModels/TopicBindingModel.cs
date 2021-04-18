using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.BindingModels
{
    public class TopicBindingModel
    {
        public string Name { get; set; }
        public int NumberOfVisitors { get; set; }
        public int NumberOfMessages { get; set; }
    }
}
