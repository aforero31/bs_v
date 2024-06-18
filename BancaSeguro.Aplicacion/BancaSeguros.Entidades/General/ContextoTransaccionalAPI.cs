using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Entidades.General
{
    public class ContextoTransaccionalAPI 
    {

        private string identificadorTransaccional;

        private string fecTransaccion;

        private string codCanalOriginador;

        private string codProcesoOriginador;

        private string codFuncionalidadOriginador;

        private string ipConsumidor;

        public string IdentificadorTransaccional
        {
            get { return this.identificadorTransaccional; }
            set { this.identificadorTransaccional = value; }
        }

        public string FecTransaccion
        {
            get { return this.fecTransaccion; }
            set { this.fecTransaccion = value; }
        }

        public string CodCanalOriginador
        {
            get { return this.codCanalOriginador; }
            set { this.codCanalOriginador = value; }
        }

        public string CodProcesoOriginador
        {
            get { return this.codProcesoOriginador; }
            set { this.codProcesoOriginador = value; }
        }

        public string CodFuncionalidadOriginador
        {
            get { return this.codFuncionalidadOriginador; }
            set { this.codFuncionalidadOriginador = value; }
        }

        public string IpConsumidor
        {
            get { return this.ipConsumidor; }
            set { this.ipConsumidor = value; }
        }

    }
}
