namespace ParcialLaboratorio2
{
    partial class VistaInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInicio));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Hobo Std", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(191, 113, 44);
            label1.Location = new Point(143, 97);
            label1.Name = "label1";
            label1.Size = new Size(305, 68);
            label1.TabIndex = 0;
            label1.Text = "ZAFIRA S.A";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Hobo Std", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(143, 265);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(198, 34);
            label2.TabIndex = 1;
            label2.Text = "Ingrese Usuario";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(143, 302);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(305, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(143, 404);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(305, 27);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Hobo Std", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(143, 367);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(239, 34);
            label3.TabIndex = 4;
            label3.Text = "Ingrese Contraseña";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(459, 550);
            button1.Name = "button1";
            button1.Size = new Size(113, 49);
            button1.TabIndex = 5;
            button1.Text = "Operario";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(12, 550);
            button2.Name = "button2";
            button2.Size = new Size(114, 49);
            button2.TabIndex = 6;
            button2.Text = "Supervisor";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(223, 462);
            button3.Name = "button3";
            button3.Size = new Size(143, 32);
            button3.TabIndex = 7;
            button3.Text = "Iniciar Sesion";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // VistaInicio
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(584, 611);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Lemon", 11.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "VistaInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zafira S.A";
            TransparencyKey = Color.FromArgb(224, 224, 224);
            Load += Inicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}