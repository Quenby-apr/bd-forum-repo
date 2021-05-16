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
using bdForumDBImplement.DatabaseContext;
using Unity;

namespace bdForum
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly TopicLogic topiclogic;
        private readonly MessageLogic messagelogic;
        public MongoDB_ mongo = new MongoDB_();
        public MyRedisDB redis = new MyRedisDB();
        public FormMain(TopicLogic topiclogic, MessageLogic messagelogic)
        {
            InitializeComponent();
            this.topiclogic = topiclogic;
            this.messagelogic = messagelogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.myTimer = DateTime.Now;
                var list = topiclogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                var answer = Program.myTimer - DateTime.Now;
                Console.WriteLine("Время выполнения: " + answer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEditTopic>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var this_topic = topiclogic.Read(new TopicBindingModel
            {
                Name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value)
            })[0];
            topiclogic.CreateOrUpdate(new TopicBindingModel
            {
                Name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value),
                NumberOfMessages = this_topic.NumberOfMessages,
                NumberOfVisitors = this_topic.NumberOfVisitors + 1
            });
            var form = Container.Resolve<FormMessages>();
            form.nameTopic = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormEditTopic>();
                form.Name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string name = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        topiclogic.Delete(new TopicBindingModel { Name = name });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonReq1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReq1>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
            var data1 = DateTime.Now;
            for (int i=0; i<20000;i++)
            {
                topiclogic.CreateOrUpdate(new TopicBindingModel {
                    Name = "тема для проверки номер " + i,
                    NumberOfMessages=0,
                    NumberOfVisitors=0
                });
            }
            var data2 = DateTime.Now;
            var result = data2.Millisecond - data1.Millisecond;
            Console.WriteLine(result);
        }

        private void buttonReq3_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReq3>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttontrans_Click(object sender, EventArgs e)
        {
            mongo.Create();
            MessageBox.Show("Перенос данных начат", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonreq_Click(object sender, EventArgs e)
        {
            redis.getdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> mylist = new List<int>();
            var time1 = DateTime.Now;
            var list = topiclogic.Read(null);
            foreach (var rec in list)
            {
                mylist.Add(1);
            }
            var time2 = DateTime.Now;
            Console.WriteLine(time2 - time1);
        }
    }
}
