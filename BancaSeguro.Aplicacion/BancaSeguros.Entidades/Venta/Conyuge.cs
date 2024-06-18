namespace BancaSeguros.Entidades.Venta
{
    using System;

    [Serializable]
    public class Conyuge
    {
        private int idConyuge;
        private int idVenta;
        private int idTipoIdentificacion;
        private string identificacion;
        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private DateTime fechaNacimiento;
        private DateTime fechaEmisionDocumento;
        private string idgenero;
        private string genero;

        public int IdConyuge
        {
            get { return idConyuge; }
            set { idConyuge = value; }
        }

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
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

        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }

        public string SegundoNombre
        {
            get { return segundoNombre; }
            set { segundoNombre = value; }
        }

        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }

        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public DateTime FechaEmisionDocumento
        {
            get { return fechaEmisionDocumento; }
            set { fechaEmisionDocumento = value; }
        }

        public string IdGenero
        {
            get { return idgenero; }
            set { idgenero = value; }
        }

        /// <summary>
        /// Genero.
        /// </summary>
        /// <value>
        /// Genero.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
    }
}