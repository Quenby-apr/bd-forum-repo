using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdForumBusinessLogic.BusinessLogic;
using Unity;

namespace bdForum
{
    public partial class FormReq1 : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly VisitorLogic visitorlogic;
        public FormReq1(VisitorLogic visitorlogic)
        {
            InitializeComponent();
            this.visitorlogic = visitorlogic;
        }

        private void FormReq1_Load(object sender, EventArgs e)
        {
            Program.myTimer = DateTime.Now;
            var list = visitorlogic.Read(new bdForumBusinessLogic.BindingModels.VisitorBindingModel
            {
                CountOfMessages = 25
            });
            if (list != null)
            {
                dataGridView1.DataSource = list;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            var answer = Program.myTimer - DateTime.Now;
            Console.WriteLine("Время выполнения: " + answer);
        }
    }
}
