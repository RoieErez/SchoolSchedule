namespace BS_project2
{
    partial class StudentMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMenu));
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.change_info = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.random_password = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 138);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "view schedule";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(217, 138);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(113, 45);
            this.button8.TabIndex = 8;
            this.button8.Text = "My info";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(339, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(49, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // change_info
            // 
            this.change_info.Location = new System.Drawing.Point(36, 281);
            this.change_info.Margin = new System.Windows.Forms.Padding(2);
            this.change_info.Name = "change_info";
            this.change_info.Size = new System.Drawing.Size(100, 38);
            this.change_info.TabIndex = 11;
            this.change_info.Text = "change info";
            this.change_info.UseVisualStyleBackColor = true;
            this.change_info.Click += new System.EventHandler(this.change_info_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // random_password
            // 
            this.random_password.Location = new System.Drawing.Point(36, 238);
            this.random_password.Margin = new System.Windows.Forms.Padding(2);
            this.random_password.Name = "random_password";
            this.random_password.Size = new System.Drawing.Size(100, 33);
            this.random_password.TabIndex = 13;
            this.random_password.Text = "random password";
            this.random_password.UseVisualStyleBackColor = true;
            this.random_password.Click += new System.EventHandler(this.random_password_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 42);
            this.button1.TabIndex = 14;
            this.button1.Text = "Messages";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(159, 281);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 38);
            this.button3.TabIndex = 15;
            this.button3.Text = "change password";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StudentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 333);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.random_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.change_info);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button change_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button random_password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}