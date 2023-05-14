namespace Cinemania
{
    partial class PerfilUsuario
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
            btnToMain = new Button();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            button1 = new Button();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            button3 = new Button();
            dataGridView3 = new DataGridView();
            idFuncion = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnCambiarPassword = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // btnToMain
            // 
            btnToMain.Location = new Point(12, 11);
            btnToMain.Name = "btnToMain";
            btnToMain.Size = new Size(75, 23);
            btnToMain.TabIndex = 1;
            btnToMain.Text = "Main";
            btnToMain.UseVisualStyleBackColor = true;
            btnToMain.Click += btnToMain_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 63);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 375);
            tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 347);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Funciones Pasadas";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column6, Column7, Column8, Column9, Costo });
            dataGridView2.Location = new Point(6, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(759, 335);
            dataGridView2.TabIndex = 0;
            // 
            // Column6
            // 
            Column6.HeaderText = "Sala";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Pelicula";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.HeaderText = "Fecha";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.HeaderText = "Cantidad de Clientes";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Costo
            // 
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(button1);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 347);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Proximas Funciones";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(384, 10);
            label14.Name = "label14";
            label14.Size = new Size(27, 15);
            label14.TabIndex = 8;
            label14.Text = "----";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(275, 10);
            label13.Name = "label13";
            label13.Size = new Size(27, 15);
            label13.TabIndex = 7;
            label13.Text = "----";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(164, 10);
            label12.Name = "label12";
            label12.Size = new Size(27, 15);
            label12.TabIndex = 6;
            label12.Text = "----";
            // 
            // button1
            // 
            button1.Location = new Point(674, 6);
            button1.Name = "button1";
            button1.Size = new Size(112, 23);
            button1.TabIndex = 5;
            button1.Text = "Devolver Entrada";
            button1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(337, 10);
            label11.Name = "label11";
            label11.Size = new Size(41, 15);
            label11.TabIndex = 4;
            label11.Text = "Fecha:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(238, 10);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 3;
            label10.Text = "Sala:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(107, 10);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 2;
            label9.Text = "Pelicula:";
            // 
            // button3
            // 
            button3.Location = new Point(3, 6);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 1;
            button3.Text = "Refrescar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { idFuncion, Column10, Column11, Column12, Column13, Column14 });
            dataGridView3.Location = new Point(3, 35);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(781, 306);
            dataGridView3.TabIndex = 0;
            dataGridView3.CellContentDoubleClick += dataGridView3_CellContentDoubleClick;
            // 
            // idFuncion
            // 
            idFuncion.HeaderText = "Funcion";
            idFuncion.Name = "idFuncion";
            idFuncion.ReadOnly = true;
            idFuncion.Visible = false;
            // 
            // Column10
            // 
            Column10.HeaderText = "Sala";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // Column11
            // 
            Column11.HeaderText = "Pelicula";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            // 
            // Column12
            // 
            Column12.HeaderText = "Fecha";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            // 
            // Column13
            // 
            Column13.HeaderText = "Cantidad de Clientes";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            // 
            // Column14
            // 
            Column14.HeaderText = "Costo";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 20);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 3;
            label1.Text = "Mi Credito";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 20);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "----";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(213, 20);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 5;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(503, 20);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Nombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(352, 19);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 8;
            label6.Text = "Mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 20);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 9;
            label5.Text = "----";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(388, 20);
            label7.Name = "label7";
            label7.Size = new Size(27, 15);
            label7.TabIndex = 10;
            label7.Text = "----";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(560, 20);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 11;
            label8.Text = "----";
            // 
            // btnCambiarPassword
            // 
            btnCambiarPassword.Location = new Point(713, 3);
            btnCambiarPassword.Name = "btnCambiarPassword";
            btnCambiarPassword.Size = new Size(75, 38);
            btnCambiarPassword.TabIndex = 12;
            btnCambiarPassword.Text = "Cambiar Contraseña";
            btnCambiarPassword.UseVisualStyleBackColor = true;
            btnCambiarPassword.Click += btnCambiarPassword_Click;
            // 
            // PerfilUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCambiarPassword);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Controls.Add(btnToMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PerfilUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PerfilUsuario";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnToMain;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private DataGridView dataGridView2;
        private TabPage tabPage3;
        private DataGridView dataGridView3;
        private Button button3;
        private Label label5;
        private Label label7;
        private Label label8;
        private Button btnCambiarPassword;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Costo;
        private Button button1;
        private Label label11;
        private Label label10;
        private Label label9;
        private DataGridViewTextBoxColumn idFuncion;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private Label label14;
        private Label label13;
        private Label label12;
    }
}