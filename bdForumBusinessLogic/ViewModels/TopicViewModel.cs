using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class TopicViewModel
    {
        [DisplayName("Название тематики")]  public string Name { get; set; }
        [DisplayName("Количество посетителей")]  public int NumberOfVisitors { get; set; }
        [DisplayName("Количество сообщений")] public int NumberOfMessages { get; set; }
    }
}
