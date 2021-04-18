using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.BindingModels
{
    public class VisitorBindingModel
    {
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TotalTime { get; set; }
        public string Status { get; set; }
        public int CountOfMessages { get; set; }
        public int Decency { get; set; }
    }
}
