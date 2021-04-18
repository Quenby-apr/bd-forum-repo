using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface ITopicStorage
    {
        List<TopicViewModel> GetFullList();
        List<TopicViewModel> GetFilteredList(TopicBindingModel model);
        TopicViewModel GetElement(TopicBindingModel model);
        void Insert(TopicBindingModel model);
        void Update(TopicBindingModel model);
        void Delete(TopicBindingModel model);
    }
}
