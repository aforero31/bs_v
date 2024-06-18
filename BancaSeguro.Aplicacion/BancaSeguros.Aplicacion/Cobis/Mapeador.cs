using BancaSeguros.Aplicacion.Configuraciones;
using BancaSeguros.Entidades.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.Cobis
{
    public class Mapeador
    {
        public Cliente MapearClienteCobisAClienteBanca(ServicioCobisCliente.Cliente[] clienteArray, int TipoCliente)
        {
            Cliente cliente = new Cliente();            

            if (clienteArray != null && clienteArray.Count() > 0)
            {
                if (clienteArray[0].codDatosActualizados == Parametros.ClienteSinDatosActualizados && TipoCliente == 1)
                {
                    cliente = mapeaCampos(clienteArray);
                    var controlError = LlavesAplicacion.COBIS_ClienteSinDatosActualizados;
                    cliente.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), controlError);
                    cliente.Resultado.Error = true;
                }
                else                
                    cliente = mapeaCampos(clienteArray);             
            }
            else
            {
                var controlError = LlavesAplicacion.COBIS_ClienteSinInformacion;
                cliente.Resultado = new Entidades.General.Resultado();
                cliente.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), controlError);
            }
            return cliente;
        }

        private Cliente mapeaCampos(ServicioCobisCliente.Cliente[] clienteArray)
        {
            Cliente cliente = new Cliente();
            cliente.Resultado = new Entidades.General.Resultado();
            if (clienteArray[0].persona != null && clienteArray[0].persona.personaNatural != null)
            {
                cliente.PrimerApellido = clienteArray[0].persona.personaNatural.valPrimerApellido;
                cliente.SegundoApellido = clienteArray[0].persona.personaNatural.valSegundoApellido;

                if (!string.IsNullOrEmpty(clienteArray[0].persona.personaNatural.valPrimerNombre))
                {
                    string[] ArrayNombre;
                    ArrayNombre = clienteArray[0].persona.personaNatural.valPrimerNombre.Split(' ');
                    int index = clienteArray[0].persona.personaNatural.valPrimerNombre.IndexOf(' ');

                    if (ArrayNombre == null)
                    {
                        cliente.PrimerNombre = string.Empty;
                        cliente.SegundoNombre = string.Empty;
                    }
                    else if (ArrayNombre.Count() == 1)
                    {
                        cliente.PrimerNombre = ArrayNombre[0];
                        cliente.SegundoNombre = string.Empty;
                    }
                    else if (ArrayNombre.Count() > 1)
                    {
                        cliente.PrimerNombre = ArrayNombre[0];
                        cliente.SegundoNombre = clienteArray[0].persona.personaNatural.valPrimerNombre.ToString().Substring(index);
                    }                    
                }

                cliente.CiudadNacimiento = clienteArray[0].persona.personaNatural.valDepartementoNacimiento;
            }

            if (clienteArray[0].persona.direccion != null)
            {
                cliente.Direccion = clienteArray[0].persona.direccion.valDireccion;
                cliente.CorreoElectronico = clienteArray[0].persona.direccion.valCorreo;
                cliente.CiudadResidencia = clienteArray[0].persona.direccion.valMunicipio;
                cliente.CodigoDANE = clienteArray[0].persona.direccion.codMunicipio;
                cliente.DepartamentoResidencia = clienteArray[0].persona.direccion.valDepartamento;
                if (clienteArray[0].persona.direccion.telefono != null)
                {
                    if (clienteArray[0].persona.direccion.telefono.valPrefijo != null)                    
                        cliente.Telefono = clienteArray[0].persona.direccion.telefono.valPrefijo.Trim().Replace(" ", "") + clienteArray[0].persona.direccion.telefono.valTelefono.Trim().Replace(" ", "");                    
                    else                    
                        cliente.Telefono = clienteArray[0].persona.direccion.telefono.valTelefono.Trim().Replace(" ", "");                    
                }

                if (clienteArray[0].persona.direccion.celular != null)
                {
                    if (clienteArray[0].persona.direccion.celular.valPrefijo != null)                    
                        cliente.Celular = clienteArray[0].persona.direccion.celular.valPrefijo.Trim().Replace(" ", "") + clienteArray[0].persona.direccion.celular.valCelular.Trim().Replace(" ", "");                    
                    else
                        cliente.Celular = clienteArray[0].persona.direccion.celular.valCelular.Trim().Replace(" ", "");                    
                }
            }

            if (clienteArray[0].persona.valActividadEconomica != null)
            {
                cliente.ActividadEconomica = clienteArray[0].persona.valActividadEconomica;
            }

            if (clienteArray[0].codGenero != null)
            {
                cliente.IdGenero = ListaGeneroPublica.ObtenerListaGeneros().FirstOrDefault(r => r.Value.StartsWith(clienteArray[0].codGenero)).Key;
                cliente.Genero = ListaGeneroPublica.ObtenerListaGeneros().FirstOrDefault(r => r.Value.StartsWith(clienteArray[0].codGenero)).Value;
            }

            cliente.FechaNacimiento = clienteArray[0].fecNacimiento;
            cliente.Nacionalidad = Parametros.Nacionalidad;
            return cliente;
        }

    }
}
