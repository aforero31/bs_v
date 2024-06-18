//-----------------------------------------------------------------------
// <copyright file="RepositorioSincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Sincronizacion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Entidades.Catalogo;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioSincronizacion : IRepositorioSincronizacion
    {

        #region Variables

        /// <summary>
        /// Connection database
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
        /// Initializes a new instance of the <see cref="RepositorioLog"/> class.
        /// </summary>
        /// <param name="nombreConexion">Name connection</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioSincronizacion(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        public Resultado GuardarDatosEnBaseDatos(string nombreCatalogo, DataTable datos)
        {
            Resultado resultado = new Resultado();

            try
            {
                SqlDatabase db = (SqlDatabase)EnterpriseLibraryContainer.Current.GetInstance<Database>("CONEXION_BANCASEGURO");

                switch (nombreCatalogo)
                {
                    case EnumCatalogo.CobisTipoIdentificacion:
                        resultado.Mensaje = this.GuardarDatos(db, Procedimientos.PR_SEG_SincronizarTiposIdentificacion, datos);
                        break;

                    case EnumCatalogo.CobisPeriodicidad:
                        resultado.Mensaje = this.GuardarDatos(db, Procedimientos.PR_SEG_SincronizarPeriodicidad, datos);
                        break;

                    case EnumCatalogo.CobisParentesco:
                        resultado.Mensaje = this.GuardarDatos(db, Procedimientos.PR_SEG_SincronizarParentesco, datos);
                        break;

                    case EnumCatalogo.CobisProducto:
                        resultado.Mensaje = this.GuardarDatos(db, Procedimientos.PR_SEG_SincronizarProductos, datos);
                        break;

                    case EnumCatalogo.CobisSubProductoCA:
                    case EnumCatalogo.CobisSubProductoCC:
                        resultado.Mensaje = this.GuardarDatos(db, Procedimientos.PR_SEG_SincronizarSubProductos, datos);
                        break;

                    case EnumCatalogo.CobisCategoriaCA:
                    case EnumCatalogo.CobisCategoriaCC:
                        resultado.Mensaje = this.GuardarDatos(db, Procedimientos.PR_SEG_SincronizarCategorias, datos);
                        break;
                }
            }
            catch (Exception exc)
            {
                resultado.Error = true;
                resultado.IdTipoMensaje = int.Parse(ParametrosGenerales.IdMensajeError);
                resultado.Mensaje = string.Format(Mensajes.ErrorInterno, exc.Message);
            }

            return resultado;
        }

        private string GuardarDatos(SqlDatabase db, string nombreProcedimiento, DataTable datos)
        {
            Resultado resultado = new Resultado();

            using (var cmd = db.GetStoredProcCommand(nombreProcedimiento))
            {
                cmd.CommandTimeout = 0;
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.Datos, SqlDbType.Structured, datos);

                using (var reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        resultado.Mensaje = reader.IsDBNull(reader.GetOrdinal(Campos.Accion)) ? string.Empty : (string)reader[Campos.Accion];
                    }
                }
            }

            return resultado.Mensaje;
        }

        #endregion
    }
}
