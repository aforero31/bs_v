using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.Seguro;

namespace BancaSeguros.Repositorio.Venta
{
    public interface IRepositorioPlan
    {
        IEnumerable<Plan> ConsultarPlanesPorIdSeguro(int idSeguro);
    }
}
