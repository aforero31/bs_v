namespace BAC.Seguridad.Mensaje
{
    using BancaSeguros.Entidades.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGestionLog
    {
        Resultado GuardarError(int evento, Exception exc, string llave);
    }
}
