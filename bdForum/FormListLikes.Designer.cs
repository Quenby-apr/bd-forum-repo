namespace bdForum
{
    partial class FormListLikes
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
            this.listBoxLikes = new System.Windows.Forms.ListBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(110, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Список лайкнувших:";
            // 
            // listBoxLikes
            // 
            this.listBoxLikes.FormattingEnabled = true;
            this.listBoxLikes.Location = new System.Drawing.Point(13, 30);
            this.listBoxLikes.Name = "listBoxLikes";
            this.listBoxLikes.Size = new System.Drawing.Size(261, 329);
            this.listBoxLikes.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(97, 372);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(97, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormListLikes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 407);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listBoxLikes);
            this.Controls.Add(this.label);
            this.Name = "FormListLikes";
            this.Text = "FormListLikes";
            this.Load += new System.EventHandler(this.FormListLikes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ListBox listBoxLikes;
        private System.Windows.Forms.Button buttonClose;
    }
}