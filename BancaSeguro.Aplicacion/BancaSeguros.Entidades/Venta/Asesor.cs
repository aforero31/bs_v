namespace BancaSeguros.Entidades.Venta
{
    using BAC.EntidadesSeguridad;
    using System;

    [Serializable]
    public class Asesor
    {
        private string idAsesor;
        private int idTipoIdentificacion;
        private int identificacion;
        private string nombre;
        private Oficina oficina;

        public Oficina Oficina
        {
            get { return oficina; }
            set { oficina = value; }
        }

        public string IdAsesor
        {
            get { return idAsesor; }
            set { idAsesor = value; }
        }

        public int IdTipoIdentificacion
        {
            get { return idTipoIdentificacion; }
            set { idTipoIdentificacion = value; }
        }

        public int Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
