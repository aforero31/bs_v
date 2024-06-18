

namespace BancaSeguros.Entidades.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using System;

    [Serializable]
    public class LogCobis
    {
        private string xmlrequest;
        private string horarequest;
        private string xmlresponse;
        private string horaresponse;
        private string usuario;
        private string tipotransaccion;

        public string XmlRequest
        {
            get { return xmlrequest; }
            set { xmlrequest = value; }
        }

        public string HoraRequest
        {
            get { return horarequest; }
            set { horarequest = value; }
        }

        public string XmlResponse
        {
            get { return xmlresponse; }
            set { xmlresponse = value; }
        }

        public string HoraResponse
        {
            get { return horaresponse; }
            set { horaresponse = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string TipoTransaccion
        {
            get { return tipotransaccion; }
            set { tipotransaccion = value; }
        }
    }
}
