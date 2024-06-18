//-----------------------------------------------------------------------
// <copyright file="RepositorioPermiso.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Seguridad
{
    using System;
    using System.Data;
    using System.Data.Common;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    
    /// <summary>
    /// Permission Repository Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Seguridad.IRepositorioPermiso" />
    public class RepositorioPermiso : IRepositorioPermiso
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
        /// Initializes a new instance of the <see cref="RepositorioPermiso"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioPermiso(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        /// <summary>
        /// Inserts permission.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 25/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado InsertarPermiso(Permisos permiso)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            try
            {
                using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_InsertarPermiso))
                {
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMenu, DbType.Int32, permiso.IdMenu);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, permiso.IdRol);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Byte, permiso.Activo.HasValue ? permiso.Activo.Value : false);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.Int32, permiso.login);
                    this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                    this.db.ExecuteNonQuery(comandoBaseDatos);

                    int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                    if (existe == 1)
                    {
                        resultado.Error = true;
                        resultado.Mensaje = Mensajes.PermisoRolExistente;
                    }
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
        /// Delete permission.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 25/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado EliminarPermiso(Permisos permiso)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            try
            {
                using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_EliminarPermiso))
                {
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMenu, DbType.Int32, permiso.IdMenu);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, permiso.IdRol);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, permiso.login);
                    this.db.ExecuteNonQuery(comandoBaseDatos);
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }
    }
}
