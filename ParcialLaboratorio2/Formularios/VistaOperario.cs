using Entidades;
using Entidades.Productos;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Stock;
using static Entidades.Usuarios.Usuario;
using static System.Windows.Forms.DataFormats;

namespace ParcialLaboratorio2
{
    /// <summary>
    /// Clase parcial que representa el formulario de la interfaz de usuario para el operario.
    /// Permite al operario realizar diversas operaciones, como la producción de bizcochuelos, gelatinas y flanes, y ver el stock actual, entre otras funciones.
    /// </summary>
    public partial class VistaOperario : Form
    {
        private Operario operario;
        Bizcochuelo bizcochuelo = new Bizcochuelo("Bizochuelo");
        Gelatina gelatina = new Gelatina("Gelatina");
        Flan flan = new Flan("Flan");

        /// <summary>
        /// Inicializa una nueva instancia de la clase VistaOperario con el operario especificado.
        /// </summary>
        /// <param name="operario">El operario que utiliza el formulario.</param>
        public VistaOperario(Operario operario)
        {
            InitializeComponent();
            this.operario = operario;
        }

        /// <summary>
        /// Maneja el evento de carga de la vista del operario.
        /// Actualiza la visualización de la vista según el tipo de usuario (administrador o no).
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void VistaOperario_Load(object sender, EventArgs e)
        {
            Operario operario = this.operario;
            lbl_nombreusuario.Text = operario.IdUsuario;
            if (operario.Tipo == TipoUsuario.Administrador)
            {
                btn_volver.Visible = true;
                btn_cerrarsesion.Visible = false;
            }
            else
            {
                btn_volver.Visible = false;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "cerrar sesión".
        /// Muestra un cuadro de diálogo para confirmar si el usuario desea cerrar sesión y, si es así, cierra la sesión y muestra la vista de inicio.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmar cierre de sesión", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {

                foreach (Form form in Application.OpenForms)
                {
                    if (form is VistaInicio)
                    {
                        this.Hide();
                        form.Show();
                    }

                    if (operario is Supervisor)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
            }
        }
        /// <summary>
        /// Maneja el evento de clic en el botón "ver stock".
        /// Muestra un cuadro de diálogo con la información del stock actual.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_stock_Click(object sender, EventArgs e)
        {
            Form StockDisponible = new Form();
            StockDisponible.Text = "Stock Disponible";
            StockDisponible.Size = new Size(500, 400);
            StockDisponible.FormBorderStyle = FormBorderStyle.FixedDialog;
            StockDisponible.StartPosition = FormStartPosition.CenterScreen;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;

            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView.RowTemplate.Height = 40;

            dataGridView.Columns.Add("Material", "Material");
            dataGridView.Columns.Add("Cantidad", "Cantidad");

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ColumnHeadersHeight = 40;

            Dictionary<string, int> diccionarioStock = Stock.ObtenerDatosStock();

            foreach (var item in diccionarioStock)
            {
                int cantidad = item.Value;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView, item.Key, cantidad);

                if (cantidad >= 1 && cantidad <= 20)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (cantidad == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }

                dataGridView.Rows.Add(row);
            }

            tableLayoutPanel.Controls.Add(dataGridView, 0, 0);

            StockDisponible.Controls.Add(tableLayoutPanel);

            StockDisponible.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "fabricar bizcochuelo".
        /// Produce la cantidad específica de bizcochuelos de diferentes sabores según las cantidades ingresadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_bizcochuelo_Click(object sender, EventArgs e)
        {
            int cantidadChocolate = (int)cntd_bizchoco.Value;
            int cantidadVainilla = (int)cntd_bizvainilla.Value;
            int cantidadCoco = (int)cntd_bizcoco.Value;

            int fabricadosChocolate = 0;
            int fabricadosVainilla = 0;
            int fabricadosCoco = 0;
            int noFabricadosChocolate = 0;
            int noFabricadosVainilla = 0;
            int noFabricadosCoco = 0;

            StringBuilder producidos = new StringBuilder();
            StringBuilder noProducidos = new StringBuilder();

            for (int i = 0; i < cantidadChocolate; i++)
            {
                if (bizcochuelo.Producir(Sabor.CHOCOLATE))
                {
                    fabricadosChocolate++;
                }
                else
                {
                    noFabricadosChocolate++;
                }
            }

            if (fabricadosChocolate > 0)
            {
                producidos.AppendLine($"Bizcochuelo de chocolate = {fabricadosChocolate}");
            }
            if (noFabricadosChocolate > 0)
            {
                noProducidos.AppendLine($"Bizcochuelo de chocolate = {noFabricadosChocolate}");
            }

            for (int i = 0; i < cantidadVainilla; i++)
            {
                if (bizcochuelo.Producir(Sabor.VAINILLA))
                {
                    fabricadosVainilla++;
                }
                else
                {
                    noFabricadosVainilla++;
                }
            }
            if (fabricadosVainilla > 0)
            {
                producidos.AppendLine($"Bizcochuelo de vainilla = {fabricadosVainilla}");
            }
            if (noFabricadosVainilla > 0)
            {
                noProducidos.AppendLine($"Bizcochuelo de vainilla = {noFabricadosVainilla}");
            }

            for (int i = 0; i < cantidadCoco; i++)
            {
                if (bizcochuelo.Producir(Sabor.COCO))
                {
                    fabricadosCoco++;
                }
                else
                {
                    noFabricadosCoco++;
                }
            }
            if (fabricadosCoco > 0)
            {
                producidos.AppendLine($"Bizcochuelo de coco = {fabricadosCoco}");
            }
            if (noFabricadosCoco > 0)
            {
                noProducidos.AppendLine($"Bizcochuelo de coco= {noFabricadosCoco}");
            }

            if (producidos.Length > 0 || noProducidos.Length > 0)
            {
                StringBuilder message = new StringBuilder();

                if (producidos.Length > 0)
                {
                    message.AppendLine("Producción exitosa:");
                    message.Append(producidos);
                    message.AppendLine();
                }

                if (noProducidos.Length > 0)
                {
                    message.AppendLine("No se pudo fabricar por falta de stock:");
                    message.Append(noProducidos);
                }

                MessageBox.Show(message.ToString(), "Producción de bizcochuelos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No ingresó cantidades a fabricar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            cntd_bizchoco.Value = 0;
            cntd_bizvainilla.Value = 0;
            cntd_bizcoco.Value = 0;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "fabricar gelatina".
        /// Produce la cantidad específica de gelatinas de diferentes sabores según las cantidades ingresadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_gelatina_Click(object sender, EventArgs e)
        {
            int cantidadFrambuesa = (int)cntd_gelframbuesa.Value;
            int cantidadFrutilla = (int)cntd_gelfrutilla.Value;
            int cantidadCereza = (int)cntd_gelcereza.Value;

            int fabricadosFrambuesa = 0;
            int fabricadosFrutilla = 0;
            int fabricadosCereza = 0;
            int noFabricadosFrambuesa = 0;
            int noFabricadosFrutilla = 0;
            int noFabricadosCereza = 0;

            StringBuilder producidos = new StringBuilder();
            StringBuilder noProducidos = new StringBuilder();

            for (int i = 0; i < cantidadFrambuesa; i++)
            {
                if (gelatina.Producir(Sabor.FRAMBUESA))
                {
                    fabricadosFrambuesa++;
                }
                else
                {
                    noFabricadosFrambuesa++;
                }
            }

            if (fabricadosFrambuesa > 0)
            {
                producidos.AppendLine($"Gelatina de frambuesa = {fabricadosFrambuesa}");
            }
            if (noFabricadosFrambuesa > 0)
            {
                noProducidos.AppendLine($"Gelatina de frambuesa = {noFabricadosFrambuesa}");
            }

            for (int i = 0; i < cantidadFrutilla; i++)
            {
                if (gelatina.Producir(Sabor.FRUTILLA))
                {
                    fabricadosFrutilla++;
                }
                else
                {
                    noFabricadosFrutilla++;
                }
            }
            if (fabricadosFrutilla > 0)
            {
                producidos.AppendLine($"Gelatina de frutilla = {fabricadosFrutilla}");
            }
            if (noFabricadosFrutilla > 0)
            {
                noProducidos.AppendLine($"Gelatina de frutilla = {noFabricadosFrutilla}");
            }

            for (int i = 0; i < cantidadCereza; i++)
            {
                if (gelatina.Producir(Sabor.CEREZA))
                {
                    fabricadosCereza++;
                }
                else
                {
                    noFabricadosCereza++;
                }
            }
            if (fabricadosCereza > 0)
            {
                producidos.AppendLine($"Gelatina de cereza = {fabricadosCereza}");
            }
            if (noFabricadosCereza > 0)
            {
                noProducidos.AppendLine($"Gelatina de cereza = {noFabricadosCereza}");
            }

            if (producidos.Length > 0 || noProducidos.Length > 0)
            {
                StringBuilder message = new StringBuilder();

                if (producidos.Length > 0)
                {
                    message.AppendLine("Producción exitosa:");
                    message.Append(producidos);
                    message.AppendLine();
                }

                if (noProducidos.Length > 0)
                {
                    message.AppendLine("No se pudo fabricar por falta de stock:");
                    message.Append(noProducidos);
                }

                MessageBox.Show(message.ToString(), "Producción de gelatinas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No ingresó cantidades a fabricar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cntd_gelframbuesa.Value = 0;
            cntd_gelfrutilla.Value = 0;
            cntd_gelcereza.Value = 0;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "fabricar flan".
        /// Produce la cantidad específica de flanes de diferentes sabores según las cantidades ingresadas.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_flan_Click(object sender, EventArgs e)
        {
            int cantidadCaramelo = (int)cntd_flancaramelo.Value;
            int cantidadChocolate = (int)cntd_flanchoco.Value;
            int cantidadVainilla = (int)cntd_flanvainilla.Value;

            int fabricadosCaramelo = 0;
            int fabricadosChocolate = 0;
            int fabricadosVainilla = 0;
            int noFabricadosCaramelo = 0;
            int noFabricadosChocolate = 0;
            int noFabricadosVainilla = 0;

            StringBuilder producidos = new StringBuilder();
            StringBuilder noProducidos = new StringBuilder();

            for (int i = 0; i < cantidadCaramelo; i++)
            {
                if (flan.Producir(Sabor.CARAMELO))
                {
                    fabricadosCaramelo++;
                }
                else
                {
                    noFabricadosCaramelo++;
                }
            }

            if (fabricadosCaramelo > 0)
            {
                producidos.AppendLine($"Flan de caramelo = {fabricadosCaramelo}");
            }
            if (noFabricadosCaramelo > 0)
            {
                noProducidos.AppendLine($"Flan de caramelo = {noFabricadosCaramelo}");
            }

            for (int i = 0; i < cantidadChocolate; i++)
            {
                if (flan.Producir(Sabor.CHOCOLATE))
                {
                    fabricadosChocolate++;
                }
                else
                {
                    noFabricadosChocolate++;
                }
            }
            if (fabricadosChocolate > 0)
            {
                producidos.AppendLine($"Flan de chocolate = {fabricadosChocolate}");
            }
            if (noFabricadosChocolate > 0)
            {
                noProducidos.AppendLine($"Flan de chocolate = {noFabricadosChocolate}");
            }

            for (int i = 0; i < cantidadVainilla; i++)
            {
                if (flan.Producir(Sabor.VAINILLA))
                {
                    fabricadosVainilla++;
                }
                else
                {
                    noFabricadosVainilla++;
                }
            }
            if (fabricadosVainilla > 0)
            {
                producidos.AppendLine($"Flan de vainilla = {fabricadosVainilla}");
            }
            if (noFabricadosVainilla > 0)
            {
                noProducidos.AppendLine($"Flan de vainilla = {noFabricadosVainilla}");
            }

            if (producidos.Length > 0 || noProducidos.Length > 0)
            {
                StringBuilder message = new StringBuilder();

                if (producidos.Length > 0)
                {
                    message.AppendLine("Producción exitosa:");
                    message.Append(producidos);
                    message.AppendLine();
                }

                if (noProducidos.Length > 0)
                {
                    message.AppendLine("No se pudo fabricar por falta de stock:");
                    message.Append(noProducidos);
                }

                MessageBox.Show(message.ToString(), "Producción de flanes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No ingresó cantidades a fabricar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cntd_flancaramelo.Value = 0;
            cntd_flanchoco.Value = 0;
            cntd_flanvainilla.Value = 0;
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "volver".
        /// Muestra el formulario del supervisor correspondiente y oculta el formulario actual del operario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_volver_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is VistaSupervisor)
                {
                    this.Hide();
                    form.Show();
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "cocina".
        /// Muestra el formulario de la vista de cocina y pasa los datos del operario actual a la vista de cocina.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_cocina_Click(object sender, EventArgs e)
        {

            Operario operario = this.operario;
            bool hayInstancia = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is VistaCocina)
                {
                    hayInstancia = true;
                    form.Show();
                }
            }

            if (!hayInstancia)
            {
                VistaCocina vistaCocina = new VistaCocina(operario);
                vistaCocina.Show();
            }
        }
    }
}
