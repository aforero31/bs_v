

namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Planos;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class Planos Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    ///  CreationDate: 12/07/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioCausalNovedad" />
    public class RepositorioParametrizacionPlanos : IRepositorioParametrizacionPlanos
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioParametrizacionPlanos"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioParametrizacionPlanos(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Métodos Públicos
        public List<Aseguradora> ConsultarAseguradoras()
        {
            List<Aseguradora> listAseguradora = new List<Aseguradora>();
            Mapeador mapeador = new Mapeador();
            Aseguradora aseguradora = new Aseguradora();
            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarAseguradorasActivas))
            {
                using (IDataReader reader = this.dataBase.ExecuteReader(comandoBase))
                {
                    while (reader.Read())
                    {
                        listAseguradora.Add(aseguradora = mapeador.DataReaderAseguradora(reader));
                    }
                }
            }
            return listAseguradora;
        }

        public List<CamposPoliza> ConsultarPolizas(int opcion)
        {
            List<CamposPoliza> listCamposPoliza = new List<CamposPoliza>() ;
            Mapeador mapeador = new Mapeador();
            CamposPoliza campo = new CamposPoliza();

            using (DbCommand comando = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarColumnasFiltro))
            {
                this.dataBase.AddInParameter(comando, ParametrosEntradaProcedimientos.opcion, DbType.Int32, opcion);
                using (IDataReader reader = this.dataBase.ExecuteReader(comando))
                {
                    while (reader.Read())
                    {
                        listCamposPoliza.Add(campo = mapeador.DataReaderCamposPoliza(reader));
                    }
                }
            }
            return listCamposPoliza;
        }

        public List<CamposCobros> ConsultarCobros(int opcion)
        {
            List<CamposCobros> listCamposCobros = new List<CamposCobros>();
            Mapeador mapeador = new Mapeador();
            CamposCobros campos = new CamposCobros();

            using (DbCommand comando = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarColumnasFiltro))
            {
                this.dataBase.AddInParameter(comando, ParametrosEntradaProcedimientos.opcion, DbType.Int32, opcion);
                using (IDataReader reader = this.dataBase.ExecuteReader(comando))
                {
                    while (reader.Read())
                    {
                        listCamposCobros.Add(campos = mapeador.DatareaderCamposCobros(reader));
                    }
                }
            }
            return listCamposCobros;      
        }

        public List<CamposCancelaciones> ConsultarCancelaciones(int opcion)
        {
            List<CamposCancelaciones> listCamposCancelaciones = new List<CamposCancelaciones>();
            Mapeador mapeador = new Mapeador();
            CamposCancelaciones campos = new CamposCancelaciones();

            using (DbCommand comando = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarColumnasFiltro))
            {
                this.dataBase.AddInParameter(comando, ParametrosEntradaProcedimientos.opcion, DbType.Int32, opcion);
                using (IDataReader reader = this.dataBase.ExecuteReader(comando))
                {
                    while (reader.Read())
                    {
                        listCamposCancelaciones.Add(campos = mapeador.DatareaderCamposCancelaciones(reader));
                    }
                }
            }
            return listCamposCancelaciones;
        }

        public List<CamposCancelaciones> ConsultarFiltrosCancelaciones()
        {
            List<CamposCancelaciones> listFiltrosCancelaciones = new List<CamposCancelaciones>();
            Mapeador mapeador = new Mapeador();
            CamposCancelaciones campos = new CamposCancelaciones();

            using (DbCommand comando = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarFiltrosCancelaciones))
            {
                using (IDataReader reader = this.dataBase.ExecuteReader(comando))
                {
                    while (reader.Read())
                    {
                        listFiltrosCancelaciones.Add(campos = mapeador.DatareaderFiltrosCancelaciones(reader));
                    }
                }
            }
            return listFiltrosCancelaciones;
        }

        public Resultado GuardarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBase = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarDatosArchivoPlano))
            {
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreArchivoPlano, DbType.String, datosArchivo.NombreArchivo);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.ObjetivoArchivoPlano, DbType.String, datosArchivo.Objetivo);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.FrecuenciaArchivoPlano, DbType.Int32, Convert.ToInt32(datosArchivo.FrecuenciaTipoProgramacion));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.FechaInicioArchivoPlano, DbType.DateTime, Convert.ToDateTime(datosArchivo.FechaInicio));
                if (datosArchivo.FechaFin == null)
                    dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.FechaFinArchivoPlano, DbType.DateTime, SqlDateTime.MinValue);
                else
                    dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.FechaFinArchivoPlano, DbType.DateTime, Convert.ToDateTime(datosArchivo.FechaFin));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.ProgramacionArchivoPlano, DbType.String, datosArchivo.Programacion);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.RutaFTPArchivoPlano, DbType.String, datosArchivo.RutaFTP);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.SeparadorArchivoPlano, DbType.String, datosArchivo.Separador);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.idAseguradora, DbType.Int32, Convert.ToInt32(datosArchivo.IdAseguradora));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoFiltroArchivoPlano, DbType.Int32, Convert.ToInt32(datosArchivo.CodigoFiltro));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CriterioFiltroArchivoPlano, DbType.String, datosArchivo.Filtros);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CamposArchivoPlano, DbType.String, datosArchivo.Campos);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.estado, DbType.Boolean, Convert.ToBoolean(datosArchivo.Estado));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.Login, DbType.String, datosArchivo.Usuario);
                if (dataBase.ExecuteNonQuery(comandoBase) == -1)
                    resultado.Error = true;
                else
                    resultado.Error = false;
            }
            return resultado;
        }


        public List<ArchivoPlano> ConsultarDatosGrilla()
        {
            List<ArchivoPlano> listDatosArchivos = new List<ArchivoPlano>();
            Mapeador mapeador = new Mapeador();
            ArchivoPlano fila = new ArchivoPlano();
            using (DbCommand comando = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarDatosArchivosPlanos))
            {
                using (IDataReader reader = this.dataBase.ExecuteReader(comando))
                {
                    while (reader.Read())
                    {
                        listDatosArchivos.Add(fila = mapeador.DataReaderFilaArchivosPlanos(reader));
                    }
                }
            }

            return listDatosArchivos;
        }


        public Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            Resultado resultado = new Resultado();
            using (DbCommand comandoBase = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarArchivoPlano))
            {
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.IdProgramacion, DbType.Int32, datosArchivo.IdProgramacion);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreArchivoPlano, DbType.String, datosArchivo.NombreArchivo);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.ObjetivoArchivoPlano, DbType.String, datosArchivo.Objetivo);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.FrecuenciaArchivoPlano, DbType.Int32, Convert.ToInt32(datosArchivo.FrecuenciaTipoProgramacion));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.RutaFTPArchivoPlano, DbType.String, datosArchivo.RutaFTP);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.SeparadorArchivoPlano, DbType.String, datosArchivo.Separador);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.idAseguradora, DbType.Int32, Convert.ToInt32(datosArchivo.IdAseguradora));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoFiltroArchivoPlano, DbType.Int32, Convert.ToInt32(datosArchivo.CodigoFiltro));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CriterioFiltroArchivoPlano, DbType.String, datosArchivo.Filtros);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CamposArchivoPlano, DbType.String, datosArchivo.Campos);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.estado, DbType.Boolean, Convert.ToBoolean(datosArchivo.Estado));
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.Login, DbType.String, datosArchivo.Usuario);
                if (dataBase.ExecuteNonQuery(comandoBase) == 1)
                    resultado.Error = true;
                else
                    resultado.Error = false;
 
            }

            return resultado;
        }


        public Resultado EliminarDatosArchivoPlano(int idProgramacion, string usuario)
        {
            Resultado resultado = new Resultado();
            using (DbCommand comando = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_EliminarDatosArchivoPlano))
            {
                dataBase.AddInParameter(comando, ParametrosEntradaProcedimientos.IdProgramacion, DbType.Int32, idProgramacion);
                dataBase.AddInParameter(comando, ParametrosEntradaProcedimientos.Login, DbType.String, usuario);
                if (dataBase.ExecuteNonQuery(comando) == 1)
                    resultado.Error = true;
                else
                    resultado.Error = false;
 
            }
            return resultado;
        }
      
 
        #endregion
    }
}
