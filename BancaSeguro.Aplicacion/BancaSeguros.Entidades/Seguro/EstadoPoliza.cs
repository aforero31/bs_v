namespace BancaSeguros.Entidades.Seguro
{
    using System;

    [Serializable]
    public class EstadoPoliza
    {
        private int codigoEstadoPoliza;
        private string descripcionEstadoPoliza;

        public string DescripcionEstadoPoliza
        {
            get { return descripcionEstadoPoliza; }
            set { descripcionEstadoPoliza = value; }
        }

        public int CodigoEstadoPoliza
        {
            get { return codigoEstadoPoliza; }
            set { codigoEstadoPoliza = value; }
        }
    }
}
