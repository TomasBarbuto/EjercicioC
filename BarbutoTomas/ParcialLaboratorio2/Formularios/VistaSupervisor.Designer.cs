namespace ParcialLaboratorio2
{
    partial class VistaSupervisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaSupervisor));
            label10 = new Label();
            lblLegajo = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblNombreUsuario = new Label();
            button7 = new Button();
            button6 = new Button();
            button4 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Hobo Std", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(191, 113, 44);
            label10.Location = new Point(648, 28);
            label10.Name = "label10";
            label10.Size = new Size(305, 68);
            label10.TabIndex = 11;
            label10.Text = "ZAFIRA S.A";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLegajo
            // 
            lblLegajo.AutoSize = true;
            lblLegajo.Location = new Point(51, 110);
            lblLegajo.Margin = new Padding(3);
            lblLegajo.Name = "lblLegajo";
            lblLegajo.Size = new Size(92, 20);
            lblLegajo.TabIndex = 16;
            lblLegajo.Text = "OP40881706";
            lblLegajo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(51, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(284, 27);
            dateTimePicker1.TabIndex = 15;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(51, 72);
            lblNombreUsuario.Margin = new Padding(3);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(92, 20);
            lblNombreUsuario.TabIndex = 14;
            lblNombreUsuario.Text = "OP40881706";
            lblNombreUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button7
            // 
            button7.Location = new Point(51, 317);
            button7.Name = "button7";
            button7.Size = new Size(151, 32);
            button7.TabIndex = 19;
            button7.Text = "Consultar Stock";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(51, 355);
            button6.Name = "button6";
            button6.Size = new Size(151, 32);
            button6.TabIndex = 18;
            button6.Text = "Observaciones";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.Location = new Point(51, 393);
            button4.Name = "button4";
            button4.Size = new Size(151, 32);
            button4.TabIndex = 17;
            button4.Text = "Cerrar Sesion";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(51, 203);
            button1.Name = "button1";
            button1.Size = new Size(151, 32);
            button1.TabIndex = 22;
            button1.Text = "Listar Operarios";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(51, 241);
            button2.Name = "button2";
            button2.Size = new Size(151, 32);
            button2.TabIndex = 21;
            button2.Text = "Produccion";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(51, 279);
            button3.Name = "button3";
            button3.Size = new Size(151, 32);
            button3.TabIndex = 20;
            button3.Text = "Pedir Stock";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(340, 203);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(597, 223);
            dataGridView1.TabIndex = 23;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // VistaSupervisor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(984, 461);
            ControlBox = false;
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(lblLegajo);
            Controls.Add(dateTimePicker1);
            Controls.Add(lblNombreUsuario);
            Controls.Add(label10);
            MaximizeBox = false;
            Name = "VistaSupervisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zafira S.A (SUPERVISOR)";
            Load += VistaSupervisor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private Label lblLegajo;
        private DateTimePicker dateTimePicker1;
        private Label lblNombreUsuario;
        private Button button7;
        private Button button6;
        private Button button4;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
    }
}