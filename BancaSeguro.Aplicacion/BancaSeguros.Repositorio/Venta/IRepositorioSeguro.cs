using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancaSeguros.Entidades.Catalogo;

using BancaSeguros.Entidades.Seguro;

namespace BancaSeguros.Repositorio.Venta
{
    public interface IRepositorioSeguro
    {
        /// <summary>
        /// Get los sure a sale.
        /// </summary>
        /// <param name="idTipoDeIdentificacion">identification number.</param>
        /// <param name="fechaDeNacimientoCliente">date client.</param>
        /// <param name="genero">gender.</param>
        /// <returns>
        /// List Entity sure
        /// </returns>
        /// <remarks>
        /// Author: Wilver Guillermo Zaldua
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IEnumerable<BancaSeguros.Entidades.Seguro.Seguro> ConsultarLosSegurosAVender(int idTipoDeIdentificacion, DateTime fechaDeNacimientoCliente, int genero);

        /// <summary>
        /// Get the sure of code y insurance.
        /// </summary>
        /// <param name="codigoSeguro">The code sure.</param>
        /// <param name="codigoAseguradora">The code insurance.</param>
        /// <returns>List entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Seguro> ConsultarSegurosPorCodigoYAseguradora(int codigoSeguro, int codigoAseguradora);
    }
}
