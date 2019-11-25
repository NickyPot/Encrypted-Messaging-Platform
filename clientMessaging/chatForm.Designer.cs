namespace clientMessaging
{
    partial class chatForm
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
            this.connectToUserBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.enoTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.chatList = new System.Windows.Forms.ListBox();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.importantCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // connectToUserBtn
            // 
            this.connectToUserBtn.Location = new System.Drawing.Point(372, 259);
            this.connectToUserBtn.Name = "connectToUserBtn";
            this.connectToUserBtn.Size = new System.Drawing.Size(75, 40);
            this.connectToUserBtn.TabIndex = 11;
            this.connectToUserBtn.Text = "Connect To User";
            this.connectToUserBtn.UseVisualStyleBackColor = true;
            this.connectToUserBtn.Click += new System.EventHandler(this.connectToUserBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID of user to connect to";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // enoTextBox
            // 
            this.enoTextBox.Location = new System.Drawing.Point(93, 280);
            this.enoTextBox.Name = "enoTextBox";
            this.enoTextBox.Size = new System.Drawing.Size(100, 20);
            this.enoTextBox.TabIndex = 9;
            this.enoTextBox.TextChanged += new System.EventHandler(this.enoTextBox_TextChanged);
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(372, 353);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // chatList
            // 
            this.chatList.FormattingEnabled = true;
            this.chatList.Location = new System.Drawing.Point(93, 12);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(323, 212);
            this.chatList.TabIndex = 7;
            this.chatList.SelectedIndexChanged += new System.EventHandler(this.chatList_SelectedIndexChanged);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(93, 355);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(251, 20);
            this.chatTextBox.TabIndex = 6;
            this.chatTextBox.TextChanged += new System.EventHandler(this.chatTextBox_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // importantCheck
            // 
            this.importantCheck.AutoSize = true;
            this.importantCheck.Location = new System.Drawing.Point(17, 357);
            this.importantCheck.Name = "importantCheck";
            this.importantCheck.Size = new System.Drawing.Size(70, 17);
            this.importantCheck.TabIndex = 13;
            this.importantCheck.Text = "Important";
            this.importantCheck.UseVisualStyleBackColor = true;
            this.importantCheck.CheckedChanged += new System.EventHandler(this.importantCheck_CheckedChanged);
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 405);
            this.Controls.Add(this.importantCheck);
            this.Controls.Add(this.connectToUserBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enoTextBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.chatTextBox);
            this.Name = "chatForm";
            this.Text = "chatForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chatForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectToUserBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox enoTextBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.ListBox chatList;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox importantCheck;
    }
}