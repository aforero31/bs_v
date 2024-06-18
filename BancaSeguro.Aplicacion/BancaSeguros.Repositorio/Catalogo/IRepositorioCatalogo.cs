using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.Catalogo;

namespace BancaSeguros.Repositorio.Catalogo
{
    public interface IRepositorioCatalogo
    {
        System.Collections.Generic.List<TipoIdentificacion> ConsultarTipoDeIdentificacion();
        
    }

}
