using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    internal class Usuario
    {
        public enum TipoUsuario { Administrador = 1, Empleado = 2 }
        private string nombreUsuario;
        protected int dniUsuario;
        private string contrasenia;
        protected TipoUsuario tipoUsuario;

        public TipoUsuario Tipo
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        public int DniUsuario
        {
            get { return dniUsuario; }
            set { dniUsuario = value; }
        }

        public Usuario(string nombreUsuario, int dniUsuario, string contrasenia, int tipoUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.dniUsuario = dniUsuario;
            this.contrasenia = contrasenia;
            this.tipoUsuario = (TipoUsuario)tipoUsuario;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {nombreUsuario}");
            sb.AppendLine($"DNI: {dniUsuario}");
            sb.AppendLine($"Contraseña: {contrasenia}");
            sb.AppendLine($"Tipo de usuario: {tipoUsuario}");
            return sb.ToString();
        }

        public static bool operator ==(Usuario usuario1, Usuario usuario2)
        {
            return usuario1.dniUsuario == usuario2.dniUsuario;
        }

        public static bool operator !=(Usuario usuario1, Usuario usuario2)
        {
            return !(usuario1 == usuario2);
        }
    }
}