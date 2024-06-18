using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.Cobis
{
    [Serializable]
    public class oficinaResult
    {
        public string valOficina { get; set; }
        public string codOficina { get; set; } 
        public municipioResult municipio { get; set; }
        public string valDireccion { get; set; }
        public string codTipoOficina { get; set; }
        public string valTipoOficina { get; set; }
        public string codDepartamento { get; set; }
        public string valDepartamento { get; set; }
        public string codPais { get; set; }
        public string valPais { get; set; }
        public string codRegional { get; set; }
        public string valRegional { get; set; }
        public string codClase { get; set; }
        public string valClase { get; set; } 

        
        //"oficina":       {
        // "valOficina": "CB TRANZA SAS - MOVIL RED",
        // "codOficina": 10001,
        // "municipio":          {
        //    "codMunicipio": 11001,
        //    "valMunicipio": "BOGOTA, D.C."
        // },
        // "valDireccion": "CARRERA 21 NO 169 - 45",
        // "codTipoOficina": "O",
        // "valTipoOficina": "Oficina",
        // "codDepartamento": 11,
        // "valDepartamento": "DISTRITO CAPITAL",
        // "codPais": 1,
        // "valPais": "COLOMBIA",
        // "codRegional": 22200,
        // "valRegional": "REGIONAL BOGOTA CONSOLIDADO",
        // "codClase": "D",
        // "valClase": "NO EXISTE DATO EN CATALOGO"

    }
}
