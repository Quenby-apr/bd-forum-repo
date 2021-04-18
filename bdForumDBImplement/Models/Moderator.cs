using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class Moderator
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Amountofhelp { get; set; }
        public int TotalTime { get; set; }
    }
}
