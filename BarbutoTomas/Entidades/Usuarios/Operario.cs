using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    internal class Operario : Usuario
    {
        protected string idUsuario;

        public Operario(string nombreUsuario, int dniUsuario, string contrasenia, int tipoUsuario) : base(nombreUsuario, dniUsuario, contrasenia, tipoUsuario)
        {
            idUsuario = GenerarIdUsuario();
        }

        public string IdUsuario
        {
            get => idUsuario;
        }

        public virtual string GenerarIdUsuario()
        {
            return $"OP{this.dniUsuario}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {idUsuario}");
            sb.AppendLine($"Nombre: {NombreUsuario}");
            sb.AppendLine($"DNI: {dniUsuario}");
            sb.AppendLine($"Tipo de usuario: {this.tipoUsuario}");
            return sb.ToString();
        }
    }
}
