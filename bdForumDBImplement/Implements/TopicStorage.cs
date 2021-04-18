using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;
using bdForumDBImplement.DatabaseContext;
using bdForumDBImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace bdForumDBImplement.Implements
{
    public class TopicStorage : ITopicStorage
    {
        public TopicViewModel GetElement(TopicBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumDatabase())
            {
                var topic = context.Topic.Include(rec => rec.Message).FirstOrDefault
                   (rec => rec.Name == model.Name);
                return topic != null ? new TopicViewModel
                {
                    Name = topic.Name,
                    NumberOfVisitors = topic.Numberofvisitors,
                    NumberOfMessages = topic.Numberofmessages
                } :
                null;
            }
        }

        public List<TopicViewModel> GetFilteredList(TopicBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<TopicViewModel> GetFullList()
        {
            using (var context = new ForumDatabase())
            {
                return context.Topic.Include(rec => rec.Message)
                    .Select(rec => new TopicViewModel
                    {
                        Name = rec.Name,
                        NumberOfVisitors = rec.Numberofvisitors,
                        NumberOfMessages = rec.Numberofmessages,
                    }).ToList();
            }
        }

        public void Insert(TopicBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                context.Topic.Add(CreateModel(model, new Topic()));
                context.SaveChanges();
            }
        }
        public void Update(TopicBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Topic.FirstOrDefault(rec => rec.Name == model.Name);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(TopicBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Topic.FirstOrDefault(rec => rec.Name == model.Name);
                if (element != null)
                {
                    context.Topic.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Topic CreateModel(TopicBindingModel model, Topic topic)
        {
            topic.Name = model.Name;
            topic.Numberofmessages = model.NumberOfMessages;
            topic.Numberofvisitors = model.NumberOfVisitors;
            return topic;
        }
    }
}
