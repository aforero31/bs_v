

namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositorioDiaHabil
    {
        Resultado EliminarDiasHabilesApartirDeFecha(DateTime fecha);

        Resultado InsertarDiaHabil(DateTime fecha);
    }
}
