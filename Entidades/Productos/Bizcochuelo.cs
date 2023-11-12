using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Stock;

namespace Entidades.Productos
{   
    /// <summary>
    /// Clase que representa un tipo específico de producto: Bizcochuelo.
    /// </summary>
    public class Bizcochuelo : Producto
    {
        private static int bizcochuelosCocoCocinados = 0;
        private static int bizcochuelosVainillaCocinados = 0;
        private static int bizcochuelosChocolateCocinados = 0;
        /// <summary>
        /// Obtiene o establece las cantidades de los diferentes sabores de bizcochuelo disponibles en el stock.
        /// </summary>
        private static Dictionary<Sabor, int> cantidades = new Dictionary<Sabor, int>
        {
            { Sabor.CHOCOLATE, 0 },
            { Sabor.VAINILLA, 0 },
            { Sabor.COCO, 0 }
        };

        /// <summary>
        /// Representa las cantidades de los diferentes sabores de bizcochuelo disponibles en el stock.
        /// </summary>

        public static Dictionary<Sabor, int> Cantidades
        {
            get { return cantidades; }
        }

        /// <summary>
        /// Constructor para la clase Bizcochuelo.
        /// </summary>
        /// <param name="nombre">Nombre del bizcochuelo.</param>
        public Bizcochuelo(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Método para producir un bizcochuelo de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del bizcochuelo a producir.</param>
        /// <returns>Devuelve verdadero si el bizcochuelo se produce con éxito; de lo contrario, falso.</returns>
        public override bool Producir(Sabor sabor)
        {
            int cantidadLeudante = 10;
            int cantidadHarina = 0;
            int cantidadAzucar = 0;
            int cantidadSabor = 10;

            switch (sabor)
            {
                case Sabor.CHOCOLATE:
                    cantidadHarina = 10;
                    cantidadAzucar = 20;
                    break;
                case Sabor.COCO:
                    cantidadHarina = 10;
                    cantidadAzucar = 15;
                    break;
                case Sabor.VAINILLA:
                    cantidadHarina = 10;
                    cantidadAzucar = 15;
                    break;
            }

            List<(string, int)> materiasPrimas = new List<(string, int)>
            {
                ("Leudante", cantidadLeudante),
                ("Harina", cantidadHarina),
                ("Azucar", cantidadAzucar),
                (sabor.ToString(), cantidadSabor)
            };

            if (Stock.UsarMateriasPrimas(materiasPrimas))
            {
                Cantidades[sabor] += 1;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Método para cocinar un cierto número de bizcochuelos de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del bizcochuelo a cocinar.</param>
        /// <param name="cantidad">Cantidad de bizcochuelos a cocinar.</param>
        /// <returns>Devuelve verdadero si se cocinan los bizcochuelos con éxito; de lo contrario, falso.</returns>
        public override bool Cocinar(Sabor sabor, int cantidad)
        {
            bool retorno = false;
            if (Cantidades.ContainsKey(sabor))
            {
                if (Cantidades[sabor] >= cantidad)
                {
                    switch (sabor)
                    {
                        case Sabor.CHOCOLATE:
                            bizcochuelosChocolateCocinados += cantidad;
                            break;
                        case Sabor.COCO:
                            bizcochuelosCocoCocinados += cantidad;
                            break;
                        case Sabor.VAINILLA:
                            bizcochuelosVainillaCocinados += cantidad;
                            break;
                    }
                    Cantidades[sabor] -= cantidad;
                    return true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Método para obtener la cantidad de bizcochuelos cocinadas de cada sabor actualmente.
        /// </summary>
        /// <returns>Detalles del stock de bizcochuelos cocinadas en forma de dictionary.</returns>
        public static Dictionary<string, int> ObtenerCantidadesCocinadas()
        {
            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();
            todasLasCantidades.Add("Bizcochuelo Coco", bizcochuelosCocoCocinados);
            todasLasCantidades.Add("Bizcochuelo Vainilla", bizcochuelosVainillaCocinados);
            todasLasCantidades.Add("Bizcochuelo Chocolate", bizcochuelosChocolateCocinados);
            return todasLasCantidades;
        }
    }
}
