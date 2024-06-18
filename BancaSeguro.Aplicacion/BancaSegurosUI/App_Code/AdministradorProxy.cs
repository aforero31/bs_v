//-----------------------------------------------------------------------
// <copyright file="AdministradorProxy.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.App_Code
{
    /// <summary>
    /// Administration Proxy
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class AdministradorProxy
    {
        #region Variables

        /// <summary>
        /// The client security
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static BancaSegurosUI.ServicioSeguridad.ServicioSeguridadClient clienteSeguridad;

        /// <summary>
        /// The client sale
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static BancaSegurosUI.ServicioVenta.ServicioVentaClient clienteVenta;

        /// <summary>
        /// The client generic
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static BancaSegurosUI.ServicioGenerico.ServicioGenericoClient clienteGenerico;

        /// <summary>
        /// The client management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static BancaSegurosUI.ServicioAdministracion.ServicioAdministracionClient clientAdministracion;

        /// <summary>
        /// The client management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static BancaSegurosUI.ServicioAdministracion.ServicioAdministracionClient clientIPC;

        /// <summary>
        /// The client control dual
        /// </summary>
        private static BancaSegurosUI.ServicioControlDual.ServicioControlDualClient clientControlDual;

        #endregion

        #region Metodos

        /// <summary>
        /// Get the client security.
        /// </summary>
        /// <returns>Entity service security</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static BancaSegurosUI.ServicioSeguridad.ServicioSeguridadClient ObtenerClienteSeguridad()
        {
            if (clienteSeguridad == null)
            {
                clienteSeguridad = new BancaSegurosUI.ServicioSeguridad.ServicioSeguridadClient();
            }

            return clienteSeguridad;
        }

        /// <summary>
        /// Get the client sale.
        /// </summary>
        /// <returns>Entity service sale</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static BancaSegurosUI.ServicioVenta.ServicioVentaClient ObtenerClienteVenta()
        {
            if (clienteVenta == null)
            {
                clienteVenta = new ServicioVenta.ServicioVentaClient();
            }          
            return clienteVenta;
        }

        /// <summary>
        /// Get the client generic.
        /// </summary>
        /// <returns>Entity service generic</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static BancaSegurosUI.ServicioGenerico.ServicioGenericoClient ObtenerClienteGenerico()
        {
            if (clienteGenerico == null)
            {
                clienteGenerico = new ServicioGenerico.ServicioGenericoClient();
            }

            return clienteGenerico;
        }

        /// <summary>
        /// Get the client parameterization template.
        /// </summary>
        /// <returns>Entity service management</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static BancaSegurosUI.ServicioAdministracion.ServicioAdministracionClient ObtenerClienteAdministracion()
        {
            if (clientAdministracion == null)
            {
                clientAdministracion = new ServicioAdministracion.ServicioAdministracionClient();
            }

            return clientAdministracion;
        }

        /// <summary>
        /// Get the client parametrization template.
        /// </summary>
        /// <returns>Entity service management</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static BancaSegurosUI.ServicioAdministracion.ServicioAdministracionClient ObtenerClienteIPC()
        {
            if (clientIPC == null)
            {
                clientIPC = new ServicioAdministracion.ServicioAdministracionClient();
            }

            return clientIPC;
        }

        /// <summary>
        /// Gets the client control dual.
        /// </summary>
        /// <returns></returns>
        public static BancaSegurosUI.ServicioControlDual.ServicioControlDualClient ObtenerClienteControlDual()
        {
            if (clientControlDual == null)
            {
                clientControlDual = new ServicioControlDual.ServicioControlDualClient();
            }

            return clientControlDual;
        }

        #endregion
    }
}