namespace BancaSeguros.Entidades.Venta
{
    using BancaSeguros.Entidades.General;
    using System;

    [Serializable]
    public class ResultadoVentaPoliza
    {
        private Resultado resultado;
        private string consecutivo;

        public string Consecutivo
        {
            get { return consecutivo; }
            set { consecutivo = value; }
        }

        public Resultado Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
    }
}
