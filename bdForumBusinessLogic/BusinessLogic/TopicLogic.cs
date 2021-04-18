using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class TopicLogic
    {
        private readonly ITopicStorage topicStorage;
        public TopicLogic(ITopicStorage topicStorage)
        {
            this.topicStorage = topicStorage;
        }
        public List<TopicViewModel> Read(TopicBindingModel model)
        {
            if (model == null)
            {
                return topicStorage.GetFullList();
            }
            if (!model.Name.Equals(null))
            {
                return new List<TopicViewModel> { topicStorage.GetElement(model) };
            }
            return topicStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(TopicBindingModel model)
        {
            if (topicStorage.GetElement(new TopicBindingModel
            {
                Name = model.Name
            }) != null)
            {
                topicStorage.Update(model);
            }
            else
            {
                topicStorage.Insert(model);
            }
        }
        public void Delete(TopicBindingModel model)
        {
            var element = topicStorage.GetElement(new TopicBindingModel { Name = model.Name });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            topicStorage.Delete(model);
        }
    }
}

