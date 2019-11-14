namespace clientMessaging
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.enoTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 486);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(55, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dodge Financial";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(90, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(68, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Changing the world,\r\n one step at a time";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(487, 73);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 83);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // enoTextBox
            // 
            this.enoTextBox.Location = new System.Drawing.Point(470, 210);
            this.enoTextBox.Name = "enoTextBox";
            this.enoTextBox.Size = new System.Drawing.Size(137, 20);
            this.enoTextBox.TabIndex = 2;
            this.enoTextBox.Text = "Employee Number";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(470, 271);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(137, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.enoTextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox enoTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button button1;
    }
}

