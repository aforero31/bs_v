using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.General;

namespace BancaSeguros.Aplicacion.ListasInhibitorias
{
    [Serializable]
    class RequestListaInhibitoria
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public ContextoTransaccionalAPI ContextoTransaccional { get; set; }
        public string Token { get; set; }

    }
}
