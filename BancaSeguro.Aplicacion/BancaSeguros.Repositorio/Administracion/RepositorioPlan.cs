//-----------------------------------------------------------------------
// <copyright file="RepositorioPlan.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// Plan repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class RepositorioPlan : IRepositorioPlan
    {
        private Database dataBase;

        public RepositorioPlan(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        /// <summary>
        /// Saves a plan.
        /// </summary>
        /// <param name="plan">The plan.</param>
        /// <returns>Resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarPlan(Plan plan)
        {
            Resultado resultado = new Resultado();

            DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarPlan);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, plan.IdSeguro);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idPeriodicidad, DbType.Int32, plan.Periodicidad.IdPeriodicidad);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.Decimal, plan.Valor);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, plan.NombrePlan);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Descripcion, DbType.String, plan.Descripcion);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.ValorIVA, DbType.Decimal, plan.ValorIVA);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.ValorSinIva, DbType.Decimal, plan.ValorSinIVA);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.CodigoPlan, DbType.Int32, plan.CodigoPlan);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.CodigoConvenio, DbType.Int32, plan.CodigoConvenio);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Int32, plan.Activo);
            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, plan.Login);

            this.dataBase.ExecuteNonQuery(comandoBaseDatos);

            return resultado;
        }

        /// <summary>
        /// Get the plans of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity List Plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Plan> ConsultarPlanesPorIdSeguro(int idSeguro)
        {
            IList<Plan> planes = new List<Plan>();
            Mapeador mapeador = new Mapeador();

            DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPlanesPorIdSeguro);

            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);

            using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
            {
                while (reader.Read())
                {
                    Plan plan = new Plan();
                    plan = mapeador.DataReaderAPlan(reader);
                    planes.Add(plan);
                }
            }
            return planes;
        }

        /// <summary>
        /// update the plan por identifier sure.
        /// </summary>
        /// <param name="planes">The planes.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizaPlanesPorIdSeguro(DataTable planes, string login)
        {
            Resultado resultado = new Resultado();

            SqlDatabase db = (SqlDatabase)EnterpriseLibraryContainer.Current.GetInstance<Database>("CONEXION_BANCASEGURO");

            using (var cmd = db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarPlanesPorId))
            {
                cmd.CommandTimeout = 0;
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.TablaPlan, SqlDbType.Structured, planes);
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.Login, SqlDbType.VarChar, login);

                using (var reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        resultado.Mensaje = reader.IsDBNull(reader.GetOrdinal(Campos.Accion)) ? string.Empty : (string)reader[Campos.Accion];
                    }
                }
            }

            return resultado;
        }
    }
}