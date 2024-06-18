//-----------------------------------------------------------------------
// <copyright file="RepositorioRol.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Role repository class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Seguridad.IRepositorioRol" />
    public class RepositorioRol : BancaSeguros.Repositorio.Seguridad.IRepositorioRol
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioRol"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioRol(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Entidades.General.Resultado InsertarRol(Rol rol)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();

            string nombreProcedimiento = Procedimientos.InsertarRol;
            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, rol.Nombre);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, rol.Activo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, rol.Login);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nuevoId, DbType.Int32, 1);
                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                    resultado.Mensaje = Mensajes.RolExistente;
                }
                else
                {
                    int nuevoId = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.nuevoId);
                    if (rol.GruposBAC != null)
                    {
                        foreach (GrupoBAC grupo in rol.GruposBAC)
                        {
                            resultado = this.InsertarRolGrupoBAC(nuevoId, grupo.IdGrupo, true, rol.Login);
                        }
                    }

                    if (rol.Menus != null)
                    {
                        foreach (Menu menu in rol.Menus)
                        {
                            resultado = this.InsertarPermiso(nuevoId, menu.IdMenu, true,rol.Login);
                        }
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Update the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Entidades.General.Resultado ActualizarRol(Rol rol)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();
            string nombreProcedimiento = Procedimientos.ActualizarRol;
            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, rol.IdRol);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, rol.Nombre);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, rol.Activo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, rol.Login);

                if (this.db.ExecuteNonQuery(comandoBaseDatos) > 0)
                {
                    resultado = this.EliminarRolGrupoBAC(rol.IdRol, null,rol.Login);
                    if (rol.GruposBAC != null)
                    {
                        foreach (GrupoBAC grupo in rol.GruposBAC)
                        {
                            resultado = this.InsertarRolGrupoBAC(rol.IdRol, grupo.IdGrupo, true, rol.Login);
                        }
                    }

                    resultado = this.EliminarPermiso(rol.IdRol, null, rol.Login);
                    if (rol.Menus != null)
                    {
                        foreach (Menu menu in rol.Menus)
                        {
                            resultado = this.InsertarPermiso(rol.IdRol, menu.IdMenu, true, rol.Login);
                        }
                    }
                }
                else
                {
                    resultado.Error = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The estate.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Rol> ObtenerRoles(string nombre, string estado)
        {
            string nombreProcedimiento = Procedimientos.ConsultarRoles;
            List<Rol> listaRoles = new List<Rol>();
            Mapeador mapeador = new Mapeador();
            Rol rol;
            using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(cmd, "@nombre", DbType.String, string.IsNullOrEmpty(nombre) ? null : nombre);
                this.db.AddInParameter(cmd, "@estado", DbType.String, string.IsNullOrEmpty(estado) ? null : estado);
                using (IDataReader reader = this.db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        rol = mapeador.DataReaderARol(reader);
                        listaRoles.Add(rol);
                    }
                }
            }

            return listaRoles;
        }

        /// <summary>
        /// Search the role by group.
        /// </summary>
        /// <param name="autenticarUsuario">The user authentication.</param>
        /// <returns>User Authentication</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public AutenticacionUsuario ConsultarRolPorGrupo(AutenticacionUsuario autenticarUsuario)
        {
            string nombreProcedimiento = Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarRolPorGrupo;
            Mapeador mapeador = new Mapeador();
            Rol rol;

            autenticarUsuario.Usuario.Roles = new List<Rol>();

            foreach (var elemento in autenticarUsuario.Usuario.Grupo)
            {
                using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
                {
                    this.db.AddInParameter(cmd, "codigoGrupo", DbType.String, string.IsNullOrEmpty(elemento.CodigoGrupo) ? null : elemento.CodigoGrupo);
                    this.db.AddInParameter(cmd, "nombreGrupo", DbType.String, string.IsNullOrEmpty(elemento.NombreGrupo) ? null : elemento.NombreGrupo);

                    using (IDataReader reader = this.db.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            rol = mapeador.DataReaderARol(reader);

                            if (!autenticarUsuario.Usuario.Roles.Exists(x => x.Nombre == rol.Nombre))
                            {
                                autenticarUsuario.Usuario.Roles.Add(rol);
                            }
                        }
                    }
                }
            }

            if (autenticarUsuario.Usuario.Roles.Count() > 0)
            {
                autenticarUsuario.Autenticado = true;
            }
            else
            {
                autenticarUsuario.Resultado.Mensaje = Mensajes.UsuarioSinRol;
            }

            return autenticarUsuario;
        }

        /// <summary>
        /// Inserts the role group.
        /// </summary>
        /// <param name="idRol">The identifier role.</param>
        /// <param name="idGrupo">The identifier group.</param>
        /// <param name="activo">if set to <c>true</c> [active].</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Entidades.General.Resultado InsertarRolGrupoBAC(int idRol, int idGrupo, bool activo, string login)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Configuraciones.Procedimientos.PR_SEG_InsertarRolGrupoBAC))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idGrupo, DbType.Int32, idGrupo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, activo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, login);
                this.db.ExecuteNonQuery(comandoBaseDatos);
            }

            return resultado;
        }

        /// <summary>
        /// Delete the groups Roles.
        /// </summary>
        /// <param name="idRol">The identifier role.</param>
        /// <param name="idGrupo">The identifier group.</param>
        /// <returns>Result Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Entidades.General.Resultado EliminarRolGrupoBAC(int idRol, int? idGrupo, string login)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();
            try
            {
                using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Configuraciones.Procedimientos.PR_SEG_EliminarRolGrupoBAC))
                {
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idGrupo, DbType.Int32, idGrupo);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, login);
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

        /// <summary>
        /// Inserts the permission.
        /// </summary>
        /// <param name="idRol">The identifier role.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <param name="activo">if set to <c>true</c> [active].</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Entidades.General.Resultado InsertarPermiso(int idRol, int idMenu, bool activo, string login)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Configuraciones.Procedimientos.PR_SEG_InsertarPermiso))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMenu, DbType.Int32, idMenu);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, activo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, login);
                this.db.ExecuteNonQuery(comandoBaseDatos);
            }

            return resultado;
        }

        /// <summary>
        /// Deletes the permission.
        /// </summary>
        /// <param name="idRol">The identifier role.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Entidades.General.Resultado EliminarPermiso(int idRol, int? idMenu, string login)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();
            try
            {
                using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Configuraciones.Procedimientos.PR_SEG_EliminarPermiso))
                {
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMenu, DbType.Int32, idMenu);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, login);
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

        #endregion
    }
}
