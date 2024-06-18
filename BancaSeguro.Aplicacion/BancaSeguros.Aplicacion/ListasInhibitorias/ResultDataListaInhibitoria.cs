using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.ListasInhibitorias
{
    [Serializable]
    public class ResultDataListaInhibitoria
    {
        public long score { set; get; }
        public string existeInhibitorias { set; get; }
        public string mensajeAlerta { set; get; }

    }
}
