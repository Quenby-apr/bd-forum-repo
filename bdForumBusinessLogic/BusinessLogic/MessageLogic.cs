using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class MessageLogic
    {
        private readonly IMessageStorage messageStorage;
        public MessageLogic(IMessageStorage messageStorage)
        {
            this.messageStorage = messageStorage;
        }
        public List<MessageViewModel> Read(MessageBindingModel model)
        {
            if (model == null)
            {
                return messageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MessageViewModel> { messageStorage.GetElement(model) };
            }
            return messageStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(MessageBindingModel model)
        {
            if (model.Id.HasValue)
            {
                messageStorage.Update(model);
            }
            else
            {
                messageStorage.Insert(model);
            }
        }
        public void Delete(MessageBindingModel model)
        {
            var element = messageStorage.GetElement(new MessageBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            messageStorage.Delete(model);
        }
    }
}

