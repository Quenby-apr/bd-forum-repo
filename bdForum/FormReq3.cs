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
    public partial class FormReq3 : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MessageLogic messagelogic;
        public FormReq3(MessageLogic messagelogic)
        {
            InitializeComponent();
            this.messagelogic = messagelogic;
        }

        private void FormReq3_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            Program.myTimer = DateTime.Now;
            var list = messagelogic.Read(new MessageBindingModel
            {
                DateFrom = dateTimePicker1.Value,
                DateTo = dateTimePicker2.Value
            });
            if (list != null)
            {
                dataGridView1.DataSource = list;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            var answer = Program.myTimer - DateTime.Now;
            Console.WriteLine("Время выполнения: " + answer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
