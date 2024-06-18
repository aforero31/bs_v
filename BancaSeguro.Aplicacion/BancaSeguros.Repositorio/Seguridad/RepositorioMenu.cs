//-----------------------------------------------------------------------
// <copyright file="RepositorioMenu.cs" company="Unión temporal FS-BAC-2013 ">
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
    /// Menu repository class
    /// </summary>
    /// <seealso cref="BancaSeguros.Repositorio.Seguridad.IRepositorioMenu" />
    public class RepositorioMenu : BancaSeguros.Repositorio.Seguridad.IRepositorioMenu
    {
        #region Variables

        /// <summary>
        /// database variable
        /// </summary>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioMenu"/> class.
        /// </summary>
        /// <param name="nombreConexion">The connection name.</param>
        public RepositorioMenu(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Gets the menus.
        /// </summary>
        /// <returns>List of menus</returns>
        public List<Menu> ObtenerMenu()
        {
            string nombreProcedimiento = Procedimientos.ConsultarMenu;

            List<Menu> listaMenu = new List<Menu>();
            Mapeador mapeador = new Mapeador();
            Menu menu;
            using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                using (IDataReader reader = this.db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        menu = mapeador.DataReaderAMenu(reader);
                        listaMenu.Add(menu);
                    }
                }
            }

            return listaMenu;
        }

        /// <summary>
        /// Gets the menus by role.
        /// </summary>
        /// <param name="idRol">The identifier role.</param>
        /// <returns>List of menus</returns>
        public List<Menu> ObtenerMenuPorRol(int idRol)
        {
            string nombreProcedimiento = BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarMenuPorRol;

            List<Menu> listaMenu = new List<Menu>();
            Mapeador mapeador = new Mapeador();
            Menu menu;

            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(nombreProcedimiento);

            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);

            using (IDataReader reader = this.db.ExecuteReader(dataBaseCommand))
            {
                while (reader.Read())
                {
                    menu = mapeador.DataReaderAMenu(reader);
                    listaMenu.Add(menu);
                }
            }

            return listaMenu;
        }

        /// <summary>
        /// Search the menus dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        public IList<Menu> ConsultaMenusAprobacionDualPorRol(int idRol)
        {
            List<Menu> listaMenu = new List<Menu>();
            Mapeador mapeador = new Mapeador();
            Menu menu;
            using (DbCommand cmd = this.db.GetStoredProcCommand(Configuraciones.Procedimientos.PR_SEG_ConsultarMenuAprobacionDualPorRol))
            {
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);
                using (IDataReader reader = this.db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        menu = mapeador.DataReaderAMenu(reader);
                        listaMenu.Add(menu);
                    }
                }
            }

            return listaMenu;
        }

        /// <summary>
        /// Search the menus required dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        public IList<Menu> ConsultaMenusRequiereDualPorRol(int idRol)
        {
            List<Menu> listaMenu = new List<Menu>();
            Mapeador mapeador = new Mapeador();
            Menu menu;
            using (DbCommand cmd = this.db.GetStoredProcCommand(Configuraciones.Procedimientos.PR_SEG_ConsultarMenuRequiereDualPorRol))
            {
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.idRol, DbType.Int32, idRol);
                using (IDataReader reader = this.db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        menu = mapeador.DataReaderAMenu(reader);
                        listaMenu.Add(menu);
                    }
                }
            }

            return listaMenu;
        }

        #endregion
    }
}
