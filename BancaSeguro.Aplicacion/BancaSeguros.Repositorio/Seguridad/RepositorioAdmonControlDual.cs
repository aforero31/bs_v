using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BAC.EntidadesSeguridad;
using System.Data.Common;
using System.Data;
using BancaSeguros.Entidades.Seguridad;

namespace BancaSeguros.Repositorio.Seguridad
{
    public class RepositorioAdmonControlDual : IRepositorioAdmonControlDual
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioAdmonControlDual"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioAdmonControlDual(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtain the items of menu.
        /// </summary>
        /// <param name="aseguradora">The menu</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Menu> ConsultarMenuControlDual()
        {
            string nombreProcedimiento = Procedimientos.ConsultarMenuControlDual;

            List<Menu> listaMenu = new List<Menu>();
            Mapeador mapeador = new Mapeador();
            Menu menu;
            using (DbCommand cmd = dataBase.GetStoredProcCommand(nombreProcedimiento))
            {
                using (IDataReader reader = dataBase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        menu = mapeador.DataReaderMenuControlDual(reader);
                        listaMenu.Add(menu);
                    }
                }
            }
            return listaMenu;
        }

        /// <summary>
        /// Obtain the list of roles.
        /// </summary>
        /// <param name="aseguradora">The Rol</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual()
        {
            string nombreProcedimiento = Procedimientos.ConsultarAdmonControlDual;


            List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> listaRoles = new List<AdministracionControlDual>();
            Mapeador mapeador = new Mapeador();
            BancaSeguros.Entidades.Seguridad.AdministracionControlDual rol;
            using (DbCommand cmd = dataBase.GetStoredProcCommand(nombreProcedimiento))
            {
                using (IDataReader reader = dataBase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        rol = mapeador.DataReaderAdmonControlDual(reader);
                        listaRoles.Add(rol);
                    }
                }
            }
            return listaRoles;
        }

        /// <summary>
        /// Obtain the list of roles for IdMenu.
        /// </summary>
        /// <param name="aseguradora">The Rol</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu)
        {
            string nombreProcedimiento = Procedimientos.ConsultarAdmonControlDualIdMenu;
            List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> listaRoles = new List<AdministracionControlDual>();
            Mapeador mapeador = new Mapeador();
            BancaSeguros.Entidades.Seguridad.AdministracionControlDual rol;
            using (DbCommand cmd = dataBase.GetStoredProcCommand(nombreProcedimiento))
            {
                this.dataBase.AddInParameter(cmd, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.idMenu, DbType.Int32, idMenu);

                using (IDataReader reader = dataBase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        rol = mapeador.DataReaderAdmonControlDual(reader);
                        listaRoles.Add(rol);
                    }
                }
            }

            return listaRoles;
        }

        /// <summary>
        /// Insert the list of roles for Control Dual.
        /// </summary>
        /// <param name="aseguradora">The Rol</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Entidades.General.Resultado InsertarAdmonControlDual(List<AdministracionControlDual> controlDual)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();
            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_InsertarAdmonControlDual))
            {
                int existe = 0;
                foreach (var item in controlDual)
                {
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.idMenu, DbType.Int32, item.IdMenu);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.idRol, DbType.Int32, item.IdRol);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.requiere, DbType.Boolean, item.Requiere);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.autoriza, DbType.Boolean, item.Autoriza);
                    this.dataBase.AddOutParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                    dataBase.ExecuteNonQuery(comandoBase);
                    existe = (int)this.dataBase.GetParameterValue(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.existe);
                    comandoBase.Parameters.Clear();
                }
            }
            return resultado;
        }

        /// <summary>
        /// Update the list of roles for Control Dual.
        /// </summary>
        /// <param name="aseguradora">The Rol</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Entidades.General.Resultado ActualizarAdmonControlDual(List<AdministracionControlDual> controlDual)
        {
            Entidades.General.Resultado resultado = new Entidades.General.Resultado();
            
            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ActualizarAdmonControlDual))
            {
                foreach (var item in controlDual)
                {
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.IdControlDual, DbType.Int32, item.IdControlDual);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.idMenu, DbType.Int32, item.IdMenu);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.idRol, DbType.Int32, item.IdRol);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.requiere, DbType.Boolean, item.Requiere);
                    this.dataBase.AddInParameter(comandoBase, BancaSeguros.Repositorio.Configuraciones.ParametrosEntradaProcedimientos.autoriza, DbType.Boolean, item.Autoriza);
                    dataBase.ExecuteNonQuery(comandoBase);
                    comandoBase.Parameters.Clear();
                }
                resultado.Mensaje = BancaSeguros.Repositorio.Configuraciones.Mensajes.ControlDualActualizado;
            }

            return resultado;
        }

        #endregion
    }
}
