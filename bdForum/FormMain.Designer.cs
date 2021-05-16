namespace bdForum
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonReq1 = new System.Windows.Forms.Button();
            this.buttonReq3 = new System.Windows.Forms.Button();
            this.buttontrans = new System.Windows.Forms.Button();
            this.buttonreq = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(682, 451);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(698, 45);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(698, 102);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 23);
            this.buttonEnter.TabIndex = 2;
            this.buttonEnter.Text = "Перейти";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(698, 158);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(698, 215);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(698, 263);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonReq1
            // 
            this.buttonReq1.Location = new System.Drawing.Point(698, 320);
            this.buttonReq1.Name = "buttonReq1";
            this.buttonReq1.Size = new System.Drawing.Size(75, 23);
            this.buttonReq1.TabIndex = 6;
            this.buttonReq1.Text = "Запрос 1";
            this.buttonReq1.UseVisualStyleBackColor = true;
            this.buttonReq1.Click += new System.EventHandler(this.buttonReq1_Click);
            // 
            // buttonReq3
            // 
            this.buttonReq3.Location = new System.Drawing.Point(698, 349);
            this.buttonReq3.Name = "buttonReq3";
            this.buttonReq3.Size = new System.Drawing.Size(75, 23);
            this.buttonReq3.TabIndex = 7;
            this.buttonReq3.Text = "Запрос 3";
            this.buttonReq3.UseVisualStyleBackColor = true;
            this.buttonReq3.Click += new System.EventHandler(this.buttonReq3_Click);
            // 
            // buttontrans
            // 
            this.buttontrans.Location = new System.Drawing.Point(698, 393);
            this.buttontrans.Name = "buttontrans";
            this.buttontrans.Size = new System.Drawing.Size(75, 45);
            this.buttontrans.TabIndex = 8;
            this.buttontrans.Text = "Перенос данных";
            this.buttontrans.UseVisualStyleBackColor = true;
            this.buttontrans.Click += new System.EventHandler(this.buttontrans_Click);
            // 
            // buttonreq
            // 
            this.buttonreq.Location = new System.Drawing.Point(808, 349);
            this.buttonreq.Name = "buttonreq";
            this.buttonreq.Size = new System.Drawing.Size(75, 89);
            this.buttonreq.TabIndex = 9;
            this.buttonreq.Text = "редис";
            this.buttonreq.UseVisualStyleBackColor = true;
            this.buttonreq.Click += new System.EventHandler(this.buttonreq_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 68);
            this.button1.TabIndex = 10;
            this.button1.Text = "постгрес";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonreq);
            this.Controls.Add(this.buttontrans);
            this.Controls.Add(this.buttonReq3);
            this.Controls.Add(this.buttonReq1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonReq1;
        private System.Windows.Forms.Button buttonReq3;
        private System.Windows.Forms.Button buttontrans;
        private System.Windows.Forms.Button buttonreq;
        private System.Windows.Forms.Button button1;
    }
}