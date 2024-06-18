using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancaSeguros.Aplicacion.Cobis
{
    [Serializable]
    public class catalogo
    {
        public string codEstado { get; set; }
        public string codClase { get; set; }
        public string codTabla { get; set; }
    }
}
