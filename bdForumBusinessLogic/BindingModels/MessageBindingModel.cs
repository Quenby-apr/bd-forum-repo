using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.BindingModels
{
    public class MessageBindingModel
    {
        public int? Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string LoginUser { get; set; }
        public string NameTopic { get; set; }
    }
}
