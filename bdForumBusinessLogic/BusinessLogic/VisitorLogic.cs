using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class VisitorLogic
    {
        private readonly IVisitorStorage visitorStorage;
        public VisitorLogic(IVisitorStorage visitorStorage)
        {
            this.visitorStorage = visitorStorage;
        }
        public List<VisitorViewModel> Read(VisitorBindingModel model)
        {
            if (model == null)
            {
                return visitorStorage.GetFullList();
            }
            if (model.LoginUser != null)
            {
                return new List<VisitorViewModel> { visitorStorage.GetElement(model) };
            }
            return visitorStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(VisitorBindingModel model)
        {
            if (visitorStorage.GetElement(new VisitorBindingModel
            {
                LoginUser = model.LoginUser,
                Password = model.Password
            }) != null)
            {
                visitorStorage.Update(model);
            }
            else
            {
                visitorStorage.Insert(model);
            }
        }
        public void Delete(VisitorBindingModel model)
        {
            var element = visitorStorage.GetElement(new VisitorBindingModel { LoginUser = model.LoginUser });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            visitorStorage.Delete(model);
        }
    }
}
