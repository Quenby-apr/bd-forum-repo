namespace bdForum
{
    partial class FormMessage
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
            this.label = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(97, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Текст сообщения";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(16, 40);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(587, 354);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(132, 415);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(139, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(333, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.label);
            this.Name = "FormMessage";
            this.Text = "FormMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RichTextBox TextBox1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonCancel;
    }
}