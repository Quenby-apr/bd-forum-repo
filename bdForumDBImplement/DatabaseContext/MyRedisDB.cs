using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bdForumBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace bdForumDBImplement.DatabaseContext
{
    public class MyRedisDB
    {
        static int i = 50;
        private ConnectionMultiplexer redis;
        IDatabase db;
        public MyRedisDB()
        {
            redis = ConnectionMultiplexer.Connect("localhost");
            db = redis.GetDatabase();
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
        public void insertdata() {
            var topics = GetFullListTopic();
            i = 0;
            foreach (var topic in topics)
            {
                i++;
                db.SetAdd("topics", "tema" + i);
                db.SetAdd("tema" + i, topic.Name);
                db.SetAdd("tema" + i, topic.NumberOfMessages);
                db.SetAdd("tema" + i, topic.NumberOfVisitors);
                Console.WriteLine("добавление прошло");
            }
        }
        public void getdata() {
            List<string> mylist = new List<string>();
            var time1 = DateTime.Now;
            for (int j = 1; j <= i; j++) {
                mylist.Add(db.SetMembers("tema" + j).ToString());
            }
            var time2 = DateTime.Now;
            var result = time2 - time1;
            Console.WriteLine(result);
        }
    }
}
