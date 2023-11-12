using Entidades;
using Entidades.Productos;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Stock;
using static System.Windows.Forms.DataFormats;

namespace ParcialLaboratorio2
{
    /// <summary>
    /// Clase parcial que representa la interfaz de usuario para un supervisor en el sistema.
    /// </summary>
    public partial class VistaSupervisor : Form
    {
        private Supervisor supervisor;
        private List<Usuario> usuarios;

        /// <summary>
        /// Constructor para la clase VistaSupervisor.
        /// </summary>
        /// <param name="supervisor">El supervisor asociado a la vista.</param>
        /// <param name="usuarios">La lista de usuarios del sistema.</param>
        public VistaSupervisor(Supervisor supervisor, List<Usuario> usuarios)
        {
            InitializeComponent();
            this.supervisor = supervisor;
            this.usuarios = usuarios;
        }

        /// <summary>
        /// Maneja el evento de carga de la vista del supervisor.
        /// Establece el IDusuario actual en "lbl_nombreusuario".
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void VistaSupervisor_Load(object sender, EventArgs e)
        {
            lbl_nombreusuario.Text = supervisor.IdUsuario;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "cerrar sesión".
        /// cierra la sesión actual y te devuelve al LOGIN.
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
                }
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "consultar stock".
        /// muestra y actualiza la información del stock en la interfaz.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_consultarstock_Click(object sender, EventArgs e)
        {
            dgv_supervisor.DataSource = null;
            dgv_supervisor.Columns.Clear();

            dgv_supervisor.Columns.Add("Material", "Material");
            dgv_supervisor.Columns.Add("Cantidad", "Cantidad");

            Dictionary<string, int> diccionarioStock = Stock.ObtenerDatosStock();

            foreach (var item in diccionarioStock)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv_supervisor, item.Key, item.Value.ToString());

                if (item.Value <= 20 && item.Value >= 1)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (item.Value == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }

                dgv_supervisor.Rows.Add(row);
            }

            dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "lista de operarios".
        /// muestra la lista de los Usuarios en la interfaz.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_listaoperarios_Click(object sender, EventArgs e)
        {
            dgv_supervisor.DataSource = null;
            dgv_supervisor.Columns.Clear();

            dgv_supervisor.AutoGenerateColumns = true;
            dgv_supervisor.DataSource = usuarios;
            dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Maneja el evento de clic del botón 'btn_pedirstock', permitiendo al usuario agregar más materia prima o cantidad de sabores al stock.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>

        private void btn_pedirstock_Click(object sender, EventArgs e)
        {
            List<string> materiasPrimas = new List<string>
            {
                "Harina",
                "Azucar",
                "Gelatina",
                "Leudantes",
                "Almidon",
                "Gelificantes"
            };

            List<string> sabores = Enum.GetNames(typeof(Stock.Sabor)).ToList();

            List<string> options = new List<string>();
            options.AddRange(materiasPrimas);
            options.AddRange(sabores);

            string selectedOption = PromptSelection("Seleccione la materia prima o sabor que desea agregar:", "Cargar Stock", options);

            if (!string.IsNullOrEmpty(selectedOption))
            {
                string input = PromptInput($"Ingrese la cantidad adicional de {selectedOption}:", "Cantidad adicional");
                if (int.TryParse(input, out int cantidad) && cantidad >= 0)
                {
                    if (materiasPrimas.Contains(selectedOption))
                    {
                        Stock.AgregarMateriaPrima(selectedOption, cantidad);
                    }
                    else if (sabores.Contains(selectedOption))
                    {
                        Stock.AgregarCantidadSabor((Stock.Sabor)Enum.Parse(typeof(Stock.Sabor), selectedOption), cantidad);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Muestra un prompt de selección con la etiqueta, el título y las opciones especificados.
        /// </summary>
        /// <param name="labelText">El texto de la etiqueta en el cuadro de diálogo.</param>
        /// <param name="caption">El título del cuadro de diálogo.</param>
        /// <param name="options">Las opciones disponibles para seleccionar.</param>
        /// <returns>La opción seleccionada por el usuario.</returns>
        private string PromptSelection(string labelText, string caption, List<string> options)
        {
            Form prompt = new Form();
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;

            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = labelText };
            ComboBox inputBox = new ComboBox() { Left = 50, Top = 50, Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };
            inputBox.Items.AddRange(options.ToArray());

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 70, Top = 100 };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return inputBox.Text;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "pedir stock".
        /// Permite al supervisor solicitar más cantidad de materias primas o sabores específicos.
        /// </summary>
        /// <param name="labelText">El texto de la etiqueta en el cuadro de diálogo.</param>
        /// <param name="caption">El título del cuadro de diálogo.</param>
        private string PromptInput(string labelText, string caption)
        {
            int result;
            Form prompt = new Form();
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.Width = 500;
            prompt.Height = 200;
            prompt.Text = caption;

            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = labelText };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 70, Top = 100 };
            confirmation.Click += (sender, e) =>
            {
                if (int.TryParse(inputBox.Text, out result) && result <= 1000)
                {
                    prompt.Close();
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un número válido menor o igual a 1000.");
                }
            };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return inputBox.Text;
        }


        /// <summary>
        /// Maneja el evento de clic en el botón "producción".
        /// Oculta el formulario actual y muestra el formulario de la vista del operario asociado a este supervisor.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btn_produccion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form vistaOperario = new VistaOperario(supervisor);
            vistaOperario.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón 'btn_RegistroCocina', mostrando un registro de las cantidades cocinadas de bizcochuelo, gelatina y flan, en un DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</

        private void btn_RegistroCocina_Click(object sender, EventArgs e)
        {
            dgv_supervisor.DataSource = null;
            dgv_supervisor.Columns.Clear();

            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();

            Dictionary<string, int> cantidadesBizcochuelo = Bizcochuelo.ObtenerCantidadesCocinadas();
            foreach (var cantidad in cantidadesBizcochuelo)
            {
                todasLasCantidades.Add(cantidad.Key, cantidad.Value);
            }

            Dictionary<string, int> cantidadesGelatina = Gelatina.ObtenerCantidadesCocinadas();
            foreach (var cantidad in cantidadesGelatina)
            {
                todasLasCantidades.Add(cantidad.Key, cantidad.Value);
            }

            Dictionary<string, int> cantidadesFlan = Flan.ObtenerCantidadesCocinadas();
            foreach (var cantidad in cantidadesFlan)
            {
                todasLasCantidades.Add(cantidad.Key, cantidad.Value);
            }

            bool todasCero = true;

            foreach (var cantidad in todasLasCantidades.Values)
            {
                if (cantidad != 0)
                {
                    todasCero = false;
                    break;
                }
            }

            if (todasCero)
            {
                MessageBox.Show("No hay stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgv_supervisor.DataSource = todasLasCantidades.ToList();
                dgv_supervisor.Columns[0].HeaderText = "Producto";
                dgv_supervisor.Columns[1].HeaderText = "Cantidad Cocinada";
                dgv_supervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_supervisor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                foreach (DataGridViewRow row in dgv_supervisor.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        int cantidad = Convert.ToInt32(row.Cells[1].Value);
                        if (cantidad >= 1 && cantidad <= 5)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (cantidad == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.IndianRed;
                        }
                    }
                }
            }
        }

        private void btn_RegProducido_Click(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<Sabor, int>> todosLosStocks = new Dictionary<string, Dictionary<Sabor, int>>
            {
                { "Bizcochuelo", Bizcochuelo.Cantidades },
                { "Gelatina", Gelatina.Cantidades },
                { "Flan", Flan.Cantidades }
            };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Producto", typeof(string));
            dataTable.Columns.Add("Sabor", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(int));

            bool todasCero = true;

            foreach (var stock in todosLosStocks)
            {
                foreach (var cantidad in stock.Value.Values)
                {
                    if (cantidad != 0)
                    {
                        todasCero = false;
                        break;
                    }
                }

                if (!todasCero)
                {
                    break;
                }
            }

            if (todasCero)
            {
                MessageBox.Show("No hay stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgv_supervisor.Dock = DockStyle.Fill;
                dgv_supervisor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

                foreach (var stock in todosLosStocks)
                {
                    foreach (var cantidad in stock.Value)
                    {
                        dataTable.Rows.Add(stock.Key, cantidad.Key, cantidad.Value);
                    }
                }

                dgv_supervisor.DataSource = dataTable;

                foreach (DataGridViewColumn column in dgv_supervisor.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
    }
}
