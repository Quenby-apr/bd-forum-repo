using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.BindingModels
{
    public class ModeratorBindingModel
    {
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TotalTime { get; set; }
        public int AmountOfHelp { get; set; }
    }
}
