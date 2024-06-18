namespace BancaSeguros.Repositorio.Venta
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    public interface IRepositorioLogCobis
    {
        /// <summary>
        /// Guardar datos en la tabla de LogCobis
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarDatosLogEnTablaLogCobis(LogCobis logCobis);

        /// <summary>
        /// Gets the consecutive to cobis.
        /// </summary>
        /// <returns>Value of consecutive</returns>
        Int64 ObtenerConsecutivoCobis();
    }
}
