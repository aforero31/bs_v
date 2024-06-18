
namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Class Novelty Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    ///  CreationDate: 24/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioNovedad" />
    public class RepositorioNovedad : IRepositorioNovedad
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioNovedad"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioNovedad(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Search novelties.
        /// </summary>
        /// <param name="aseguradora">The novelty to search.</param>
        /// <returns>List results</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Novedad> ConsultarNovedades(Novedad novedad)
        {
            List<Novedad> resultado = new List<Novedad>();
            Mapeador mapeador = new Mapeador();
            Novedad resultadoNovedad = new Novedad();

            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarTipoNovedades))
            {
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoNovedad, DbType.Int32, novedad.CodigoTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreNovedad, DbType.String, novedad.NombreTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.EstadoNovedad, DbType.Boolean, novedad.Activo);
                using (IDataReader reader = this.dataBase.ExecuteReader(comandoBase))
                {
                    while (reader.Read())
                    {
                        resultado.Add(resultadoNovedad = mapeador.DataReaderNovedad(reader));
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Inserts the Novelty.
        /// </summary>
        /// <param name="aseguradora">The Novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarNovedad(Novedad novedad)
        {
            Resultado resultado = new Resultado();
            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarTipoNovedad))
            {
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoNovedad, DbType.Int32, novedad.CodigoTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreNovedad, DbType.String, novedad.NombreTipoNovedad.ToUpper());
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.EstadoNovedad, DbType.Boolean, novedad.Activo);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.Login, DbType.String, novedad.Login);
                this.dataBase.AddOutParameter(comandoBase, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.dataBase.ExecuteNonQuery(comandoBase);                

                int existe = (int)this.dataBase.GetParameterValue(comandoBase, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                    resultado.Mensaje = Mensajes.NovedadExistente;
                }
                else
                {
                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.NovedadGuardada;
                }       
            }

            return resultado;
        }

        /// <summary>
        /// Update the Novelty.
        /// </summary>
        /// <param name="aseguradora">The Novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarNovedad(Novedad novedad)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarTipoNovedad))
            {
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoNovedad, DbType.Int32, novedad.CodigoTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreNovedad, DbType.String, novedad.NombreTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.EstadoNovedad, DbType.Boolean, novedad.Activo);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.IdNovedad, DbType.Int32, novedad.IdTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.Login, DbType.String, novedad.Login);
                this.dataBase.ExecuteNonQuery(comandoBase);
                resultado.Error = false;
            }
            return resultado;
        }
        #endregion
    }
}
