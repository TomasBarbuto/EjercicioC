using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Stock
    {
        public enum Sabor{COCO, VAINILLA, CHOCOLATE, FRUTILLA, FRAMBUESA, CEREZA, CARAMELO}

        private static int harina = 0;
        private static int azucar = 0;
        private static int gelatina = 0;
        private static int leudantes = 0;
        private static Dictionary<Sabor, int> sabores = new Dictionary<Sabor, int>();
        private static int almidon = 0;
        private static int gelificantes = 0;

        //Necesito crear las propiedades de estas variables staticas ya que en algun momento voy a consultar por su cantidad
        //y tambien poder setearle mas cantidad.
        public static int Harina
        {
            get { return harina; }
            set { harina = value; }
        }



        public static void AgregarSabor(Sabor sabor, int cantidad)
        {
            if (sabores.ContainsKey(sabor))
            {
                sabores[sabor] += cantidad;
            }
            else
            {
                sabores[sabor] = cantidad;
            }
        }
    }
}
