namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Configuraciones;
    using Entidades.General;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioVenta : IRepositorioVenta
    {
        #region Variables

        private Database db;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Contructor donde obtiene la conexion de la Base de datos
        /// </summary>
        /// <param name="nombreConexion"></param>
        public RepositorioVenta(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion Constructor

        #region Metodos Publicos

        #region Venta

        public string ObtenerConsecutivo(RegistrarVenta registrarVenta)
        {
            string consecutivoNroPoliza = string.Empty;

            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ConstruirNroPoliza);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idPlan, DbType.Int32, registrarVenta.IdPlan);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.identificacion, DbType.String, registrarVenta.Cliente.Identificacion);

            using (IDataReader reader = this.db.ExecuteReader(dataBaseCommand))
            {
                while (reader.Read())
                {
                    consecutivoNroPoliza = reader.IsDBNull(reader.GetOrdinal("NroPolizaGenerada")) ? string.Empty : (string)reader["NroPolizaGenerada"];
                }
            }

            return consecutivoNroPoliza;
        }

        public bool ActualizarSiguienteConsecutivo(RegistrarVenta registrarVenta)
        {
            string consecutivoNroPoliza = string.Empty;

            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarSiguienteConsecutivo);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idPlan, DbType.Int32, registrarVenta.IdPlan);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.identificacion, DbType.String, registrarVenta.Cliente.Identificacion);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, registrarVenta.Consecutivo);           
            if (db.ExecuteNonQuery(dataBaseCommand) > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Saves the sale data into asesor table.
        /// </summary>
        /// <param name="asesor">The asesor.</param>
        /// <returns>Respuesta de la tranasaccion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool GuardarDatosVentaEnTablaAsesor(Asesor asesor)
        {
            string idAsesor = string.Empty;

            DbCommand dbCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarAsesor);
            this.db.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.idAsesor, DbType.String, asesor.IdAsesor);
            this.db.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.idOficina, DbType.Int32, asesor.Oficina.IdOficina);
            this.db.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.nombre, DbType.String, asesor.Nombre);
            this.db.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.identificacion, DbType.String, asesor.Identificacion);

            this.db.ExecuteNonQuery(dbCommand);

            return false;
        }

        public RegistrarVenta GuardarDatosVentaEnTablaVenta(RegistrarVenta RegistrarVenta)
        {
            DbCommand dbCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarVenta);
            this.db.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.actividadEconomica, DbType.String, RegistrarVenta.Cliente.ActividadEconomica);
            this.db.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.ciudadNacimiento, DbType.String, RegistrarVenta.Cliente.CiudadNacimiento);
            this.db.AddInParameter(dbCommand, "ciudadResidencia", DbType.String, RegistrarVenta.Cliente.CiudadResidencia);
            this.db.AddInParameter(dbCommand, "correo", DbType.String, RegistrarVenta.Cliente.Correo);
            this.db.AddInParameter(dbCommand, "direccion", DbType.String, RegistrarVenta.Cliente.Direccion);
            this.db.AddInParameter(dbCommand, "fechaNacimiento", DbType.DateTime, RegistrarVenta.Cliente.FechaNacimiento);
            this.db.AddInParameter(dbCommand, "idgenero", DbType.Int16, RegistrarVenta.Cliente.IdGenero);
            this.db.AddInParameter(dbCommand, "identificacion", DbType.String, RegistrarVenta.Cliente.Identificacion);
            this.db.AddInParameter(dbCommand, "idTipoIdentificacion", DbType.Int32, RegistrarVenta.Cliente.TipoIdentificacion.IdTipoIdentificacion);
            this.db.AddInParameter(dbCommand, "nacionalidad", DbType.String, RegistrarVenta.Cliente.Nacionalidad);
            this.db.AddInParameter(dbCommand, "primerApellido", DbType.String, RegistrarVenta.Cliente.PrimerApellido);
            this.db.AddInParameter(dbCommand, "primerNombre", DbType.String, RegistrarVenta.Cliente.PrimerNombre);
            this.db.AddInParameter(dbCommand, "segundoApellido", DbType.String, RegistrarVenta.Cliente.SegundoApellido);
            this.db.AddInParameter(dbCommand, "segundoNombre", DbType.String, RegistrarVenta.Cliente.SegundoNombre);
            this.db.AddInParameter(dbCommand, "telefono", DbType.String, RegistrarVenta.Cliente.Telefono);
            this.db.AddInParameter(dbCommand, "celular", DbType.String, RegistrarVenta.Cliente.Celular);
            this.db.AddInParameter(dbCommand, "consecutivo", DbType.String, RegistrarVenta.Consecutivo);
            this.db.AddInParameter(dbCommand, "idPlan", DbType.Int32, RegistrarVenta.IdPlan);
            this.db.AddInParameter(dbCommand, "idAsesor", DbType.String, RegistrarVenta.Asesor.IdAsesor);
            this.db.AddInParameter(dbCommand, "idOficina", DbType.String, RegistrarVenta.Asesor.Oficina.IdOficina);
            this.db.AddInParameter(dbCommand, "codigoTipoCuenta", DbType.Int16, Convert.ToInt16(RegistrarVenta.ProductoBancario.CodigoProducto));
            this.db.AddInParameter(dbCommand, "numeroCuenta", DbType.String, RegistrarVenta.ProductoBancario.NumeroCuenta);
            this.db.AddInParameter(dbCommand, "valorPoliza", DbType.Decimal, RegistrarVenta.ProductoBancario.Saldo);
            this.db.AddInParameter(dbCommand, "departamentoResidencia", DbType.String, RegistrarVenta.Cliente.DepartamentoResidencia);
            this.db.AddInParameter(dbCommand, "codigoDANE", DbType.String, RegistrarVenta.Cliente.CodigoDANE);

            RegistrarVenta.IdVenta = int.Parse(db.ExecuteScalar(dbCommand).ToString());

            return RegistrarVenta;
        }

        public bool GuardarDatosVentaEnTablaConyugue(Conyuge conyuge)
        {
            DbCommand dbCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarConyuge);
            this.db.AddInParameter(dbCommand, "idVenta", DbType.Int32, conyuge.IdVenta);
            this.db.AddInParameter(dbCommand, "idTipoIdentificacion", DbType.Int32, conyuge.IdTipoIdentificacion);
            this.db.AddInParameter(dbCommand, "identificacion", DbType.String, conyuge.Identificacion);
            this.db.AddInParameter(dbCommand, "primerNombre", DbType.String, conyuge.PrimerNombre);
            this.db.AddInParameter(dbCommand, "segundoNombre", DbType.String, conyuge.SegundoNombre);
            this.db.AddInParameter(dbCommand, "primerApellido", DbType.String, conyuge.PrimerApellido);
            this.db.AddInParameter(dbCommand, "segundoApellido", DbType.String, conyuge.SegundoApellido);
            this.db.AddInParameter(dbCommand, "fechaNacimiento", DbType.DateTime, conyuge.FechaNacimiento);
            this.db.AddInParameter(dbCommand, "idgenero", DbType.Int16, conyuge.IdGenero);

            if (db.ExecuteNonQuery(dbCommand) > 0)
                return true;
            return false;
        }

        public bool GuardarDatosVentaEnTablaBeneficiario(Beneficiario beneficiario)
        {
            DbCommand dbCommand = db.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarBeneficiario);
            db.AddInParameter(dbCommand, "idVenta", DbType.Int32, beneficiario.IdVenta);
            db.AddInParameter(dbCommand, "idParentesco", DbType.Int32, beneficiario.IdParentesco);
            db.AddInParameter(dbCommand, "idTipoIdentificacion", DbType.Int32, beneficiario.IdTipoIdentificacion);
            db.AddInParameter(dbCommand, "identificacion", DbType.String, beneficiario.Identificacion);
            db.AddInParameter(dbCommand, "nombres", DbType.String, beneficiario.Nombres);
            db.AddInParameter(dbCommand, "apellidos", DbType.String, beneficiario.Apellidos);
            db.AddInParameter(dbCommand, "porcentaje", DbType.Int32, beneficiario.Porcentaje);

            if (db.ExecuteNonQuery(dbCommand) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Save  the sale variable.
        /// </summary>
        /// <param name="variables">The variable.</param>
        /// <returns>Value of result</returns>
        public bool GuardarVariableVenta(VariableVenta variable)
        {
            bool exitoso = false;

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarVariableVenta))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVenta, DbType.Int32, variable.IdVenta);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, variable.Valor);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, variable.Login);

                int resultado = this.db.ExecuteNonQuery(comandoBaseDatos);

                if (resultado > 0 || resultado == -1)
                {
                    exitoso = true;
                }
            }

            return exitoso;
        }

        #endregion Venta

        #region Consultar Venta

        public List<ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente)
        {
            List<ConsultarVenta> listaConsulta = new List<ConsultarVenta>();
            ConsultarVenta consultarVenta;
            Mapeador mapeador = new Mapeador();

            //try
            //{
            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPolizasPorCliente);

            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idTipoDeIdentificacion, DbType.Int32, cliente.TipoIdentificacion.IdTipoIdentificacion);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.identificacion, DbType.String, cliente.Identificacion);

            using (IDataReader reader = db.ExecuteReader(dataBaseCommand))
            {
                while (reader.Read())
                {
                    listaConsulta.Add(consultarVenta = mapeador.DataReaderAConsultarVenta(reader));
                }
            }

            //}
            //catch (Exception ex)
            //{
            //listaConsulta = new List<ConsultarVenta>();
            //consultarVenta = new ConsultarVenta();
            //consultarVenta.ManejoExcepcion = new Entidades.General.ManejoExcepcion();
            //consultarVenta.ManejoExcepcion.Error = true;
            //consultarVenta.ManejoExcepcion.Mensaje = ex.Message;
            //listaConsulta.Add(consultarVenta);
            //}

            return listaConsulta;
        }

        public List<ConsultarVenta> ConsultarVentaPorClienteDiaHabil(Cliente cliente)
        {
            List<ConsultarVenta> listaConsulta = new List<ConsultarVenta>();
            ConsultarVenta consultarVenta;
            Mapeador mapeador = new Mapeador();

            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPolizasPorClienteDiaHabil);

            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idTipoDeIdentificacion, DbType.Int32, cliente.TipoIdentificacion.IdTipoIdentificacion);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.identificacion, DbType.String, cliente.Identificacion);

            using (IDataReader reader = db.ExecuteReader(dataBaseCommand))
            {
                while (reader.Read())
                {
                    listaConsulta.Add(consultarVenta = mapeador.DataReaderAConsultarVenta(reader));
                }
            }

            return listaConsulta;
        }

        /// <summary>
        /// Get the sale account of client.
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ConsultarVentasCuentasPorCliente(Cliente cliente)
        {
            Resultado resultado = new Resultado();

            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarVentasCuentasPorCliente);

            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idTipoDeIdentificacion, DbType.Int32, cliente.TipoIdentificacion.IdTipoIdentificacion);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.identificacion, DbType.String, cliente.Identificacion);
            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.codigoSeguro, DbType.Int32, cliente.CodigoSeguro);

            using (IDataReader reader = db.ExecuteReader(dataBaseCommand))
            {
                while (reader.Read())
                {
                    resultado.Mensaje += reader[0].ToString() + "-" + reader[1].ToString() + "|";
                }
            }
            return resultado;
        }

        #endregion Consultar Venta

        #endregion Metodos Publicos
    }
}