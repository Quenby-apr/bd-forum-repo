using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.BusinessLogic;
using Unity;

namespace bdForum
{
    public partial class FormSignUp : Form
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly VisitorLogic visitorlogic;
        private readonly ModeratorLogic moderatorlogic;
        public FormSignUp(VisitorLogic visitorlogic, ModeratorLogic moderatorlogic)
        {
            InitializeComponent();
            this.visitorlogic = visitorlogic;
            this.moderatorlogic = moderatorlogic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Посетитель"))
            {
                visitorlogic.CreateOrUpdate(new VisitorBindingModel { 
                    LoginUser=textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Email = textBoxEmail.Text,
                    CountOfMessages=0,
                    Decency=1000,
                    TotalTime = 0,
                    Status = "approved"
                });
            }
            if (comboBox1.SelectedItem.Equals("Модератор"))
            {
                moderatorlogic.CreateOrUpdate(new ModeratorBindingModel
                {
                    LoginUser = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Email = textBoxEmail.Text, 
                    AmountOfHelp = 0,
                    TotalTime = 0 
                });
            }
            var form = Container.Resolve<FormSignIn>();
            form.ShowDialog();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Посетитель");
            comboBox1.Items.Add("Модератор");
        }
    }
}
