﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.Cobis
{
    public interface IGestionTransaccion
    {
        bool ConsultarDiaHabil(DateTime dia);
    }
}
