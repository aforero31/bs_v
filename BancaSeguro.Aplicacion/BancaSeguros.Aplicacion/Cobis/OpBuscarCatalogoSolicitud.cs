using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancaSeguros.Aplicacion.Cobis
{
    [Serializable]
    public class OpBuscarCatalogoSolicitud
    {
        public contextoTransaccional contextoTransaccional { get; set; }
        public paginacion paginacion { get; set; }
        public catalogo catalogo { get; set; }

    }

    [Serializable]
    public class RequestCatalogo
    {
        public OpBuscarCatalogoSolicitud opBuscarCatalogoSolicitud { get; set; }
    }

}
