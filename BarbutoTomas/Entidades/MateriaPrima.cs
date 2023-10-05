using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class MateriaPrima
    {
        protected string nombre;
        protected int cantidadDiponible;

        public MateriaPrima(string nombre, int cantidadDiponible)
        {
            this.nombre = nombre;
            this.cantidadDiponible = cantidadDiponible;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int CantidadDiponible
        {
            get { return this.cantidadDiponible; }
            set { this.cantidadDiponible = value; }
        }

        //Necesito crear un metodo que me devuelva la informacion de la materia prima.
        public string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Materia Prima: {this.nombre}");
            sb.AppendLine($"Cantidad disponible: {this.cantidadDiponible}");
            return sb.ToString();
        }
        //necesito crear un metodo en donde se valide que la materi prima nunca sea menor a 0 cuando se le resta.
        public bool RestarMateriaPrima(int cantidad)
        {
            bool retorno = false;
            if (this.cantidadDiponible >= cantidad)
            {
                this.cantidadDiponible -= cantidad;
                retorno = true;
            }
            return retorno;
        }
        // ahora necesito crear el metodo donde le puedo setear mas materia prima es decir sumarle una cantidad validando que sea un numero, este metodo se lo voy a pasar la propiedad para que vaya variando su cantidad durante el programa.
        public void SumarMateriaPrima(int cantidad)
        {
            if (cantidad > 0)
            {
                this.cantidadDiponible += cantidad;
            }
        }

        //necesito sobrecargar el metodo == para que si instancio otra materia prima con el mismo nombre me devuelva true.
        public static bool operator ==(MateriaPrima materia1, MateriaPrima materia2)
        {
            bool retorno = false;
            if (materia1.nombre == materia2.nombre)
            {
                retorno = true;
            }
            return retorno;
        }
        //ahora sobrecarga el metodo != para que si instancio otra materia prima con el mismo nombre me devuelva false.
        public static bool operator !=(MateriaPrima materia1, MateriaPrima materia2)
        {
            return !(materia1.nombre == materia2.nombre);
        }
    }
}
