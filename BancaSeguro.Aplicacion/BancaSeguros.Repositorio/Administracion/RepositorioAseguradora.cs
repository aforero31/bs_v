//-----------------------------------------------------------------------
// <copyright file="RepositorioAseguradora.cs" company="Unión temporal FS-BAC-2013 ">
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
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
      
    /// <summary>
    /// Class Insurance Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 15/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioAseguradora" />
    public class RepositorioAseguradora : IRepositorioAseguradora 
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
        /// Initializes a new instance of the <see cref="RepositorioAseguradora"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioAseguradora(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Search insurances.
        /// </summary>
        /// <param name="aseguradora">The insurance to search.</param>
        /// <returns>List results</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Aseguradora> ConsultarAseguradoras(Aseguradora aseguradora)
        {
            List<Aseguradora> resultados = new List<Aseguradora>();
            Aseguradora resultadoAseguradora = null;
            Repositorio.Venta.Mapeador mapeador = new Repositorio.Venta.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarAseguradoras))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, aseguradora.Nombre);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, aseguradora.CodigoSuperintendencia);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoIdentificacion, DbType.Int32, aseguradora.TipoIdentificacion != null ? aseguradora.TipoIdentificacion.IdTipoIdentificacion : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.identificacion, DbType.String, aseguradora.Identificacion);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, aseguradora.Activo.HasValue ? aseguradora.Activo.Value : (bool?)null);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoAseguradora = mapeador.DataReaderAseguradora(reader));
                    }
                }
            }
                
            return resultados; 
        }

        /// <summary>
        /// Search Insurance by identifier.
        /// </summary>
        /// <param name="idAseguradora">The identifier.</param>
        /// <returns>Entity Insurance</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Aseguradora ConsultarAseguradoraPorId(int idAseguradora)
        {
            Aseguradora resultado = null;
            Repositorio.Venta.Mapeador mapeador = new Repositorio.Venta.Mapeador();
            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarAseguradoraPorId))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idAseguradora, DbType.Int32, idAseguradora);
                
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultado = mapeador.DataReaderAseguradora(reader);
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Inserts the Insurance.
        /// </summary>
        /// <param name="aseguradora">The Insurance</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarAseguradora(Aseguradora aseguradora)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_InsertarAseguradora))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, aseguradora.Nombre);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, aseguradora.CodigoSuperintendencia);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoIdentificacion, DbType.Int32, aseguradora.TipoIdentificacion != null ? aseguradora.TipoIdentificacion.IdTipoIdentificacion : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.identificacion, DbType.String, aseguradora.Identificacion);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.contacto, DbType.String, aseguradora.Contacto);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.telefono, DbType.String, aseguradora.Telefono);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.correo, DbType.String, aseguradora.Correo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, aseguradora.Activo.HasValue ? aseguradora.Activo.Value : false);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.consecutivoInicial, DbType.Int32, aseguradora.ConsecutivoInicial);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.consecutivoActual, DbType.Int32, aseguradora.ConsecutivoActual);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, aseguradora.Login);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                if (this.db.ExecuteNonQuery(comandoBaseDatos) == 1)
                {
                    resultado.Error = true;
                }
                else
                {
                    resultado.Error = false;
                }
            }
            return resultado; 
        }

        /// <summary>
        /// Update Insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarAseguradora(Aseguradora aseguradora)
        {
            Resultado resultado = new Resultado();

            
                using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ActualizarAseguradora))
                {
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idAseguradora, DbType.Int32, aseguradora.IdAseguradora);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, aseguradora.Nombre);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, aseguradora.CodigoSuperintendencia);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idTipoIdentificacion, DbType.Int32, aseguradora.TipoIdentificacion != null ? aseguradora.TipoIdentificacion.IdTipoIdentificacion : (int?)null);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.identificacion, DbType.String, aseguradora.Identificacion);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.contacto, DbType.String, aseguradora.Contacto);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.telefono, DbType.String, aseguradora.Telefono);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.correo, DbType.String, aseguradora.Correo);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, aseguradora.Activo.HasValue ? aseguradora.Activo.Value : false);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.consecutivoInicial, DbType.Int32, aseguradora.ConsecutivoInicial);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.consecutivoActual, DbType.Int32, aseguradora.ConsecutivoActual);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.actualizaConsecutivo, DbType.Boolean, aseguradora.ActualizaConsecutivo);
                    this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, aseguradora.Login);
                    this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);

                    if (this.db.ExecuteNonQuery(comandoBaseDatos) == 1)
                    {
                        resultado.Error = true;
                    }
                    else
                    {
                        resultado.Error = false;
                    }
                }
            
            
 
            return resultado; 
        }



#endregion
    }
}
