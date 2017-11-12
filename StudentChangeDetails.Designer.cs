namespace BS_project2
{
    partial class StudentChangeDetails
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
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.full_name = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.change_the_details = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.output_firstname = new System.Windows.Forms.Label();
            this.output_lastname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_LastName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Location = new System.Drawing.Point(43, 51);
            this.textBox_FirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(68, 20);
            this.textBox_FirstName.TabIndex = 1;
            this.textBox_FirstName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // full_name
            // 
            this.full_name.AutoSize = true;
            this.full_name.Location = new System.Drawing.Point(165, 55);
            this.full_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.full_name.Name = "full_name";
            this.full_name.Size = new System.Drawing.Size(52, 13);
            this.full_name.TabIndex = 2;
            this.full_name.Text = "first name";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(180)));
            this.title.Location = new System.Drawing.Point(95, 12);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(116, 18);
            this.title.TabIndex = 4;
            this.title.Text = "change details";
            // 
            // change_the_details
            // 
            this.change_the_details.Location = new System.Drawing.Point(35, 168);
            this.change_the_details.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.change_the_details.Name = "change_the_details";
            this.change_the_details.Size = new System.Drawing.Size(75, 23);
            this.change_the_details.TabIndex = 5;
            this.change_the_details.Text = "change";
            this.change_the_details.UseVisualStyleBackColor = true;
            this.change_the_details.Click += new System.EventHandler(this.change_the_details_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(147, 168);
            this.exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(137, 23);
            this.exit.TabIndex = 6;
            this.exit.Text = "return to student menu";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // output_firstname
            // 
            this.output_firstname.AutoSize = true;
            this.output_firstname.Location = new System.Drawing.Point(43, 76);
            this.output_firstname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.output_firstname.Name = "output_firstname";
            this.output_firstname.Size = new System.Drawing.Size(0, 13);
            this.output_firstname.TabIndex = 8;
            // 
            // output_lastname
            // 
            this.output_lastname.AutoSize = true;
            this.output_lastname.Location = new System.Drawing.Point(43, 123);
            this.output_lastname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.output_lastname.Name = "output_lastname";
            this.output_lastname.Size = new System.Drawing.Size(0, 13);
            this.output_lastname.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "last name";
            // 
            // textBox1_LastName
            // 
            this.textBox1_LastName.Location = new System.Drawing.Point(43, 98);
            this.textBox1_LastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1_LastName.Name = "textBox1_LastName";
            this.textBox1_LastName.Size = new System.Drawing.Size(68, 20);
            this.textBox1_LastName.TabIndex = 9;
            this.textBox1_LastName.TextChanged += new System.EventHandler(this.textBox1_lastname_TextChanged);
            // 
            // StudentChangeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 229);
            this.Controls.Add(this.output_lastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1_LastName);
            this.Controls.Add(this.output_firstname);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.change_the_details);
            this.Controls.Add(this.title);
            this.Controls.Add(this.full_name);
            this.Controls.Add(this.textBox_FirstName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StudentChangeDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentChangeDetails";
            this.Load += new System.EventHandler(this.StudentChangeDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.Label full_name;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button change_the_details;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label output_firstname;
        private System.Windows.Forms.Label output_lastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1_LastName;
    }
}