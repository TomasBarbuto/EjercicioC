using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Stock;

namespace Entidades.Productos
{
    /// <summary>
    /// Clase que representa un tipo específico de producto: Flan.
    /// </summary>
    public class Flan : Producto
    {
        private static int flanesCarameloCocinados = 0;
        private static int flanesChocolateCocinados = 0;
        private static int flanesVainillaCocinados = 0;
        /// <summary>
        /// Obtiene o establece las cantidades de los diferentes sabores de flan disponibles en el stock.
        /// </summary>
        private static Dictionary<Sabor, int> cantidades = new Dictionary<Sabor, int>
        {
            { Sabor.CHOCOLATE, 0 },
            { Sabor.VAINILLA, 0 },
            { Sabor.CARAMELO, 0 }
        };

        /// <summary>
        /// Representa las cantidades de los diferentes sabores de bizcochuelo disponibles en el stock. Proporciona métodos de acceso para obtener y establecer los valores de las cantidades.
        /// </summary>

        public static Dictionary<Sabor, int> Cantidades
        {
            get { return cantidades; }
        }

        /// <summary>
        /// Constructor para la clase Flan.
        /// </summary>
        /// <param name="nombre">Nombre del flan.</param>
        public Flan(string nombre) : base(nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Método para producir un flan de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del flan a producir.</param>
        /// <returns>Devuelve verdadero si el flan se produce con éxito; de lo contrario, falso.</returns>
        public override bool Producir(Sabor sabor)
        {
            int cantidadAlmidon = 0;
            int cantidadAzucar = 0;
            int cantidadGelificante = 10;
            int cantidadSabor = 10;

            switch (sabor)
            {
                case Sabor.CHOCOLATE:
                    cantidadAlmidon = 15;
                    cantidadAzucar = 15;
                    break;
                case Sabor.CARAMELO:
                    cantidadAlmidon = 10;
                    cantidadAzucar = 20;
                    break;
                case Sabor.VAINILLA:
                    cantidadAlmidon = 10;
                    cantidadAzucar = 20;
                    break;
            }

            List<(string, int)> materiasPrimas = new List<(string, int)>
            {
                ("Almidon", cantidadAlmidon),
                ("Gelificante", cantidadGelificante),
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
        /// Método para cocinar un cierto número de flanes de un sabor específico.
        /// </summary>
        /// <param name="sabor">Sabor del flan a cocinar.</param>
        /// <param name="cantidad">Cantidad de flanes a cocinar.</param>
        /// <returns>Devuelve verdadero si se cocinan los flanes con éxito; de lo contrario, falso.</returns>
        public override bool Cocinar(Sabor sabor, int cantidad)
        {
            bool retorno = false;
            if (Cantidades.ContainsKey(sabor))
            {
                if (Cantidades[sabor] >= cantidad)
                {
                    switch (sabor)
                    {
                        case Sabor.CARAMELO:
                            flanesCarameloCocinados += cantidad;
                            break;
                        case Sabor.CHOCOLATE:
                            flanesChocolateCocinados += cantidad;
                            break;
                        case Sabor.VAINILLA:
                            flanesVainillaCocinados += cantidad;
                            break;
                    }

                    Cantidades[sabor] -= cantidad;
                    return true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Método estático para obtener la cantidad de flanes cocinados de cada sabor actualmente.
        /// </summary>
        /// <returns>Detalles del stock de flanes cocinados en forma de dictionary.</returns>

        public static Dictionary<string, int> ObtenerCantidadesCocinadas()
        {
            Dictionary<string, int> todasLasCantidades = new Dictionary<string, int>();
            todasLasCantidades.Add("Flan Caramelo", flanesCarameloCocinados);
            todasLasCantidades.Add("Flan Chocolate", flanesChocolateCocinados);
            todasLasCantidades.Add("Flan Vainilla", flanesVainillaCocinados);
            return todasLasCantidades;
        }
    }
}
