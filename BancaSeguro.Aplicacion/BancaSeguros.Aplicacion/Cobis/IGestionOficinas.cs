using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Aplicacion;

namespace BancaSeguros.Aplicacion.Cobis
{
    public interface IGestionOficinas
    {
        ListaOficinas ConsultarOficinasServicio();
    }
}
