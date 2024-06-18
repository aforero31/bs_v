//-----------------------------------------------------------------------
// <copyright file="IRepositorioCanalVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using System.Collections.Generic;

    /// <summary>
    /// Interface Save Channel Sale
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioCanalVenta
    {
        /// <summary>
        /// Save Channel Sale of Identifier.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarCanalVenta(CanalVenta canalVenta);

        /// <summary>
        /// Update the channel sale of identifier.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizaCanalVentaPorId(CanalVenta canalVenta);

        /// <summary>
        /// Gets the canales venta activos.
        /// </summary>
        /// <returns>CanalVenta list</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<CanalVenta> ObtenerCanalesVentaActivos();
    }
}
