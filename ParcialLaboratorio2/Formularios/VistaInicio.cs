using Entidades;
using Entidades.Usuarios;

namespace ParcialLaboratorio2
{
    /// <summary>
    /// Clase parcial que representa el formulario de inicio de sesión de la interfaz de usuario.
    /// Permite a los usuarios iniciar sesión como supervisor u operario y redirigirlos al formulario correspondiente una vez que se autentican correctamente.
    /// </summary>
    public partial class VistaInicio : Form
    {
        private List<Usuario> usuarios;
        Supervisor supervisor = new Supervisor("Lautaro", 10000000, "L10", 1);
        Operario operario1 = new Operario("Lucas", 20000000, "L20", 2);
        Operario operario2 = new Operario("Mathi", 30000000, "M30", 2);
        Operario operario3 = new Operario("Nico", 40000000, "N40", 2);
        Operario operario4 = new Operario("Tomas", 40000000, "T40", 2);

        /// <summary>
        /// Constructor de la clase VistaInicio. Inicializa una nueva instancia del formulario de inicio de sesión.
        /// </summary>
        public VistaInicio()
        {
            InitializeComponent();
            usuarios = new List<Usuario>();
        }

        /// <summary>
        /// Agrega los usuarios a la lista de usuarios y configura el stock de sabor en 50 al cargar el formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Inicio_Load(object sender, EventArgs e)
        {
            supervisor.AgregarUsuario(supervisor, usuarios);
            operario1.AgregarUsuario(operario1, usuarios);
            operario2.AgregarUsuario(operario2, usuarios);
            operario3.AgregarUsuario(operario3, usuarios);
            operario4.AgregarUsuario(operario4, usuarios);
            Stock.SetearStockSabor(50);
        }

        /// <summary>
        /// Escribe el nombre de usuario y la contraseña como "Lautaro" y "L10" al hacer clic en el botón de Supervisor.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btn_supervisor_Click(object sender, EventArgs e)
        {
            in_usuario.Text = "Lautaro";
            in_contraseña.Text = "L10";
        }

        /// <summary>
        /// Escribe el nombre de usuario y la contraseña como "Lucas" y "L20" al hacer clic en el botón de Operario.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btn_operario_Click(object sender, EventArgs e)
        {
            in_usuario.Text = "Lucas";
            in_contraseña.Text = "L20";
        }

        /// <summary>
        /// Verifica el nombre de usuario y la contraseña ingresados y muestra el formulario correspondiente según el tipo de usuario al hacer clic en el botón de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btn_iniciocesion_Click(object sender, EventArgs e)
        {

            string nombreUsuarioIngresado = in_usuario.Text;
            string contraseniaIngresada = in_contraseña.Text;

            foreach (var usuario in usuarios)
            {
                if (usuario.NombreUsuario == nombreUsuarioIngresado && usuario.Contrasenia == contraseniaIngresada)
                {

                    this.Hide();

                    if (usuario is Supervisor)
                    {
                        VistaSupervisor formSupervisor = new VistaSupervisor(supervisor, usuarios);
                        formSupervisor.Show();
                    }
                    else if (usuario is Operario)
                    {
                        VistaOperario formOperario = new VistaOperario(operario1);
                        formOperario.Show();
                    }

                    MessageBox.Show("Inicio de sesión exitoso");
                    return;
                }
            }
            MessageBox.Show("Nombre de usuario o contraseña incorrectos. Inténtelo de nuevo.");
        }

        /// <summary>
        /// Evento FormClosing para manejar el cierre del formulario.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}