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
            dt_fechahora = new DateTimePicker();
            lbl_nombreusuario = new Label();
            btn_consultarstock = new Button();
            btn_cerrarsesion = new Button();
            btn_produccion = new Button();
            btn_pedirstock = new Button();
            dgv_supervisor = new DataGridView();
            btn_listaoperarios = new Button();
            btn_RegistroCocina = new Button();
            btn_RegProducido = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_supervisor).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(191, 113, 44);
            label10.Location = new Point(667, 28);
            label10.Name = "label10";
            label10.Size = new Size(294, 55);
            label10.TabIndex = 11;
            label10.Text = "ZAFIRA S.A";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // dt_fechahora
            // 
            dt_fechahora.Location = new Point(35, 28);
            dt_fechahora.Name = "dt_fechahora";
            dt_fechahora.Size = new Size(284, 27);
            dt_fechahora.TabIndex = 15;
            // 
            // lbl_nombreusuario
            // 
            lbl_nombreusuario.AutoSize = true;
            lbl_nombreusuario.Location = new Point(35, 72);
            lbl_nombreusuario.Margin = new Padding(3);
            lbl_nombreusuario.Name = "lbl_nombreusuario";
            lbl_nombreusuario.Size = new Size(92, 20);
            lbl_nombreusuario.TabIndex = 14;
            lbl_nombreusuario.Text = "OP40881706";
            lbl_nombreusuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_consultarstock
            // 
            btn_consultarstock.Location = new Point(35, 350);
            btn_consultarstock.Name = "btn_consultarstock";
            btn_consultarstock.Size = new Size(151, 32);
            btn_consultarstock.TabIndex = 19;
            btn_consultarstock.Text = "Consultar Stock";
            btn_consultarstock.UseVisualStyleBackColor = true;
            btn_consultarstock.Click += btn_consultarstock_Click;
            // 
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.Location = new Point(35, 388);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(151, 32);
            btn_cerrarsesion.TabIndex = 17;
            btn_cerrarsesion.Text = "Cerrar Sesion";
            btn_cerrarsesion.UseVisualStyleBackColor = true;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            // 
            // btn_produccion
            // 
            btn_produccion.Location = new Point(35, 236);
            btn_produccion.Name = "btn_produccion";
            btn_produccion.Size = new Size(151, 32);
            btn_produccion.TabIndex = 21;
            btn_produccion.Text = "Produccion";
            btn_produccion.UseVisualStyleBackColor = true;
            btn_produccion.Click += btn_produccion_Click;
            // 
            // btn_pedirstock
            // 
            btn_pedirstock.Location = new Point(35, 274);
            btn_pedirstock.Name = "btn_pedirstock";
            btn_pedirstock.Size = new Size(151, 32);
            btn_pedirstock.TabIndex = 20;
            btn_pedirstock.Text = "Pedir Stock";
            btn_pedirstock.UseVisualStyleBackColor = true;
            btn_pedirstock.Click += btn_pedirstock_Click;
            // 
            // dgv_supervisor
            // 
            dgv_supervisor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_supervisor.Location = new Point(244, 198);
            dgv_supervisor.Name = "dgv_supervisor";
            dgv_supervisor.RowTemplate.Height = 29;
            dgv_supervisor.Size = new Size(504, 222);
            dgv_supervisor.TabIndex = 23;
            // 
            // btn_listaoperarios
            // 
            btn_listaoperarios.Location = new Point(35, 198);
            btn_listaoperarios.Name = "btn_listaoperarios";
            btn_listaoperarios.Size = new Size(151, 32);
            btn_listaoperarios.TabIndex = 24;
            btn_listaoperarios.Text = "Listar Operarios";
            btn_listaoperarios.UseVisualStyleBackColor = true;
            btn_listaoperarios.Click += btn_listaoperarios_Click;
            // 
            // btn_RegistroCocina
            // 
            btn_RegistroCocina.Location = new Point(35, 312);
            btn_RegistroCocina.Name = "btn_RegistroCocina";
            btn_RegistroCocina.Size = new Size(151, 32);
            btn_RegistroCocina.TabIndex = 25;
            btn_RegistroCocina.Text = "Registro Cocina";
            btn_RegistroCocina.UseVisualStyleBackColor = true;
            btn_RegistroCocina.Click += btn_RegistroCocina_Click;
            // 
            // btn_RegProducido
            // 
            btn_RegProducido.Location = new Point(810, 198);
            btn_RegProducido.Name = "btn_RegProducido";
            btn_RegProducido.Size = new Size(151, 32);
            btn_RegProducido.TabIndex = 26;
            btn_RegProducido.Text = "Registro Producido";
            btn_RegProducido.UseVisualStyleBackColor = true;
            btn_RegProducido.Click += btn_RegProducido_Click;
            // 
            // VistaSupervisor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(984, 461);
            ControlBox = false;
            Controls.Add(btn_RegProducido);
            Controls.Add(btn_RegistroCocina);
            Controls.Add(btn_listaoperarios);
            Controls.Add(dgv_supervisor);
            Controls.Add(btn_produccion);
            Controls.Add(btn_pedirstock);
            Controls.Add(btn_consultarstock);
            Controls.Add(btn_cerrarsesion);
            Controls.Add(dt_fechahora);
            Controls.Add(lbl_nombreusuario);
            Controls.Add(label10);
            MaximizeBox = false;
            Name = "VistaSupervisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zafira S.A (Supervisor)";
            Load += VistaSupervisor_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_supervisor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private DateTimePicker dt_fechahora;
        private Label lbl_nombreusuario;
        private Button btn_consultarstock;
        private Button btn_cerrarsesion;
        private Button btn_produccion;
        private Button btn_pedirstock;
        private DataGridView dgv_supervisor;
        private Button btn_listaoperarios;
        private Button btn_RegistroCocina;
        private Button btn_RegProducido;
    }
}