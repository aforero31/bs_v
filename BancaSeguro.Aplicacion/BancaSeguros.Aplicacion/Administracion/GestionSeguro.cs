//-----------------------------------------------------------------------
// <copyright file="GestionSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using Configuraciones;
    using Entidades.Administracion;
    using Entidades.Catalogo;
    using Entidades.General;
    using Entidades.Seguro;
    using Entidades.Tipos;
    using Entidades.Venta;
    using Repositorio.Administracion;
    using Repositorio.Venta;

    /// <summary>
    /// Management secure
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 26/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionSeguro" />
    public class GestionSeguro : IGestionSeguro
    {
        #region Variables

        /// <summary>
        /// The repository secure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Repositorio.Administracion.IRepositorioSeguro repositorioSeguro;

        /// <summary>
        /// The repository plan
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Repositorio.Administracion.IRepositorioPlan repositorioPlan;

        /// <summary>
        /// The repository product not access
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioProductoNoPermitido repositorioProductoNoPermitido;

        /// <summary>
        /// The repository channel sale
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioCanalVenta repositorioCanalVenta;

        /// <summary>
        /// The repository type identification secure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioTipoIdentificacionSeguro repositorioTipoIdentificacionSeguro;

        /// <summary>
        /// The repository document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 11/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionSeguro"/> class.
        /// </summary>
        /// <param name="interfazRepositorioSeguro">The interface repository sure.</param>
        /// <param name="interfazRepositorioPlan">The interface repository plan.</param>
        /// <param name="interfazRepositorioProductoNoPermitido">The interface repository product not access.</param>
        /// <param name="interfazRepositorioCanalVenta">The interface repository channel sale.</param>
        /// <param name="interfazRepositorioTipoIdentificacionSeguro">The interface repository type identification sure.</param>
        /// <param name="repositorioDocumentoPoliza">The interface repository document policy.</param>
        public GestionSeguro(
            Repositorio.Administracion.IRepositorioSeguro interfazRepositorioSeguro,
            Repositorio.Administracion.IRepositorioPlan interfazRepositorioPlan,
            IRepositorioProductoNoPermitido interfazRepositorioProductoNoPermitido,
            IRepositorioCanalVenta interfazRepositorioCanalVenta,
            IRepositorioTipoIdentificacionSeguro interfazRepositorioTipoIdentificacionSeguro,
            IRepositorioDocumentoPoliza repositorioDocumentoPoliza)
        {
            this.repositorioCanalVenta = interfazRepositorioCanalVenta;
            this.repositorioPlan = interfazRepositorioPlan;
            this.repositorioProductoNoPermitido = interfazRepositorioProductoNoPermitido;
            this.repositorioSeguro = interfazRepositorioSeguro;
            this.repositorioTipoIdentificacionSeguro = interfazRepositorioTipoIdentificacionSeguro;
            this.repositorioDocumentoPoliza = repositorioDocumentoPoliza;
        }

        #endregion

        #region Metodos publicos

        /// <summary>
        /// Save the sure.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parameterization sure.</param>
        /// <returns>entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarSeguro(ParametrizacionSeguro parametrizacionSeguro)
        {
            Resultado resultado = new Resultado();
            try
            {
                ResultadoSeguro resultadoSeguro = new ResultadoSeguro();
                resultado = this.ValidarEntidadParametrizacionSeguro(parametrizacionSeguro);

                if (!resultado.Error)
                {
                    parametrizacionSeguro.Seguro.Login = parametrizacionSeguro.Login;
                    resultadoSeguro = this.repositorioSeguro.InsertarSeguro(parametrizacionSeguro.Seguro);
                }

                if (!resultadoSeguro.Resultado.Error && !resultado.Error)
                {
                    resultado = this.InsertarPlanesPorSeguro(parametrizacionSeguro.Planes, resultadoSeguro.IdSeguro, parametrizacionSeguro.Login);
                    resultado = this.InsertarProductosNoPermitidosPorSeguro(parametrizacionSeguro.ProductosNoPermitidos, resultadoSeguro.IdSeguro, parametrizacionSeguro.Login);
                    resultado = this.InsertarTiposIdentificacionSeguroPorSeguro(parametrizacionSeguro.TiposIdentificacionPorSeguro, resultadoSeguro.IdSeguro, parametrizacionSeguro.Login);
                }

                if (!resultadoSeguro.Resultado.Error && !resultado.Error && parametrizacionSeguro.DocumentoPoliza != null)
                {
                    parametrizacionSeguro.DocumentoPoliza.IdSeguro = resultadoSeguro.IdSeguro;
                    parametrizacionSeguro.DocumentoPoliza.UsuarioCreacion = parametrizacionSeguro.Login;
                    resultado = this.repositorioDocumentoPoliza.InsertarPlantillaSeguroDuplicada(parametrizacionSeguro.DocumentoPoliza);
                }

                if (resultado.Error)
                {
                    var controlError = LlavesAplicacion.ErrorGuardarProducto;
                    int evento = int.Parse(LlavesAplicacion.EventoGuardarProducto);
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(evento, controlError);
                }
                else
                {
                    var controlError = LlavesAplicacion.GuardarProductoSatisfactorio;
                    int evento = int.Parse(LlavesAplicacion.EventoGuardarProducto);
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(evento, controlError);
                }
            }
            catch (Exception exception)
            {
                resultado = new Resultado();
                var controlError = LlavesAplicacion.ExcepcionGuardarProducto;
                int evento = int.Parse(LlavesAplicacion.EventoGuardarProducto);
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(evento, exception, controlError);
            }

            return resultado;
        }

        /// <summary>
        /// Get the channel sale active.
        /// </summary>
        /// <returns>channel sale List</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<CanalVenta> ObtenerCanalesVentaActivos()
        {
            return this.repositorioCanalVenta.ObtenerCanalesVentaActivos();
        }

        /// <summary>
        /// Get all the sure.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Seguro> ConsultarTodosLosSeguros()
        {
            return this.repositorioSeguro.ConsultarTodosLosSeguros();
        }

        /// <summary>
        /// Update the sure of identifier.
        /// </summary>
        /// <param name="parametrizacionSeguro">The sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarSeguroPorId(ParametrizacionSeguro parametrizacionSeguro)
        {
            Resultado resultado = new Resultado();

            try
            {
                parametrizacionSeguro.Seguro.Login = parametrizacionSeguro.Login;
                resultado = this.repositorioSeguro.ActualizarSeguroPorId(parametrizacionSeguro.Seguro);

                List<TipoPlan> tipoPlanes = new List<TipoPlan>();
                tipoPlanes = this.MapearPlanATipoPlan(parametrizacionSeguro.Planes, parametrizacionSeguro.Seguro.IdSeguro);
                DataTable planes = new DataTable();
                planes = this.ToDataTable<TipoPlan>(tipoPlanes);
                resultado = this.repositorioPlan.ActualizaPlanesPorIdSeguro(planes, parametrizacionSeguro.Login);

                List<TipoProductoNoPermitido> tipoProductos = new List<TipoProductoNoPermitido>();
                tipoProductos = this.MapearProductoNoATipo(parametrizacionSeguro.ProductosNoPermitidos, parametrizacionSeguro.Seguro.IdSeguro);
                DataTable produtos = new DataTable();
                produtos = this.ToDataTable<TipoProductoNoPermitido>(tipoProductos);
                resultado = this.repositorioProductoNoPermitido.ActualizarProductosNoPermitidosPorId(produtos, parametrizacionSeguro.Seguro.IdSeguro, parametrizacionSeguro.Login);

                List<TipoSeguroTipoIdenti> tiposIdentificaciones = new List<TipoSeguroTipoIdenti>();
                tiposIdentificaciones = this.MapearTipIdentATipIdentifi(parametrizacionSeguro.TiposIdentificacionPorSeguro, parametrizacionSeguro.Seguro.IdSeguro);
                DataTable tiposIdentificacion = new DataTable();
                tiposIdentificacion = this.ToDataTable<TipoSeguroTipoIdenti>(tiposIdentificaciones);
                resultado = this.repositorioTipoIdentificacionSeguro.ActualizarSeguroTipoIdentiPorId(tiposIdentificacion, parametrizacionSeguro.Login);

                if (parametrizacionSeguro.DocumentoPoliza != null)
                {
                    parametrizacionSeguro.DocumentoPoliza.UsuarioCreacion = parametrizacionSeguro.Login;
                    resultado = this.repositorioDocumentoPoliza.ActualizarPlantilla(parametrizacionSeguro.DocumentoPoliza);
                }
                else if (!parametrizacionSeguro.Seguro.Activo && parametrizacionSeguro.Seguro.IdSeguro != 0)
                {
                    resultado = this.repositorioDocumentoPoliza.DesActivarPlantillasPorIdSeguro(parametrizacionSeguro.Seguro.IdSeguro);
                }

                if (resultado.Error)
                {
                    var controlError = LlavesAplicacion.ErrorActualizarProducto;
                    int evento = int.Parse(LlavesAplicacion.EventoActualizarProducto);
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(evento, controlError);
                }
                else
                {
                    var controlError = LlavesAplicacion.ActualizarProductoSatisfactorio;
                    int evento = int.Parse(LlavesAplicacion.EventoActualizarProducto);
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(evento, controlError);
                }
            }
            catch (Exception exception)
            {
                resultado = new Resultado();
                var controlError = LlavesAplicacion.ExcepcionActualizarProducto;
                int evento = int.Parse(LlavesAplicacion.EventoActualizarProducto);
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(evento, exception, controlError);
            }

            return resultado;
        }

        /// <summary>
        /// Get sure
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity Sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ParametrizacionSeguro ConsultarInformacionSeguroPorId(int idSeguro)
        {
            ParametrizacionSeguro parametrizacionSeguro = new ParametrizacionSeguro();

            parametrizacionSeguro.Seguro = this.repositorioSeguro.ConsultarSeguroPorId(idSeguro);
            parametrizacionSeguro.Planes = this.repositorioPlan.ConsultarPlanesPorIdSeguro(idSeguro);
            parametrizacionSeguro.TiposIdentificacionPorSeguro = this.repositorioTipoIdentificacionSeguro.ConsultarTiposIdentificacionPorIdSeguro(idSeguro);
            parametrizacionSeguro.ProductosNoPermitidos = this.repositorioProductoNoPermitido.ConsultarProductosNoPermitidosPorSeguro(idSeguro);
            parametrizacionSeguro.DocumentoPoliza = this.repositorioDocumentoPoliza.ObtenerDocumentoPolizaPorIdSeguro(idSeguro);

            return parametrizacionSeguro;
        }

        /// <summary>
        /// Get all the sure.
        /// </summary>
        /// <param name="nombreProducto">the name product</param>
        /// <param name="codigoProducto">the code product</param>
        /// <param name="nombreAseguradora">the name insurance</param>
        /// <returns>Entity result</returns>
        public List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora)
        {
            List<Seguro> seguros = new List<Seguro>();

            try
            {
                seguros = this.repositorioSeguro.ConsultarSegurosPorParametros(nombreProducto, codigoProducto, nombreAseguradora);
            }
            catch (Exception)
            {
                seguros = null;
            }

            return seguros;
        }

        /// <summary>
        /// Get sure by insurance.
        /// </summary>
        /// <param name="idAseguradora">the identifier insurance</param>
        /// <returns>list entity sure</returns>
        public List<Seguro> ConsultarSegurosPorAseguradora(int idAseguradora)
        {
            List<Seguro> seguros = this.repositorioSeguro.ConsultarTodosLosSeguros();
            return seguros.Where(x => x.Aseguradora.IdAseguradora == idAseguradora).ToList();
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Map product a type
        /// </summary>
        /// <param name="productosNoPermitidos">The product not access</param>
        /// <param name="idSeguro">the identifier sure</param>
        /// <returns>Entity list product not access</returns>
        private List<TipoProductoNoPermitido> MapearProductoNoATipo(IList<ProductoNoPermitido> productosNoPermitidos, int idSeguro)
        {
            List<TipoProductoNoPermitido> tipoProductos = new List<TipoProductoNoPermitido>();

            foreach (var item in productosNoPermitidos)
            {
                TipoProductoNoPermitido tipo = new TipoProductoNoPermitido();

                tipo.IdSeguro = idSeguro;
                tipo.CodigoProducto = item.Producto.Codigo.ToString();
                tipo.CodigoSubProducto = item.SubProducto.Codigo.ToString();
                tipo.CodigoCategoria = item.Categoria.Codigo.ToString();
                tipoProductos.Add(tipo);
            }

            return tipoProductos;
        }

        /// <summary>
        /// Map type identification a type identification
        /// </summary>
        /// <param name="tiposIdentificacionPorSeguro">The type identification</param>
        /// <param name="idSeguro">The identifier sure</param>
        /// <returns>Entity list type sure</returns>
        private List<TipoSeguroTipoIdenti> MapearTipIdentATipIdentifi(IList<TipoIdentificacion> tiposIdentificacionPorSeguro, int idSeguro)
        {
            List<TipoSeguroTipoIdenti> tipoIdentificacionesPorSeguro = new List<Entidades.Tipos.TipoSeguroTipoIdenti>();

            foreach (var item in tiposIdentificacionPorSeguro)
            {
                TipoSeguroTipoIdenti tipo = new Entidades.Tipos.TipoSeguroTipoIdenti();
                tipo.IdSeguro = idSeguro;
                tipo.IdTipoIdentificacion = item.IdTipoIdentificacion;
                tipoIdentificacionesPorSeguro.Add(tipo);
            }

            return tipoIdentificacionesPorSeguro;
        }

        /// <summary>
        /// Map plan a type plan
        /// </summary>
        /// <param name="planes">The plans</param>
        /// <param name="idSeguro">The identifier sure</param>
        /// <returns>Entity list type plan</returns>
        private List<TipoPlan> MapearPlanATipoPlan(IList<Plan> planes, int idSeguro)
        {
            List<TipoPlan> tipoPlanes = new List<TipoPlan>();

            foreach (var item in planes)
            {
                TipoPlan tipoPlan = new TipoPlan();
                tipoPlan.Activo = item.Activo;
                tipoPlan.CodigoConvenio = item.CodigoConvenio;
                tipoPlan.CodigoPlan = item.CodigoPlan;
                tipoPlan.Descripcion = item.Descripcion;
                tipoPlan.IdPeriodicidad = item.Periodicidad.IdPeriodicidad;
                tipoPlan.IdPlan = item.IdPlan;
                tipoPlan.IdSeguro = item.IdSeguro;
                tipoPlan.NombrePlan = item.NombrePlan;
                tipoPlan.Valor = item.Valor;
                tipoPlan.ValorIVA = item.ValorIVA;
                tipoPlan.ValorSinIVA = item.ValorSinIVA;
                tipoPlan.IdSeguro = idSeguro;
                tipoPlanes.Add(tipoPlan);
            }

            return tipoPlanes;
        }

        /// <summary>
        /// Insert the plan of sure.
        /// </summary>
        /// <param name="planes">The plan.</param>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <param name="login">The login.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado InsertarPlanesPorSeguro(IList<Plan> planes, int idSeguro, string login)
        {
            Resultado resultado = new Resultado();

            foreach (var plan in planes)
            {
                plan.IdSeguro = idSeguro;
                plan.Login = login;
                resultado = this.repositorioPlan.GuardarPlan(plan);
            }

            return resultado;
        }

        /// <summary>
        /// Insert the products not access of sure.
        /// </summary>
        /// <param name="productosNoPermitidos">The product not access.</param>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <param name="login">The login.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado InsertarProductosNoPermitidosPorSeguro(IList<ProductoNoPermitido> productosNoPermitidos, int idSeguro, string login)
        {
            Resultado resultado = new Resultado();
            string mensaje = string.Empty;

            if (productosNoPermitidos != null)
            {
                foreach (var productoNoPermitido in productosNoPermitidos)
                {
                    productoNoPermitido.IdSeguro = idSeguro;
                    productoNoPermitido.Login = login;
                    resultado = this.repositorioProductoNoPermitido.GuardarProductoNoPermitido(productoNoPermitido);
                    if (resultado.Error)
                    {
                        mensaje = string.Concat(mensaje, resultado.Mensaje, "</br>");
                    }
                }
            }

            resultado.Error = !string.IsNullOrEmpty(mensaje);
            resultado.Mensaje = mensaje;
            return resultado;
        }

        /// <summary>
        /// Insert the type identification sure of sure.
        /// </summary>
        /// <param name="tiposIdentificacion">The type identification.</param>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <param name="login">The login.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado InsertarTiposIdentificacionSeguroPorSeguro(IList<TipoIdentificacion> tiposIdentificacion, int idSeguro, string login)
        {
            Resultado resultado = new Resultado();
            string mensaje = string.Empty;
            foreach (var tipoIdentificacion in tiposIdentificacion)
            {
                resultado = this.repositorioTipoIdentificacionSeguro.GuardarTipoDocumentoSeguro(idSeguro, tipoIdentificacion.IdTipoIdentificacion, login);
                if (resultado.Error)
                {
                    mensaje = string.Concat(mensaje, resultado.Mensaje, "</br>");
                }
            }

            resultado.Error = !string.IsNullOrEmpty(mensaje);
            resultado.Mensaje = mensaje;
            return resultado;
        }

        /// <summary>
        /// validate the entity parameterization sure.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parameterization sure.</param>
        /// <returns>entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado ValidarEntidadParametrizacionSeguro(ParametrizacionSeguro parametrizacionSeguro)
        {
            Resultado resultado = new Resultado();
            string mensajeResultado = string.Empty;

            if (parametrizacionSeguro.Planes.Count == 0)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroPlanes);
            }

            if (parametrizacionSeguro.TiposIdentificacionPorSeguro.Count == 0)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroTiposIdentificacion);
            }

            if (parametrizacionSeguro.Seguro.IdAseguradora == 0)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroTiposIdentificacion);
            }

            if (string.IsNullOrEmpty(parametrizacionSeguro.Seguro.Codigo))
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroCodigo);
            }

            if (string.IsNullOrEmpty(parametrizacionSeguro.Seguro.Descripcion))
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroDescripcion);
            }

            if (parametrizacionSeguro.Seguro.Conyuge ? parametrizacionSeguro.Seguro.EdadMaximaConyuge <= 0 : false)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroEdadMaximaConyuge);
            }

            if (parametrizacionSeguro.Seguro.Conyuge ? parametrizacionSeguro.Seguro.EdadMinimaConyuge <= 0 : false)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroEdadMinimaConyuge);
            }

            if (parametrizacionSeguro.Seguro.Conyuge ? (parametrizacionSeguro.Seguro.EdadMinimaConyuge >= parametrizacionSeguro.Seguro.EdadMaximaConyuge) : false)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroEdadMinimaMaximaConyuge);
            }

            if (parametrizacionSeguro.Seguro.Beneficiario ? (parametrizacionSeguro.Seguro.MaximoBeneficiarios == 0) : false)
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroNumeroBeneficiarios);
            }

            if (string.IsNullOrEmpty(parametrizacionSeguro.Seguro.Nombre))
            {
                mensajeResultado = string.Concat(mensajeResultado, Mensajes.ParametrizacionSeguroNombreSeguro);
            }

            if (!string.IsNullOrEmpty(mensajeResultado.ToString()))
            {
                resultado.Error = true;
                resultado.Mensaje = mensajeResultado.ToString();
            }

            return resultado;
        }

        /// <summary>
        /// Convert list a data table
        /// </summary>
        /// <typeparam name="T">the generic type</typeparam>
        /// <param name="items">the items list</param>
        /// <returns>data table</returns>
        private DataTable ToDataTable<T>(IList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }

            foreach (DataRow fila in dataTable.Rows)
            {
                foreach (DataColumn columna in dataTable.Columns)
                {
                    fila[columna] = fila[columna].ToString().Replace(",", ".");
                }
            }

            return dataTable;
        }

        #endregion
    }
}
