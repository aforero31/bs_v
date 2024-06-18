using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Venta;

namespace BancaSeguros.Aplicacion.ListasInhibitorias
{
    
    public interface IGestionListaInhibitoria
    {
        Resultado ClienteEstaEnListasInhibitoriasActual(Cliente cliente, string token);


    }
}
