using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class VisitorViewModel
    {
        [DisplayName("Логин посетителя")] public string LoginUser { get; set; }
        [DisplayName("Пароль посетителя")] public string Password { get; set; }
        [DisplayName("Почта посетителя")] public string Email { get; set; }
        [DisplayName("Общее время")] public int TotalTime { get; set; }
        [DisplayName("Статус посетителя")] public string Status { get; set; }
        [DisplayName("Количество сообщений")] public int CountOfMessages { get; set; }
        [DisplayName("Порядочность")] public int Decency { get; set; }
    }
}
