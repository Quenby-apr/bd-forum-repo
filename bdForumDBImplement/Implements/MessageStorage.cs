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
    public class MessageStorage : IMessageStorage
    { 
        public MessageViewModel GetElement(MessageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumDatabase())
            {
                var message = context.Message.Include(rec => rec.Like).FirstOrDefault
                   (rec => rec.Id == model.Id);
                return message != null ? new MessageViewModel
                {
                    Id = message.Id,
                    Text = message.Text,
                    Time = message.Time,
                    LoginUser = message.Visitorlogin,
                    NameTopic = message.Topicname,
                } :
                null;
            }
        }

        public List<MessageViewModel> GetFilteredList(MessageBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                return context.Message.Include(rec => rec.Like).Where(rec => rec.Topicname.Contains(model.NameTopic) || (rec.Time>model.DateFrom && rec.Time<model.DateTo))
                    .Select(rec => new MessageViewModel
                    {
                        Id = rec.Id,
                        Text = rec.Text,
                        Time = rec.Time,
                        LoginUser = rec.Visitorlogin,
                        NameTopic = rec.Topicname,
                    }).ToList();
            }
        }

        public List<MessageViewModel> GetFullList()
        {
            using (var context = new ForumDatabase())
            {
                return context.Message.Include(rec => rec.Like)
                    .Select(rec => new MessageViewModel
                    {
                        Id = rec.Id,
                        Text = rec.Text,
                        Time = rec.Time,
                        LoginUser = rec.Visitorlogin,
                        NameTopic = rec.Topicname,
                    }).ToList();
            }
        }

        public void Insert(MessageBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                context.Message.Add(CreateModel(model, new Message()));
                context.SaveChanges();
            }
        }
        public void Update(MessageBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Message.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(MessageBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Message.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Message.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Message CreateModel(MessageBindingModel model, Message message)
        {
            message.Text = model.Text;
            message.Time = model.Time;
            message.Topicname = model.NameTopic;
            message.Visitorlogin = model.LoginUser;
            return message;
        }
    }
}
