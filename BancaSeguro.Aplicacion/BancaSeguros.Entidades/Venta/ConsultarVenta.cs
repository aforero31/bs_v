namespace BancaSeguros.Entidades.Venta
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using System;

    [Serializable]
    public class ConsultarVenta
    {
        private RegistrarVenta datosVenta;
        private BancaSeguros.Entidades.Seguro.Seguro seguro;
        private DetalleCancelacionPoliza detalleCancelacionPoliza;
        private DateTime fechaCreacion;
        private DateTime fechaCobroExitoso;
        private Resultado resultado;
        public DateTime FechaCobroExitoso
        {
            get { return fechaCobroExitoso; }
            set { fechaCobroExitoso = value; }
        }

        public DetalleCancelacionPoliza DetalleCancelacionPoliza
        {
            get { return detalleCancelacionPoliza; }
            set { detalleCancelacionPoliza = value; }
        } 
        
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        //private ManejoExcepcion manejoExcepcion;

        public RegistrarVenta DatosVenta
        {
            get { return datosVenta; }
            set { datosVenta = value; }
        }

        public BancaSeguros.Entidades.Seguro.Seguro Seguro
        {
            get { return seguro; }
            set { seguro = value; }
        }

        //public ManejoExcepcion ManejoExcepcion
        //{
        //    get { return manejoExcepcion; }
        //    set { manejoExcepcion = value; }
        //}

        public Resultado Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
    }
}
