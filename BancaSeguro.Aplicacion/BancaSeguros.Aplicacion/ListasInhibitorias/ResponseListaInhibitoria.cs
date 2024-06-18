using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.ListasInhibitorias
{
    [Serializable]
    class ResponseListaInhibitoria
    {
        public string responseCode { set; get; }
        public string responseMessage { set; get; }
        public long rowsAffected { set; get; }
        public ResultDataListaInhibitoria resultData { set; get; }

    }
}
