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
    public partial class FormMessages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MessageLogic messagelogic;
        private readonly TopicLogic topiclogic;
        private readonly LikeLogic likelogic;
        public string nameTopic;
        public FormMessages(MessageLogic messagelogic, LikeLogic likelogic, TopicLogic topiclogic)
        {
            InitializeComponent();
            this.messagelogic = messagelogic;
            this.likelogic = likelogic;
            this.topiclogic = topiclogic;
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.myTimer = DateTime.Now;
                var list = messagelogic.Read(new MessageBindingModel {NameTopic = nameTopic});
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[4].Visible = true;
                }
                var answer = Program.myTimer - DateTime.Now;
                Console.WriteLine("Время выполнения: " + answer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMessage>();
            form.nameTopic = nameTopic;
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonLike_Click(object sender, EventArgs e)
        {
            try
            {
                likelogic.CreateOrUpdate(new LikeBindingModel
                {
                    LoginUser = Program.Visitor.LoginUser,
                    IdMessage = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value)
                });
                MessageBox.Show("Лайк поставлен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        messagelogic.Delete(new MessageBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonListLikes_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormListLikes>();
            form.IDMessage = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value); 
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
