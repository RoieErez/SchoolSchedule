namespace BS_project2.HOD
{
    partial class Add_new_lecturer_practitioner
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.IDText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.practioner = new System.Windows.Forms.CheckBox();
            this.lecturer = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 39);
            this.label1.TabIndex = 9;
            this.label1.Text = "Add new lecturer or practioner";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 250);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(25, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "ID:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(443, 336);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 34);
            this.button3.TabIndex = 16;
            this.button3.Text = "Previous screen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // IDText
            // 
            this.IDText.Location = new System.Drawing.Point(144, 105);
            this.IDText.Margin = new System.Windows.Forms.Padding(4);
            this.IDText.Name = "IDText";
            this.IDText.Size = new System.Drawing.Size(209, 22);
            this.IDText.TabIndex = 17;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(144, 137);
            this.NameText.Margin = new System.Windows.Forms.Padding(4);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(209, 22);
            this.NameText.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(25, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Full name:";
            // 
            // practioner
            // 
            this.practioner.AutoSize = true;
            this.practioner.Location = new System.Drawing.Point(261, 210);
            this.practioner.Margin = new System.Windows.Forms.Padding(4);
            this.practioner.Name = "practioner";
            this.practioner.Size = new System.Drawing.Size(94, 21);
            this.practioner.TabIndex = 23;
            this.practioner.Text = "practioner";
            this.practioner.UseVisualStyleBackColor = true;
            // 
            // lecturer
            // 
            this.lecturer.AutoSize = true;
            this.lecturer.Location = new System.Drawing.Point(172, 210);
            this.lecturer.Margin = new System.Windows.Forms.Padding(4);
            this.lecturer.Name = "lecturer";
            this.lecturer.Size = new System.Drawing.Size(78, 21);
            this.lecturer.TabIndex = 24;
            this.lecturer.Text = "lecturer";
            this.lecturer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(25, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Type:";
            // 
            // Add_new_lecturer_practitioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 385);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lecturer);
            this.Controls.Add(this.practioner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.IDText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Add_new_lecturer_practitioner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new lecturer or practitioner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_new_lecturer_practitioner_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Add_new_lecturer_practitioner_FormClosed);
            this.Load += new System.EventHandler(this.Add_new_lecturer_practitioner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox IDText;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox practioner;
        private System.Windows.Forms.CheckBox lecturer;
        private System.Windows.Forms.Label label5;
    }
}