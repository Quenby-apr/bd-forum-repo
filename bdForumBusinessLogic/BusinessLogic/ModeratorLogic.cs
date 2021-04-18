using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class ModeratorLogic
    {
        private readonly IModeratorStorage moderatorStorage;
        public ModeratorLogic(IModeratorStorage moderatorStorage)
        {
            this.moderatorStorage = moderatorStorage;
        }
        public List<ModeratorViewModel> Read(ModeratorBindingModel model)
        {
            if (model == null)
            {
                return moderatorStorage.GetFullList();
            }
            if (model.LoginUser != null)
            {
                return new List<ModeratorViewModel> { moderatorStorage.GetElement(model) };
            }
            return moderatorStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ModeratorBindingModel model)
        {
            if (moderatorStorage.GetElement(new ModeratorBindingModel {
                LoginUser = model.LoginUser,
                Password = model.Password
            }) != null)
            {
                moderatorStorage.Update(model);
            }
            else
            {
                moderatorStorage.Insert(model);
            }
        }
        public void Delete(ModeratorBindingModel model)
        {
            var element = moderatorStorage.GetElement(new ModeratorBindingModel { LoginUser = model.LoginUser });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            moderatorStorage.Delete(model);
        }
    }
}
