using System;
using System.Collections.Generic;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class LikeLogic
    {
        private readonly ILikeStorage likeStorage;
        public LikeLogic(ILikeStorage likeStorage)
        {
            this.likeStorage = likeStorage;
        }
        public List<LikeViewModel> Read(LikeBindingModel model)
        {
            if (model == null)
            {
                return likeStorage.GetFullList();
            }
            if (model.LoginUser != null)
            {
                return new List<LikeViewModel> { likeStorage.GetElement(model) };
            }
            return likeStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(LikeBindingModel model)
        {
            var element = likeStorage.GetElement(new LikeBindingModel
            {
                LoginUser = model.LoginUser,
                IdMessage = model.IdMessage
            });
            if (element != null)
            {
                throw new Exception("Такой лайк поставлен");
            }
                likeStorage.Insert(model);
        }
        public void Delete(LikeBindingModel model)
        {
            var element = likeStorage.GetElement(new LikeBindingModel {
                LoginUser = model.LoginUser,
                IdMessage = model.IdMessage
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            likeStorage.Delete(model);
        }
    }
}
