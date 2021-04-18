using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class ModeratorViewModel
    {
        [DisplayName("Логин модератора")] public string LoginUser { get; set; }
        [DisplayName("Пароль модератора")] public string Password { get; set; }
        [DisplayName("Почта модератора")] public string Email { get; set; }
        [DisplayName("Общее время")] public int TotalTime { get; set; }
        [DisplayName("Количество помощи")] public int AmountOfHelp { get; set; }
    }
}
