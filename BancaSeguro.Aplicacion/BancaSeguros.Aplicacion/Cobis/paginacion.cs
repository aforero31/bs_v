using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancaSeguros.Aplicacion.Cobis
{
    [Serializable]
    public class paginacion
    {
        public string valUltimoRegistroTexto { get; set; }
        public string valTamPagina { get; set; }
        public string valOrdenacion { get; set; }
    }
}
