using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que gestiona el stock de ingredientes y sabores para la producción.
    /// </summary>
    public static class Stock
    {
        /// <summary>
        /// Enumeración para los diferentes sabores disponibles durante el programa.
        /// </summary>
        public enum Sabor { VAINILLA, CHOCOLATE, COCO, FRUTILLA, FRAMBUESA, CEREZA, CARAMELO }

        private static int harina = 100;
        private static int azucar = 100;
        private static int gelatina = 100;
        private static int leudantes = 100;
        private static int almidon = 100;
        private static int gelificantes = 100;
        private static Dictionary<Sabor, int> sabores = new Dictionary<Sabor, int>();


        /// <summary>
        /// Obtiene o establece la cantidad actual de harina en el stock.
        /// </summary>
        public static int Harina
        {
            get { return harina; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad actual de azúcar en el stock.
        /// </summary>
        public static int Azucar
        {
            get { return azucar; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad actual de gelatina en el stock.
        /// </summary>
        public static int SGelatina
        {
            get { return gelatina; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad actual de leudantes en el stock.
        /// </summary>
        public static int Leudantes
        {
            get { return leudantes; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad actual de almidón en el stock.
        /// </summary>
        public static int Almidon
        {
            get { return almidon; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad actual de gelificantes en el stock.
        /// </summary>
        public static int Gelificantes
        {
            get { return gelificantes; }
        }

        /// <summary>
        /// Método para establecer la cantidad de cada sabor en el stock.
        /// </summary>
        /// <param name="cantidad">Cantidad predeterminada de cada sabor.</param>
        public static void SetearStockSabor(int cantidad)
        {
            foreach (Sabor sabor in Enum.GetValues(typeof(Sabor)))
            {
                sabores[sabor] = cantidad;
            }
        }

        /// <summary>
        /// Agrega la cantidad especificada de la materia prima especificada al stock.
        /// </summary>
        /// <param name="materiaPrima">El nombre de la materia prima que se va a agregar al stock.</param>
        /// <param name="cantidad">La cantidad de la materia prima que se va a agregar al stock.</param>
        public static void AgregarMateriaPrima(string materiaPrima, int cantidad)
        {

            switch (materiaPrima)
            {
                case "Harina":
                    harina += cantidad;
                    break;
                case "Azucar":
                    azucar += cantidad;
                    break;
                case "Gelatina":
                    gelatina += cantidad;
                    break;
                case "Leudante":
                    leudantes += cantidad;
                    break;
                case "Almidon":
                    almidon += cantidad;
                    break;
                case "Gelificante":
                    gelificantes += cantidad;
                    break;
            }
        }

        public static bool VerificarExistencia(List<(string, int)> materiasPrimas)
        {
            foreach (var materiaPrima in materiasPrimas)
            {
                switch (materiaPrima.Item1)
                {
                    case "Harina":
                        if (harina < materiaPrima.Item2) return false;
                        break;
                    case "Azucar":
                        if (azucar < materiaPrima.Item2) return false;
                        break;
                    case "Gelatina":
                        if (gelatina < materiaPrima.Item2) return false;
                        break;
                    case "Leudante":
                        if (leudantes < materiaPrima.Item2) return false;
                        break;
                    case "Almidon":
                        if (almidon < materiaPrima.Item2) return false;
                        break;
                    case "Gelificante":
                        if (gelificantes < materiaPrima.Item2) return false;
                        break;
                    default:
                        foreach (Sabor sabor in Enum.GetValues(typeof(Sabor)))
                    {
                        if (materiaPrima.Item1 == sabor.ToString())
                        {
                             if (sabores[sabor] < materiaPrima.Item2) return false;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public static bool UsarMateriasPrimas(List<(string, int)> materiasPrimas)
        {
            if (VerificarExistencia(materiasPrimas))
            {
                foreach (var materiaPrima in materiasPrimas)
                {
                    switch (materiaPrima.Item1)
                    {
                        case "Harina":
                            harina -= materiaPrima.Item2;
                            break;
                        case "Azucar":
                            azucar -= materiaPrima.Item2;
                            break;
                        case "Gelatina":
                            gelatina -= materiaPrima.Item2;
                            break;
                        case "Leudante":
                            leudantes -= materiaPrima.Item2;
                            break;
                        case "Almidon":
                            almidon -= materiaPrima.Item2;
                            break;
                        case "Gelificante":
                            gelificantes -= materiaPrima.Item2;
                            break;
                        default:
                            foreach (Sabor sabor in Enum.GetValues(typeof(Sabor)))
                            {
                                if (materiaPrima.Item1.ToString() == sabor.ToString())
                                {
                                    sabores[sabor] -= materiaPrima.Item2;
                                    break;
                                }
                            }
                            break;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para obtener los datos de stock actuales, incluyendo la cantidad de ingredientes y sabores disponibles.
        /// </summary>
        /// <returns>Un diccionario que contiene el nombre de cada ingrediente y sabor junto con su cantidad respectiva en el stock.</returns>
        public static Dictionary<string, int> ObtenerDatosStock()
        {
            Dictionary<string, int> diccionarioStock = new Dictionary<string, int>
        {
            { "Harina", Harina },
            { "Azucar", Azucar },
            { "Gelatina", SGelatina },
            { "Leudantes", Leudantes },
            { "Almidon", Almidon },
            { "Gelificantes", Gelificantes }
        };

            foreach (Sabor sabor in Enum.GetValues(typeof(Sabor)))
            {
                diccionarioStock.Add(sabor.ToString(), sabores[sabor]);
            }

            return diccionarioStock;
        }

        /// <summary>
        /// Método para agregar una cantidad específica a un sabor determinado en el stock.
        /// </summary>
        /// <param name="sabor">Sabor al que se le va a agregar la cantidad.</param>
        /// <param name="cantidad">Cantidad que se va a agregar al sabor especificado.</param>
        public static void AgregarCantidadSabor(Sabor sabor, int cantidad)
        {
            if (sabores.ContainsKey(sabor))
            {
                sabores[sabor] += cantidad;
            }
        }
    }
}
