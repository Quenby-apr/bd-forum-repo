using System;
using System.Collections.Generic;
using System.Text;

namespace bdForumBusinessLogic.ViewModels
{
    public class TopicMongoViewModel
    {
        public string nametopic { get; set; }
        public List<MessageViewModel> messages { get; set; }
        public List<LikeViewModel> likes { get; set; }
    }
}
