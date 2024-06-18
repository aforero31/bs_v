

namespace BancaSeguros.Aplicacion.Administracion
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
    /// Interface Parametrizacion Planos Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 12/07/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionParametrizacionPlanos
    {
        /// <summary>
        /// Obtain the Aseguradoras.
        /// </summary>
        /// <param name="ipc">The Aseguradora</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposCobros> ConsultarCobros(int opcion);

        /// <summary>
        /// Obtain the name of columns.
        /// </summary>
        /// <param name="ipc">The Columns</param>
        /// <returns>list string Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposPoliza> ConsultarPolizas(int opcion);


        /// <summary>
        /// Obtain the name of columns.
        /// </summary>
        /// <param name="ipc">The Columns</param>
        /// <returns>list string Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposCancelaciones> ConsultarCancelaciones(int opcion);

        /// <summary>
        /// Obtain the filters of Cancelation.
        /// </summary>
        /// <param name="ipc">The filters</param>
        /// <returns>list string Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<CamposCancelaciones> ConsultarFiltrosCancelaciones();


        /// <summary>
        /// Inserts data for Generate the File.
        /// </summary>
        /// <param name="mensaje">Inserts data for Generate the File</param>
        /// <returns>Resultado</returns>
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
        /// Update data for Generate the File.
        /// </summary>
        /// <param name="mensaje">Inserts data for Generate the File</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo);

        /// <summary>
        /// Update data for Generate the File.
        /// </summary>
        /// <param name="mensaje">Inserts data for Generate the File</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado EliminarDatosArchivoPlano(int idProgramacion, string usuario);
    }
}
