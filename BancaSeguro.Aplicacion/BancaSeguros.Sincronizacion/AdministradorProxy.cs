//-----------------------------------------------------------------------
// <copyright file="AdministradorProxy.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Sincronizacion
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
        private static BancaSeguros.Sincronizacion.ServicioSincronizacion.ServicioSincronizacionClient clienteSincronizacion;

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
        public static BancaSeguros.Sincronizacion.ServicioSincronizacion.ServicioSincronizacionClient ObtenerClienteSincronizacion()
        {
            if (clienteSincronizacion == null)
            {
                clienteSincronizacion = new ServicioSincronizacion.ServicioSincronizacionClient();
            }

            return clienteSincronizacion;
        }

        #endregion
    }
}