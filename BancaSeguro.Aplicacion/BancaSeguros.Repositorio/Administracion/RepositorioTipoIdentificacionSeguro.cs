//-----------------------------------------------------------------------
// <copyright file="RepositorioDocumentoSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioTipoIdentificacionSeguro : IRepositorioTipoIdentificacionSeguro
    {
        #region Variables
        private Database dataBase;
        #endregion

        #region Constructores
        public RepositorioTipoIdentificacionSeguro(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }
        #endregion

        #region Metodos Publico
        /// <summary>
        /// Saves the DocumentTipo by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoDocumento">The identifier tipo documento.</param>
        /// <returns>resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion, string login)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_InsertarSeguroTipoIdentificacion))
                {
                    this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.String, idSeguro);
                    this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoIdentificacion, DbType.Int32, idTipoIdentificacion);
                    this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, login);
                    this.dataBase.ExecuteNonQuery(comandoBaseDatos);
                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.GuardarTipoIdentificacionSeguroExitoso;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Deletes the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoIdentificacion">The identifier tipo identificacion.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_EliminarSeguroTipoIdentificacion))
                {
                    this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.String, idSeguro);
                    this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoIdentificacion, DbType.Int32, idTipoIdentificacion);
                    this.dataBase.ExecuteNonQuery(comandoBaseDatos);
                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.GuardarTipoIdentificacionSeguroExitoso;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Get the type identification of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity List Plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<TipoIdentificacion> ConsultarTiposIdentificacionPorIdSeguro(int idSeguro)
        {
            IList<TipoIdentificacion> tiposIdentificacion = new List<TipoIdentificacion>();
            Mapeador mapeador = new Mapeador();

            DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarTiposIdentificacionPorIdSeguro);

            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);

            using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
            {
                while (reader.Read())
                {
                    TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                    tipoIdentificacion = mapeador.DataReaderATipoIdentificacion(reader);
                    tiposIdentificacion.Add(tipoIdentificacion);
                }
            }
            return tiposIdentificacion;
        }

        /// <summary>
        /// Update the sure type identifier por identifier.
        /// </summary>
        /// <param name="tiposIdentificacion">The type identifier.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarSeguroTipoIdentiPorId(DataTable tiposIdentificacion, string login)
        {
            Resultado resultado = new Resultado();

            SqlDatabase db = (SqlDatabase)EnterpriseLibraryContainer.Current.GetInstance<Database>("CONEXION_BANCASEGURO");

            using (var cmd = db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarSeguroTipoIdentiPorId))
            {
                cmd.CommandTimeout = 0;
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.TablaSeguroTipoI, SqlDbType.Structured, tiposIdentificacion);
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.Login, SqlDbType.VarChar, login);

                using (var reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        resultado.Mensaje = reader.IsDBNull(reader.GetOrdinal(Campos.Accion)) ? string.Empty : (string)reader[Campos.Accion];
                    }
                }
            }

            return resultado;
        }

        #endregion
    }
}
