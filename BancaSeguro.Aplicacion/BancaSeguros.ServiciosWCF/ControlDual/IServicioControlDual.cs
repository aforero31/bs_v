//-----------------------------------------------------------------------
// <copyright file="IServicioControlDual.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.ServiciosWCF.ControlDual
{
    using System.ServiceModel;
    using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Administracion;

    /// <summary>
    /// Dual Control Manage Interface
    /// </summary>
    [ServiceContract]
    public interface IServicioControlDual
    {
        /// <summary>
        /// Inserts the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado InsertarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba);

        /// <summary>
        /// Update the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado ActualizarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba);

        /// <summary>
        /// Activate the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado ActivarRegistroEfectivo(int idAprobacionDual);

        /// <summary>
        /// Delete the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado EliminarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba);

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        [OperationContract]
        AprobacionDual ConsultarRegistroControlDualPorId(int idAprobacionDual);
    }
}
