using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IModeratorStorage
    {
        List<ModeratorViewModel> GetFullList();
        List<ModeratorViewModel> GetFilteredList(ModeratorBindingModel model);
        ModeratorViewModel GetElement(ModeratorBindingModel model);
        void Insert(ModeratorBindingModel model);
        void Update(ModeratorBindingModel model);
        void Delete(ModeratorBindingModel model);
    }
}
