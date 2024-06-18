

namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Class Causal Novelty Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    ///  CreationDate: 27/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioCausalNovedad" />
    public class RepositorioCausalNovedad : IRepositorioCausalNovedad
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
        public RepositorioCausalNovedad(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Inserts the Causal Novelty.
        /// </summary>
        /// <param name="aseguradora">The Causal Novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarCausalNovedad(CausalNovedad causalNovedad)
        {
            Resultado resultado = new Resultado();
            
            using (DbCommand comandoBase = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarCausalNovedad))
            {
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.IdNovedad, DbType.Int32, causalNovedad.IdTipoNovedad);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoCausalNovedad, DbType.String, causalNovedad.CodigoCausalNovedad);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreCausalNovedad, DbType.String, causalNovedad.NombreCausalNovedad.ToUpper());
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.estadoCausalNovedad, DbType.Boolean, causalNovedad.EstadoCausalNovedad);
                dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.Login, DbType.String, causalNovedad.Login);
                dataBase.AddOutParameter(comandoBase, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                dataBase.ExecuteNonQuery(comandoBase);

                int existe = (int)this.dataBase.GetParameterValue(comandoBase, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                    resultado.Mensaje = Mensajes.CausalNovedadExistente;
                }
                else
                {
                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.CausalNovedadGuardada;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Update the Causal Novelty.
        /// </summary>
        /// <param name="aseguradora">The Causal Novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarCausalNovedad))
            {
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.IdCausalNovedad, DbType.Int32, causalNovedad.IdCausalNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.CodigoCausalNovedad, DbType.Int32, causalNovedad.CodigoCausalNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.NombreCausalNovedad, DbType.String, causalNovedad.NombreCausalNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.estadoCausalNovedad, DbType.Boolean, causalNovedad.EstadoCausalNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.IdNovedad, DbType.Int32, causalNovedad.IdTipoNovedad);
                this.dataBase.AddInParameter(comandoBase, ParametrosEntradaProcedimientos.Login, DbType.String, causalNovedad.Login);
                this.dataBase.ExecuteNonQuery(comandoBase);
                resultado.Error = false;
            }

            return resultado;

        }

        /// <summary>
        /// Obtain the Causal Novelty.
        /// </summary>
        /// <param name="aseguradora">The Causal Novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<CausalNovedad> ConsultarCausalNovedad()
        {
            List<CausalNovedad> resultado = new List<CausalNovedad>();
            Mapeador mapeador = new Mapeador();
            CausalNovedad resultadoCausal = new CausalNovedad();
            using (DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarCausalNovedad))
            {
                using (IDataReader reader = this.dataBase.ExecuteReader(comandoBase))
                {
                    while (reader.Read())
                    {
                        resultado.Add(resultadoCausal = mapeador.DataReaderCausalNovedad(reader));
                    }
                }
            }

            return resultado;
        }
        #endregion
    }
}
