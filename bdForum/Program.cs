using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdForumBusinessLogic.BusinessLogic;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;
using bdForumDBImplement.DatabaseContext;
using bdForumDBImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace bdForum
{
    static class Program
    {
        public static ModeratorViewModel Moderator { get; set; }
        public static VisitorViewModel Visitor { get; set; }
        public static DateTime myTimer { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormSignIn>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ILikeStorage, LikeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMessageStorage, MessageStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IModeratorStorage, ModeratorStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITopicStorage, TopicStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IVisitorStorage, VisitorStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<LikeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MessageLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ModeratorLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TopicLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<VisitorLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
