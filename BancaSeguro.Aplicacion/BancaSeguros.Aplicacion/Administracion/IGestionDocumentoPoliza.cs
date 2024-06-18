
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.Seguro;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGestionDocumentoPoliza
    {
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
    }
}
