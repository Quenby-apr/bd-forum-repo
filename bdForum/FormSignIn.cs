using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.BusinessLogic;
using Unity;

namespace bdForum
{
    public partial class FormSignIn : Form
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly VisitorLogic visitorlogic;
        private readonly ModeratorLogic moderatorlogic;
        public FormSignIn(VisitorLogic visitorlogic, ModeratorLogic moderatorlogic)
        {
            InitializeComponent();
            this.visitorlogic = visitorlogic;
            this.moderatorlogic = moderatorlogic;
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSignUp>();
            form.ShowDialog();
                Close();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var visitor = visitorlogic.Read(new VisitorBindingModel
            {
                LoginUser = textBoxLogin.Text,
                Password = textBoxPassword.Text
            })[0];
            var moder = moderatorlogic.Read(new ModeratorBindingModel
            {
                LoginUser = textBoxLogin.Text,
                Password = textBoxPassword.Text
            })[0];
            if (visitor != null) 
            {
                Program.Visitor = visitor;
                var form = Container.Resolve<FormMain>();
                form.ShowDialog();
            }
            else if (moder != null)
            {
                Program.Moderator = moder;
                Program.Visitor.LoginUser = moder.LoginUser;
                Program.Visitor.Password = moder.Password;
                var form = Container.Resolve<FormMain>();
                form.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Данные неверны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}
