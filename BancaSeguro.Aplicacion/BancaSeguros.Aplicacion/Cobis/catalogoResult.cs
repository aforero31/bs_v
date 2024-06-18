using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.Cobis
{
    [Serializable]
    public class catalogoResult
    {
        public string codEstado { get; set; }
        public string codTabla { get; set; }
        public string codCatalogo { get; set; }
        public string valCatalogo { get; set; }
        public oficinaResult oficina { get; set; }
    }
}
