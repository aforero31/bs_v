using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Repositorio.Seguridad
{
    internal static class Procedimientos
    {
        #region Rol

        public static string ActualizarRol = "PR_SEG_ActualizarRol";
        public static string InsertarRol = "PR_SEG_InsertarRol";
        public static string ConsultarRoles = "PR_SEG_ConsultarRoles";
        public static string ConsultarAdmonControlDual = "PR_SEG_ConsultarAdmonControlDual";
        public static string ConsultarAdmonControlDualIdMenu = "PR_SEG_ConsultarAdmonControlDualIdMenu";

        #endregion

        #region Menu

        public static string ConsultarMenu = "PR_SEG_ConsultarMenu";
        public static string ConsultarMenuControlDual = "PR_SEG_ConsultarMenuParaControlDual";

        #endregion

        #region Oficinas

        public static string ConsultarOficinas = "PR_SEG_ConsultarOficinas";
        public static string ActualizarOficina = "PR_SEG_ActualizarOficina";
        public static string GuardarLogOficinas = "PR_SEG_GuardarLogOficinas";

        #endregion

        #region Generico

        public static string ConsultarCatalogo = "PR_SEG_ConsultarCatalogo";

        public static string GuardarError = "PR_SEG_InsertarLogErrores";


        #endregion
    }
}
