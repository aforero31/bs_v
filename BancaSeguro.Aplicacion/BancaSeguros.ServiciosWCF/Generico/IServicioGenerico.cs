using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BancaSeguros.ServiciosWCF.Generico
{
    [ServiceContract]
    public interface IServicioGenerico
    {
        #region Catalogo

        [OperationContract]
        DtoCatalogo ConsultarCatalogo(string NombreTabla);

        #endregion

        #region Log

        [OperationContract]
        Resultado GuardarError(int evento, string excepcion, string llave);

        #endregion

        #region Mensajes

        [OperationContract]
        Resultado ConsultarMensajePorLlave(int evento, string llave);

        #endregion
    }
}
