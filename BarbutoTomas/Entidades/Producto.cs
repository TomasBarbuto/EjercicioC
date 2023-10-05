using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Producto
    {
        //cada vez que yo cree un producto tengo que tener en cuenta que materia prima voy a necesitar para crearlo.
        //necesito crear una lista de materia prima para poder agregarle las materias primas que necesito para crear el producto.
        protected string nombre;
        protected int cantidad;
        protected List<MateriaPrima> Ingredientes;

        public Producto(string nombre, int cantidad, List<MateriaPrima> Ingredientes)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.Ingredientes = Ingredientes;   
        }

        //Bien necesito ahora que cuado yo cree un producto me agregue a la lista de materia prima para poder agregarle las materias primas que necesito para crear el producto.
        //necesito crear un metodo que me agregue a la lista de materia prima para poder agregarle las materias primas que necesito para crear el producto.
        public void AgregarMateriaPrima(MateriaPrima materiaPrima, int cantidad)
        {
            if (this.Ingredientes is null)
            {
                this.Ingredientes = new List<MateriaPrima>();
            }
            this.Ingredientes.Add(materiaPrima);
        }

        //necesito crear un metodo que me devuelva la informacion del producto.
        
        public string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Producto: {this.nombre}");
            sb.AppendLine($"Cantidad: {this.cantidad}");
            return sb.ToString();
        }
    }
}
