using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface ILikeStorage
    {
        List<LikeViewModel> GetFullList();
        List<LikeViewModel> GetFilteredList(LikeBindingModel model);
        LikeViewModel GetElement(LikeBindingModel model);
        void Insert(LikeBindingModel model);
        void Update(LikeBindingModel model);
        void Delete(LikeBindingModel model);
    }
}
