using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancaSeguros.Aplicacion.Cobis
{
    [Serializable]
    public class contextoTransaccional
    {
        public string identificadorTransaccional { get; set; }
        public string fecTransaccion { get; set; }
        public string codCanalOriginador { get; set; }
        public string codProcesoOriginador { get; set; }
        public string codFuncionalidadOriginador { get; set; }
        public string ipConsumidor { get; set; }

    }
}
