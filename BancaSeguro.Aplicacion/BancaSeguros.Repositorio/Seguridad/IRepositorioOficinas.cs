using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAC.EntidadesSeguridad;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.General;

namespace BancaSeguros.Repositorio.Seguridad
{
    public interface IRepositorioOficinas
    {
        ListaOficinas ConsultarOficinas(int opcion);

        Entidades.General.Resultado ActualizarOficinas(Entidades.Catalogo.Oficina oficina);

    }
}
