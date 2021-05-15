using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace bdForumDBImplement.DatabaseContext
{
    public partial class MongoDB_ : DbContext
    {
        IMongoCollection<Message> messages;
        IMongoCollection<User> users;
        public MongoDB_()
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("forumdb");
            messages = database.GetCollection<Message>("messages");
            users = database.GetCollection<User>("users");
        }

        public class Message
        {
            public ObjectId _id { get; set; }
            public string text { get; set; }
            public string time { get; set; }
            public string userlogin { get; set; }
            public string topicname { get; set; }
            public Likelist[] Likelists { get; set; }
        }
        public class Likelist
        {
            public string name { get; set; }
        }
        public class User
        {
            public ObjectId _id { get; set; }
            public string login { get; set; }
            public string password { get; set; }
            public int totaltime { get; set; }
            public string role { get; set; }
            public string status { get; set; }
            public int countofmessages { get; set; }
            public int decency { get; set; }
            public int amountofhelp { get; set; }
        }
        public List<TopicViewModel> GetFullListTopic()
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
        public List<MessageViewModel> GetFilteredListMessages(MessageBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                return context.Message.Include(rec => rec.Like).Where(rec => rec.Topicname.Contains(model.NameTopic))
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
        public List<LikeViewModel> GetFilteredListLikes(LikeBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                return context.Like.Where(rec => rec.Messageid == model.IdMessage).Select(rec => new LikeViewModel
                {
                    LoginUser = rec.Visitorlogin,
                    IdMessage = rec.Messageid
                }).ToList();
            }
        }
        public List<Message> GetFullListMongoMessages()
        {
            var result = new List<Message>();
            var topics = GetFullListTopic();
            foreach (var topic in topics)
            {
                var messages = GetFilteredListMessages(new MessageBindingModel
                {
                    NameTopic = topic.Name
                });
                foreach (var message in messages)
                {
                    var likes = GetFilteredListLikes(new LikeBindingModel
                    {
                        IdMessage = message.Id
                    });
                    List<Likelist> _likes = new List<Likelist>();
                    foreach (var like in likes)
                    {
                        _likes.Add(new Likelist()
                            {
                            name = like.LoginUser
                        });
                    }
                    var mes = new Message();
                    mes.text = message.Text;
                    mes.time = message.Time.ToString();
                    mes.userlogin = message.LoginUser;
                    mes.topicname = message.NameTopic;
                    mes.Likelists = _likes.ToArray();
                    result.Add(mes);
                }
                Console.WriteLine("тема обработана");
            }
            Console.WriteLine("ОБРАБОТКА ТЕМ ЗАВЕРШЕНА");
            return result;
        }

        public List<VisitorViewModel> GetFullListVisitors()
        {
            using (var context = new ForumDatabase())
            {
                return context.Visitor
                    .Select(rec => new VisitorViewModel
                    {
                        LoginUser = rec.Login,
                        Password = rec.Password,
                        Email = rec.Email,
                        TotalTime = rec.TotalTime,
                        Status = rec.Status,
                        Decency = rec.Decency,
                        CountOfMessages = rec.Countmessages,
                    }).ToList();
            }
        }
        public List<ModeratorViewModel> GetFullListModerators()
        {
            using (var context = new ForumDatabase())
            {
                return context.Moderator
                    .Select(rec => new ModeratorViewModel
                    {
                        LoginUser = rec.Login,
                        Password = rec.Password,
                        Email = rec.Email,
                        TotalTime = rec.TotalTime,
                        AmountOfHelp = rec.Amountofhelp
                    }).ToList();
            }
        }
        public List<User> GetFullListMongoUsers()
        {
            var result = new List<User>();
            var visitors = GetFullListVisitors();
            var moderators = GetFullListModerators();
            foreach (var visitor in visitors)
            {
                var user = new User();
                user.login = visitor.LoginUser;
                user.password = visitor.Password;
                user.role = "visitor";
                user.status = visitor.Status;
                user.totaltime = visitor.TotalTime;
                user.countofmessages = visitor.CountOfMessages;
                user.decency = visitor.Decency;
                result.Add(user);
            }
            Console.WriteLine("посетители обработаны");
            foreach (var moderator in moderators) 
            {
                var user = new User();
                user.login = moderator.LoginUser;
                user.password = moderator.Password;
                user.role = "moderator";
                user.totaltime = moderator.TotalTime;
                user.amountofhelp = moderator.AmountOfHelp;
                result.Add(user);
            }
            Console.WriteLine("модеры обработаны");
            Console.WriteLine("ОБРАБОТКА ПОЛЬЗОВАТЕЛЕЙ ЗАВЕРШЕНА");
            return result;
        }
        public void Create()
        {
            var mess = GetFullListMongoMessages();
            var us = GetFullListMongoUsers();
            Console.WriteLine("ЗАПОЛНЕНИЕ ДАННЫМИ");
            messages.InsertManyAsync(mess);
            Console.WriteLine("сообщениЯ заполнены");
            users.InsertManyAsync(us); 
        }
    }
}
