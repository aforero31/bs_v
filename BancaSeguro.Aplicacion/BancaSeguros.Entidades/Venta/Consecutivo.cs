namespace BancaSeguros.Entidades.Venta
{
    using System;

    [Serializable]
    public class Consecutivo
    {
        private int idConsecutivo;
        private int idAseguradora;
        private int consecutivoActual;
        private int consecutivoMaximo;
        private int? siguienteConsecutivo;

        public int IdConsecutivo
        {
            get { return idConsecutivo; }
            set { idConsecutivo = value; }
        }

        public int IdAseguradora
        {
            get { return idAseguradora; }
            set { idAseguradora = value; }
        }

        public int ConsecutivoActual
        {
            get { return consecutivoActual; }
            set { consecutivoActual = value; }
        }

        public int ConsecutivoMaximo
        {
            get { return consecutivoMaximo; }
            set { consecutivoMaximo = value; }
        }

        public int? SiguienteConsecutivo
        {
            get { return siguienteConsecutivo; }
            set { siguienteConsecutivo = value; }
        }
    }
}
