

namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Planos;
    using BancaSeguros.Entidades.Seguro;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Interface Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    ///  CreationDate: 12/07/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioParametrizacionPlanos
    {
        /// <summary>
        /// Search Aseguradora.
        /// </summary>
        /// <param name="novedad">The aseguradora.</param>
        /// <returns>List of Aseguradora</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposCobros> ConsultarCobros(int opcion);

        /// <summary>
        /// Search Name of Columns Poliza.
        /// </summary>
        /// <param name="novedad">The Name of Columns Poliza.</param>
        /// <returns>List of Name of Columns Poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposPoliza> ConsultarPolizas(int opcion);

        /// <summary>
        /// Search Name of Columns Cancel.
        /// </summary>
        /// <param name="novedad">The Name of Columns Cancel.</param>
        /// <returns>List of Name of Columns Poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposCancelaciones> ConsultarCancelaciones(int opcion);


        /// <summary>
        /// Search Filters of option Cancelation.
        /// </summary>
        /// <param name="novedad">The Filters of option Cancelation.</param>
        /// <returns>List of Filters of option Cancelation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposCancelaciones> ConsultarFiltrosCancelaciones();


        /// <summary>
        /// Insert the data for generate the File
        /// </summary>
        /// <param name="novedad">The data generate the file</param>
        /// <returns>True or False</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarDatosArchivoPlano(ArchivoPlano datosArchivo);

        /// <summary>
        /// Search the data for fill the Grid
        /// </summary>
        /// <param name="novedad">the data for fill the Grid</param>
        /// <returns>data</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 18/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<ArchivoPlano> ConsultarDatosGrilla();

        /// <summary>
        /// Update the data for generate the File
        /// </summary>
        /// <param name="novedad">The data generate the file</param>
        /// <returns>True or False</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo);

        /// <summary>
        /// Delete the data for generate the File
        /// </summary>
        /// <param name="novedad">The data generate the file</param>
        /// <returns>True or False</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado EliminarDatosArchivoPlano(int idProgramacion, string usuario);

    }
}
