namespace BS_project2
{
    partial class ChangeNameOfCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeNameOfCourse));
            this.comboBox1_selectdepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2_selectcourse = new System.Windows.Forms.ComboBox();
            this.textBox1_newcoursename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Change_Name = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1_selectdepartment
            // 
            this.comboBox1_selectdepartment.FormattingEnabled = true;
            this.comboBox1_selectdepartment.Location = new System.Drawing.Point(434, 174);
            this.comboBox1_selectdepartment.Name = "comboBox1_selectdepartment";
            this.comboBox1_selectdepartment.Size = new System.Drawing.Size(232, 28);
            this.comboBox1_selectdepartment.TabIndex = 1;
            this.comboBox1_selectdepartment.SelectedIndexChanged += new System.EventHandler(this.comboBox1_selectdepartment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "select department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "select course";
            // 
            // comboBox2_selectcourse
            // 
            this.comboBox2_selectcourse.FormattingEnabled = true;
            this.comboBox2_selectcourse.Location = new System.Drawing.Point(434, 231);
            this.comboBox2_selectcourse.Name = "comboBox2_selectcourse";
            this.comboBox2_selectcourse.Size = new System.Drawing.Size(232, 28);
            this.comboBox2_selectcourse.TabIndex = 3;
            // 
            // textBox1_newcoursename
            // 
            this.textBox1_newcoursename.Location = new System.Drawing.Point(434, 291);
            this.textBox1_newcoursename.Name = "textBox1_newcoursename";
            this.textBox1_newcoursename.Size = new System.Drawing.Size(232, 26);
            this.textBox1_newcoursename.TabIndex = 5;
            this.textBox1_newcoursename.TextChanged += new System.EventHandler(this.textBox1_newcoursename_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "new course name";
            // 
            // Change_Name
            // 
            this.Change_Name.Location = new System.Drawing.Point(69, 391);
            this.Change_Name.Name = "Change_Name";
            this.Change_Name.Size = new System.Drawing.Size(158, 63);
            this.Change_Name.TabIndex = 8;
            this.Change_Name.Text = "change name";
            this.Change_Name.UseVisualStyleBackColor = true;
            this.Change_Name.Click += new System.EventHandler(this.Change_Name_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(638, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(572, 355);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // ChangeNameOfCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 518);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Change_Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1_newcoursename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2_selectcourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1_selectdepartment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeNameOfCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeNameOfCourse";
            this.Load += new System.EventHandler(this.ChangeNameOfCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1_selectdepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2_selectcourse;
        private System.Windows.Forms.TextBox textBox1_newcoursename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Change_Name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}