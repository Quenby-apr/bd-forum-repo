using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Текст сообщения")]  public string Text { get; set; }
        [DisplayName("Время отправки")]  public DateTime Time { get; set; }
        [DisplayName("Логин пользователя")]  public string LoginUser { get; set; }
        [DisplayName("Название тематики")]  public string NameTopic { get; set; }
    }
}
