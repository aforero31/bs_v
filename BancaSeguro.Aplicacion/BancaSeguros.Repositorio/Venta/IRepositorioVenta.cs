using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.Venta;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.General;

namespace BancaSeguros.Repositorio.Venta
{
    public interface IRepositorioVenta
    {
        #region Venta

        string ObtenerConsecutivo(RegistrarVenta registrarVenta);

        bool ActualizarSiguienteConsecutivo(RegistrarVenta registrarVenta);

        bool GuardarDatosVentaEnTablaAsesor(Asesor asesor);

        RegistrarVenta GuardarDatosVentaEnTablaVenta(RegistrarVenta registrarVenta);

        bool GuardarDatosVentaEnTablaConyugue(Conyuge conyuge);

        bool GuardarDatosVentaEnTablaBeneficiario(Beneficiario beneficiario);
        /// <summary>
        /// Save  the sale variable.
        /// </summary>
        /// <param name="variables">The variable.</param>
        /// <returns>Value of result</returns>
        bool GuardarVariableVenta(VariableVenta variable);

        #endregion

        #region Consultar Venta

        List<ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente);

        List<ConsultarVenta> ConsultarVentaPorClienteDiaHabil(Cliente cliente);

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
        Resultado ConsultarVentasCuentasPorCliente(Cliente cliente);
            #endregion
        }
}
