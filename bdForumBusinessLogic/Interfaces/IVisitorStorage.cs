using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IVisitorStorage
    {
        List<VisitorViewModel> GetFullList();
        List<VisitorViewModel> GetFilteredList(VisitorBindingModel model);
        VisitorViewModel GetElement(VisitorBindingModel model);
        void Insert(VisitorBindingModel model);
        void Update(VisitorBindingModel model);
        void Delete(VisitorBindingModel model);
    }
}
