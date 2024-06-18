//-----------------------------------------------------------------------
// <copyright file="RepositorioCanalVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Collections.Generic;

    /// <summary>
    /// Repository Channel Sale
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioCanalVenta" />
    public class RepositorioCanalVenta : IRepositorioCanalVenta
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
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioCanalVenta"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioCanalVenta(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Save the channel sale of identifier.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarCanalVenta(CanalVenta canalVenta)
        {
            Resultado resultado = new Resultado();

            
                DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarCanalVenta);

                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.Int32, canalVenta.Codigo);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, canalVenta.Nombre);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, canalVenta.Activo);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, canalVenta.Login);


                using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
                {
                    if (reader.Read())
                    {
                        resultado.Error = false;
                    }
                    else
                    {
                        resultado.Error = true;
                    }
                }
            return resultado;
        }

        /// <summary>
        /// Update the channel sale of identifier.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizaCanalVentaPorId(CanalVenta canalVenta)
        {
            Resultado resultado = new Resultado();


            DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizaCanalVentaPorId);

            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.IdCanalVenta, DbType.Int32, canalVenta.IdCanalVenta);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.Int32, canalVenta.Codigo);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, canalVenta.Nombre);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, canalVenta.Activo);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, canalVenta.Login);
            if (this.dataBase.ExecuteNonQuery(comandoBaseDatos) == 1)
            {
                resultado.Error = true;
            }
            else
            {
                resultado.Error = false;
            }
            return resultado;
        }

        /// <summary>
        /// Gets the canales venta activos.
        /// </summary>
        /// <value>
        /// The obtener canales venta activos.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<CanalVenta> ObtenerCanalesVentaActivos()
        {
            IList<CanalVenta> resultado = new List<CanalVenta>();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarCanalesActivos))
            {
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        CanalVenta canalVenta = new CanalVenta();
                        canalVenta = mapeador.DataReaderCanalVenta(reader);
                        resultado.Add(canalVenta);
                    }
                }
            }
            return resultado;
        }
        #endregion
    }
}
