using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Venta;
using System.Collections.Generic;

namespace BancaSeguros.Aplicacion.Cobis
{
    public interface IGestionCobis
    {
        Cliente ConsultarInformacionCliente(Cliente cliente, string usuario);

        Cliente ClienteEstaEnListasInhibitorias(Cliente cliente);

        List<ProductoBancario> ConsultarProductosBancarios(Cliente cliente, string usuario);

        Resultado CreacionRapidaCliente(Cliente cliente, string usuario);

        Resultado GenerarDebitoACuentaCliente(RegistrarVenta registrarVenta);

        Resultado GenerarCreditoACuentaAseguradora(RegistrarVenta registrarVenta);

        Resultado GenerarRecaudoACliente(RegistrarVenta registrarVenta, ref LogCobis datosLog, string consecutivoVenta);
    }
}