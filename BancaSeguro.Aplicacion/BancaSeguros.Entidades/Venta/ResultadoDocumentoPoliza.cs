namespace BancaSeguros.Entidades.Venta
{
    using BancaSeguros.Entidades.General;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class ResultadoDocumentoPoliza
    {
        public Resultado Resultado { get; set; }

        public IEnumerable<byte> ArchivoPolizaPdf { get; set; }

        public String RutaArchivo { get; set; }

        public IEnumerable<byte> ImagenPoliza { get; set; }
    }
}
