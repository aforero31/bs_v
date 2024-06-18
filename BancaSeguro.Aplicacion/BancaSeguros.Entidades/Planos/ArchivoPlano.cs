
namespace BancaSeguros.Entidades.Planos
{
    using System;
    using System.Xml;

    [Serializable]
    public class ArchivoPlano
    {
        private string nombrearchivo;
        private string frecuenciatipoprogramacion;
        private string fechaini;
        private DateTime fechainicio;
        private string fechafinal;
        private DateTime? fechafin;
        private string fechaejec;
        private string fechaejecucion; /*Solo para el xml, no se envia por parametro*/
        private string programacion; /*XML*/
        private string ultimaejecucion;
        private string proximaejecucion;
        private string separador;
        private string rutaftp;
        private string idaseguradora;
        private string codigofiltro;
        private string filtros;
        private string campos;
        private string estado;
        private string objetivo;
        private string diasemanal;
        private string diamensual;
        private string numerosemana;
        private string diasemana;
        private int idprogramacion;
        private string usuario;
        
        


        public string NombreArchivo
        {
            get { return this.nombrearchivo; }
            set { this.nombrearchivo = value; }
        }

        public string FrecuenciaTipoProgramacion
        {
            get { return this.frecuenciatipoprogramacion; }
            set { this.frecuenciatipoprogramacion = value; }
        }
        public DateTime FechaInicio
        {
            get { return this.fechainicio; }
            set { this.fechainicio = value; }
        }

        public DateTime? FechaFin
        {
            get { return this.fechafin; }
            set { this.fechafin = value; }
        }

        public string FechaEjecucion
        {
            get { return this.fechaejecucion; }
            set { this.fechaejecucion = value; }
        }

        public string Programacion
        {
            get { return this.programacion; }
            set { this.programacion = value; }
        }

        public string UltimaEjecucion
        {
            get { return this.ultimaejecucion; }
            set { this.ultimaejecucion = value; }
        }

        public string ProximaEjecucion
        {
            get { return this.proximaejecucion; }
            set { this.proximaejecucion = value; }
        }

        public string Separador
        {
            get { return this.separador; }
            set { this.separador = value; }
        }

        public string RutaFTP
        {
            get { return this.rutaftp; }
            set { this.rutaftp = value; }
        }

        public string IdAseguradora
        {
            get { return this.idaseguradora; }
            set { this.idaseguradora = value; }
        }

        public string CodigoFiltro
        {
            get { return this.codigofiltro; }
            set { this.codigofiltro = value; }
        }

        public string Filtros
        {
            get { return this.filtros; }
            set { this.filtros = value; }
        }
        public string Campos
        {
            get { return this.campos; }
            set { this.campos = value; }
        }

        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /*Descripcion*/

        public string Objetivo
        {
            get { return this.objetivo; }
            set { this.objetivo = value; } 
        }

        public string DiaSemanal
        {
            get { return this.diasemanal; }
            set { this.diasemanal = value; }
        }

        public string DiaMes
        {
            get { return this.diamensual; }
            set { this.diamensual = value; }
        }

        public string NumeroSemana
        {
            get { return this.numerosemana; }
            set { this.numerosemana = value; }
        }

        public string DiaSemana
        {
            get { return this.diasemana; }
            set { this.diasemana = value; }
        }

        public int IdProgramacion
        {
            get { return this.idprogramacion; }
            set { this.idprogramacion = value; }
        }

        public string FechaIni
        {
            get { return this.fechaini; }
            set { this.fechaini = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string FechaFinal
        {
            get { return this.fechafinal; }
            set { this.fechafinal = value; }
        }

        public string FechaEjec
        {
            get { return this.fechaejec; }
            set { this.fechaejec = value; }
        }
    }
}
