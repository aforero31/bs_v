//-----------------------------------------------------------------------
// <copyright file="RepositorioGrupoBAC.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Seguridad
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Group repository class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 27/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Seguridad.IRepositorioGrupoBAC" />
    public class RepositorioGrupoBAC : IRepositorioGrupoBAC
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
        /// Initializes a new instance of the <see cref="RepositorioGrupoBAC"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioGrupoBAC(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Search the groups.
        /// </summary>
        /// <param name="grupo">The group.</param>
        /// <returns>List of groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<GrupoBAC> ConsultarGruposBAC(GrupoBAC grupo)
        {
            List<GrupoBAC> resultados = new List<GrupoBAC>();
            GrupoBAC resultadogrupo = null;
            Repositorio.Venta.Mapeador mapeador = new Repositorio.Venta.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarGrupoBAC))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, grupo.NombreGrupo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, grupo.CodigoGrupo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, grupo.Activo.HasValue ? grupo.Activo.Value : (bool?)null);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadogrupo = mapeador.DataReaderGrupoBAC(reader));
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Search the group by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of Groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<GrupoBAC> ConsultarGrupoPorRol(Rol rol)
        {
            List<GrupoBAC> resultados = new List<GrupoBAC>();
            Mapeador mapeador = new Mapeador();
            GrupoBAC grupo;
            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarGrupoPorRol))
            {
                this.db.AddInParameter(comandoBaseDatos, Configuraciones.ParametrosEntradaProcedimientos.idRol, DbType.Int32, rol.IdRol);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        grupo = mapeador.DataReaderAGrupoBAC(reader);
                        resultados.Add(grupo);
                    }
                }
            }

            return resultados;
        }

        #endregion
    }
}
