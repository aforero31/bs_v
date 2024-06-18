//-----------------------------------------------------------------------
// <copyright file="RepositorioGenerico.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio
{
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Infraestructura;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;

    /// <summary>
    ///  Repository Generic
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.IRepositorioGenerico" />
    public class RepositorioGenerico : IRepositorioGenerico
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

        /// <summary>
        /// The entity list
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DatatableToList dtl;

        /// <summary>
        /// The entity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DtoCatalogo dto;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioGenerico"/> class.
        /// </summary>
        /// <param name="nombreConexion">Name connection</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioGenerico(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Consults the catalog of name table.
        /// </summary>
        /// <param name="nombreTabla">The table name.</param>
        /// <returns>Return entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DtoCatalogo ConsultarCatalogo(string nombreTabla)
        {
            this.dto = new DtoCatalogo();
            this.dtl = new DatatableToList();
            string nombreProcedimiento = BancaSeguros.Repositorio.Seguridad.Procedimientos.ConsultarCatalogo;

            using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(cmd, "@tblname", DbType.String, string.IsNullOrEmpty(nombreTabla) ? null : nombreTabla);
                DataSet dataSetDevuelto = null;
                dataSetDevuelto = this.db.ExecuteDataSet(cmd);
                if (dataSetDevuelto.Tables[0].Rows.Count > 0)
                {
                    switch (nombreTabla)
                    {
                        case EnumCatalogo.Parentesco:
                            this.dto.ListParentesco = this.dtl.ConvertTo<Parentesco>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.Periodicidad:
                            this.dto.ListPeriodicidad = this.dtl.ConvertTo<Periodicidad>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TipoIdentificacion:
                            this.dto.ListTipoIdentificacion = this.dtl.ConvertTo<TipoIdentificacion>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.Genero:
                            this.dto.ListGenero = this.dtl.ConvertTo<Genero>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TipoProducto:
                            this.dto.ListTipoProducto = this.dtl.ConvertTo<TipoProducto>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.Plan:
                            this.dto.ListPlanes = this.dtl.ConvertTo<Plan>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.Parametro:
                            this.dto.ListParametro = this.dtl.ConvertTo<Parametro>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.CanalVenta:
                            this.dto.ListCanalVenta = this.dtl.ConvertTo<CanalVenta>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TipoDato:
                            this.dto.ListTipoDato = this.dtl.ConvertTo<TipoDato>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TipoValidacion:
                            this.dto.ListTipoValidacion = this.dtl.ConvertTo<TipoValidacion>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TablaAuditada:
                            this.dto.ListTablaAuditada = this.dtl.ConvertTo<TablaAuditada>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TablaNovedad:
                            this.dto.ListTablaNovedad = this.dtl.ConvertTo<Novedad>(dataSetDevuelto.Tables[0]);
                            break;
                        case EnumCatalogo.TablaEventos:
                            this.dto.ListTablaEvento = this.dtl.ConvertTo<Evento>(dataSetDevuelto.Tables[0]);
                            break;
                    }
                }
            }

            return this.dto;
        }

        /// <summary>
        /// Inserta Error y devuelve el numero de registro.
        /// </summary>
        /// <param name="nombreTabla">SEG_LogErrores.</param>
        /// <returns>Return entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 22/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Int64 GuardarError(string exc)
        {
            DbCommand dbCommand = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Seguridad.Procedimientos.GuardarError);
            this.db.AddInParameter(dbCommand, "@Error", DbType.String, exc);
            return Convert.ToInt64(db.ExecuteScalar(dbCommand));           
        }

        #endregion
    }
}
