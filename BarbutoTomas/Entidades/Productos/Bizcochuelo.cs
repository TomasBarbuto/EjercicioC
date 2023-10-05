using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Productos
{
    internal class Bizcochuelo : Producto
    {

        public enum Sabores { Chocolate, Vainilla, Coco, Frutilla, Cereza, Frambuesa, Caramelo }
        protected Sabores tipoDeSabor;
        //necesito crear un constructor que me pida el nombre del producto, la cantidad y el sabor.
        public Bizcochuelo(string nombre, int cantidad, Sabores tipoDeSabor) : base(nombre, cantidad)
        {
            this.tipoDeSabor = tipoDeSabor;
        }



    }
}
