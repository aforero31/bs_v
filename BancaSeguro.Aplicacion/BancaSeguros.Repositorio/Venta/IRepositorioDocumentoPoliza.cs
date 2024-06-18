
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositorioDocumentoPoliza
    {
        /// <summary>
        /// Obteners the documento poliza por identifier seguro.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        DocumentoPoliza ObtenerDocumentoPolizaPorIdSeguro(int idSeguro);

        /// <summary>
        /// Obtiene la informacion del documento de la poliza.
        /// </summary>
        /// <param name="idPoliza">IdPoliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        EncabezadoPolizaDocumento ObtenerInformacionEncabezadoDocumentoPoliza(string consecutivoPoliza);

        /// <summary>
        /// Obtiene la informacion beneficiarios documento poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">Consecutivo de la poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<BeneficiariosPolizaDocumento> ObtenerInformacionBeneficiariosDocumentoPoliza(string consecutivoPoliza);

        /// <summary>
        /// Obtiene la informacion conyuge documento poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">Consecutivo de la poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        ConyugePolizaDocumento ObtenerInformacionConyugeDocumentoPoliza(string consecutivoPoliza);

        /// <summary>
        /// Insertar el documento plantilla seguro.
        /// </summary>
        /// <param name="documentoPoliza">Documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 24/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza);

        /// <summary>
        /// Insertar los datos con que genero la poliza
        /// </summary>
        /// <param name="plantillaXml">Datos XML de la venta</param>
        /// <param name="IdDocumentoPoliza">Id de la plantilla utilizada</param>
        /// <param name="consecutivoPoliza">Consecutivo de la Poliza</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 24/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarPolizaVendidaImpresion(System.Xml.Linq.XElement plantillaXml, int IdDocumentoPoliza, string consecutivoPoliza);

        /// <summary>
        /// Obtiene la informacion del documento de la poliza para reimpresion.
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivoPoliza</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        DocumentoPoliza ConsultarInformacionReimpresion(string consecutivoPoliza);

        /// <summary>
        /// Obteners the plantillas por identifier seguro.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro);

        /// <summary>
        /// Elimina una plantilla.
        /// </summary>
        /// <param name="idDocumentoPlantilla">idDocumentoPlantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado EliminarPlantilla(int idDocumentoPlantilla);

        /// <summary>
        /// Activars the estado plantilla.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActivarEstadoPlantilla(int idDocumentoPoliza);

        /// <summary>
        /// Obteners the documento poliza por identifier documento poliza.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 29/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        DocumentoPoliza ObtenerDocumentoPolizaPorIdDocumentoPoliza(int idDocumentoPoliza);


        /// <summary>
        /// Obtiene la informacion de los campos dinamicos de la poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">Id de la venta.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<VariableVenta> ObtenerInformacionVariableVentaDocumentoPoliza(VariableVenta variable);

        /// <summary>
        /// gets the list template active.
        /// </summary>
        /// <returns>list entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 08/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<DocumentoPoliza> ConsultarPlantillasActivas();

        /// <summary>
        /// Insert the template sure.
        /// </summary>
        /// <param name="documentoPoliza">The document policy.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 11/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado InsertarPlantillaSeguroDuplicada(DocumentoPoliza documentoPoliza);

        /// <summary>
        /// update the template.
        /// </summary>
        /// <param name="documentoPoliza">The document policy.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarPlantilla(DocumentoPoliza documentoPoliza);

        /// <summary>
        /// not active template of identifier sure
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado DesActivarPlantillasPorIdSeguro(int idSeguro);

        /// <summary>
        /// Obtiene el id seguro por el consecutivo poliza
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivoPoliza</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CALVAREZP
        /// CreationDate: 29/09/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        int ConsultarSeguroPorConsecutivoPoliza(string consecutivoPoliza);

    }
}
