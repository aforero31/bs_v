
namespace BancaSeguros.Aplicacion.Configuraciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ListaGeneroPublica
    {
        /// <summary>
        /// Obtener lista generos.
        /// </summary>
        /// <returns>Lista de generos</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static IDictionary<int, string> ObtenerListaGeneros()
        {
            IDictionary<int, string> resultado = new Dictionary<int, string>();
            resultado.Add(int.Parse(ListaGenero.FemeninoValor), ListaGenero.FemeninoDescripcion);
            resultado.Add(int.Parse(ListaGenero.MasculinoValor), ListaGenero.MasculinoDescripcion);
            return resultado;
        }

        /// <summary>
        /// get list code assurance
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, int> ObtenerListaCardifIdentificacion()
        {
            IDictionary<string, int> resultado = new Dictionary<string, int>();
            resultado.Add("CEDULA", 1);
            resultado.Add("EXTRANJERIA", 2);
            resultado.Add("NIT", 3);
            resultado.Add("PASAPORTE", 4);
            return resultado;
        }
    }
}
