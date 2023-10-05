using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Usuarios.Usuario;

namespace Entidades.Usuarios
{
    internal class Supervisor : Operario
    {
        //generame el cosntructor
        public Supervisor(string nombreUsuario, int dniUsuario, string contrasenia, int tipoUsuario) : base(nombreUsuario, dniUsuario, contrasenia, tipoUsuario)
        {
            idUsuario = GenerarIdUsuario();
        }

        public override string GenerarIdUsuario()
        {
            return $"SU{this.dniUsuario}";
        }

        //generame el tostring
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {idUsuario}");
            sb.AppendLine($"Nombre: {NombreUsuario}");
            sb.AppendLine($"DNI: {dniUsuario}");
            sb.AppendLine($"Tipo de usuario: {tipoUsuario}");
            return sb.ToString();
        }
    }
}
