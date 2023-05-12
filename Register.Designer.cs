namespace Cinemania
{
    partial class Register
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
            checkBox1 = new CheckBox();
            button2 = new Button();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnToLogin = new Button();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(250, 336);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(102, 19);
            checkBox1.TabIndex = 32;
            checkBox1.Text = "Administrador";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(246, 361);
            button2.Name = "button2";
            button2.Size = new Size(144, 23);
            button2.TabIndex = 31;
            button2.Text = "Registrarse";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(246, 300);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 30;
            label6.Text = "Fecha Nacimiento";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(355, 297);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 256);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 28;
            label5.Text = "Pass";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 212);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 27;
            label4.Text = "Mail";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(246, 156);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 26;
            label3.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 112);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 25;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 74);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 24;
            label1.Text = "DNI";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(340, 248);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 23;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(340, 204);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 22;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(340, 153);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 21;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(340, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 20;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(340, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 19;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // btnToLogin
            // 
            btnToLogin.Location = new Point(396, 361);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(140, 23);
            btnToLogin.TabIndex = 33;
            btnToLogin.Text = "Iniciar Sesion";
            btnToLogin.UseVisualStyleBackColor = true;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(820, 500);
            Controls.Add(btnToLogin);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Button button2;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnToLogin;
    }
}