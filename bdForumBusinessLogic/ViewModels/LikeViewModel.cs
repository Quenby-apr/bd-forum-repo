using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class LikeViewModel
    {
        [DisplayName("Логин пользователя")]public string LoginUser { get; set; }
        public int IdMessage { get; set; }
    }
}
