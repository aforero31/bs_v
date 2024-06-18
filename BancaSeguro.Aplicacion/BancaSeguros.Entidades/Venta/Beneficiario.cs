namespace BancaSeguros.Entidades.Venta
{
    using System;

    [Serializable]
    public class Beneficiario
    {
        private int idBeneficiario;
        private int idVenta;
        private int idParentesco;
        private int idTipoIdentificacion;
        private string identificacion;
        private string nombres;
        private string apellidos;
        private int porcentaje;

        public int IdBeneficiario
        {
            get { return idBeneficiario; }
            set { idBeneficiario = value; }
        }

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public int IdParentesco
        {
            get { return idParentesco; }
            set { idParentesco = value; }
        }

        public int IdTipoIdentificacion
        {
            get { return idTipoIdentificacion; }
            set { idTipoIdentificacion = value; }
        }

        public string Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public int Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }
    }
}