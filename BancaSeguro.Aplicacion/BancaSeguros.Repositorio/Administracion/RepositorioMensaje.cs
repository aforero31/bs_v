//-----------------------------------------------------------------------
// <copyright file="RepositorioMensaje.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Message repository class
    /// </summary>
    public class RepositorioMensaje : IRepositorioMensaje
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioMensaje"/> class.
        /// </summary>
        /// <param name="nombreConexion">The connection name.</param>
        public RepositorioMensaje(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Search the messages.
        /// </summary>
        /// <param name="mensaje">The message to search.</param>
        /// <returns>List of messages</returns>
        public IList<Mensaje> ConsultarMensajes()
        {
            List<Mensaje> resultados = new List<Mensaje>();
            Mensaje resultadoMensaje = null;
            Repositorio.Administracion.Mapeador mapeador = new Repositorio.Administracion.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarMensaje))
            {
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoMensaje = mapeador.DataReaderMensaje(reader));
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Inserts the message.
        /// </summary>
        /// <param name="mensaje">The message.</param>
        /// <returns>result of operation</returns>
        public Resultado InsertarMensaje(Mensaje mensaje)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarMensaje))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Llave, DbType.String, mensaje.Llave);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoMensaje, DbType.Int32, mensaje.IdTipoMensaje);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idEvento, DbType.Int32, mensaje.IdEvento);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Mensaje, DbType.String, mensaje.DescripcionMensaje);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, mensaje.Login);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                    resultado.Mensaje = Mensajes.LlaveMensajeExistente;
                }
                else
                {
                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.MensajeGuardado;
                }

            }

            return resultado;
        }

        /// <summary>
        /// Update the message.
        /// </summary>
        /// <param name="mensaje">The message.</param>
        /// <returns>Result of operation</returns>
        public Resultado ActualizarMensaje(Mensaje mensaje)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarMensaje))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMensaje, DbType.Int32, mensaje.IdMensaje);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Llave, DbType.String, mensaje.Llave);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoMensaje, DbType.Int32, mensaje.IdTipoMensaje);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idEvento, DbType.Int32, mensaje.IdEvento);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Mensaje, DbType.String, mensaje.DescripcionMensaje);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, mensaje.Login);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                    resultado.Mensaje = Mensajes.LlaveMensajeExistente;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Search the message by identifier.
        /// </summary>
        /// <param name="idMensaje">The identifier of message.</param>
        /// <returns>Message object</returns>
        public Mensaje ConsultarMensajePorId(int? idEvento, string Llave)
        {
            Mensaje resultadoMensaje = null;
            Repositorio.Administracion.Mapeador mapeador = new Repositorio.Administracion.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarMensajePorId))
            {
                this.db.AddInParameter(comandoBaseDatos, "idEvento", DbType.Int32, (int?)idEvento);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Llave, DbType.String, Llave);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultadoMensaje = mapeador.DataReaderMensaje(reader);
                    }
                }
            }

            return resultadoMensaje;
        }

        #endregion
    }
}
