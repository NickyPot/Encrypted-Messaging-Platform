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
            this.SuspendLayout();
            // 
            // connectToUserBtn
            // 
            this.connectToUserBtn.Location = new System.Drawing.Point(372, 280);
            this.connectToUserBtn.Name = "connectToUserBtn";
            this.connectToUserBtn.Size = new System.Drawing.Size(75, 40);
            this.connectToUserBtn.TabIndex = 11;
            this.connectToUserBtn.Text = "Connect To User";
            this.connectToUserBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID of user to connect to";
            // 
            // enoTextBox
            // 
            this.enoTextBox.Location = new System.Drawing.Point(93, 280);
            this.enoTextBox.Name = "enoTextBox";
            this.enoTextBox.Size = new System.Drawing.Size(100, 20);
            this.enoTextBox.TabIndex = 9;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(372, 353);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            // 
            // chatList
            // 
            this.chatList.FormattingEnabled = true;
            this.chatList.Location = new System.Drawing.Point(93, 12);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(323, 212);
            this.chatList.TabIndex = 7;
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(93, 355);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(251, 20);
            this.chatTextBox.TabIndex = 6;
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 405);
            this.Controls.Add(this.connectToUserBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enoTextBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.chatTextBox);
            this.Name = "chatForm";
            this.Text = "chatForm";
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
    }
}