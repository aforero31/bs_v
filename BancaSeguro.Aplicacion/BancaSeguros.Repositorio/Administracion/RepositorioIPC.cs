
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
    /// Repository IPC
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 17/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioIPC" />
    public class RepositorioIPC : IRepositorioIPC
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor
        // <summary>
        /// Initializes a new instance of the <see cref="RepositorioIPC"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public RepositorioIPC(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Save the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public Resultado GuardarIPC(IPC ipc)
        {
            Resultado resultado = new Resultado();

            
                DbCommand comandoBaseDatos = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarIPC);

                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.AñoIPC, DbType.Int32, ipc.Ano);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.ValorIPC, DbType.Decimal, ipc.Valor);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, ipc.Login);
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
        /// Update the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public Resultado ActualizaIPC(IPC ipc)
        {
            Resultado resultado = new Resultado();

            
                DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarIPC);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.AñoIPC, DbType.Int32, ipc.Ano);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.ValorIPC, DbType.Decimal, ipc.Valor);
                /*Se deja hasta aqui porque hasta el momento no se permite actualizar 17/05/2016 - Andres Combariza*/
            
            return resultado;
        }

        /// <summary>
        /// Obtain the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public IPC ConsultarIPC()
        {
            IPC resultado = new IPC();
            Mapeador mapeador = new Mapeador();

            using(DbCommand comandoBase = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarIPC))
            {
                using (IDataReader reader = dataBase.ExecuteReader(comandoBase))
                {
                    while (reader.Read())
                    {
                        IPC ipc = new IPC();
                        ipc = mapeador.DataReaderIPC(reader);
                        resultado = ipc;
 
                    }
                }
            }
            return resultado;
        }
        #endregion

    }
}
