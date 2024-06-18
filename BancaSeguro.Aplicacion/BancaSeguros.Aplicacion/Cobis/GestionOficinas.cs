using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.ServiceModel;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.General;
//using ServicioCobisCatalogos;


namespace BancaSeguros.Aplicacion.Cobis
{
    public class GestionOficinas: IGestionOficinas
    {

        #region Metodos Publicos

        public ListaOficinas ConsultarOficinasServicio()
        {
            ListaOficinas OficinasServicio = new ListaOficinas();
            OficinasServicio.ListOficinas = new List<Oficina>();
            Resultado Resp = new Resultado();
            
            try
            {
                OficinasServicio = CargarOficinasServicioCobis();
            }
            catch (Exception exc)
            {
               // OficinasServicio.ListOficinas.First().Resultado.Error = true;
               //OficinasServicio.ListOficinas.First().Resultado.Mensaje = String.Concat("Se generó excepción al consultar servicio en COBIS.", exc.Message);
                OficinasServicio.Resultado.Error = true;
                OficinasServicio.Resultado.Mensaje = String.Concat("ConsultarOficinasServicio: Se generó excepción al consultar servicio en COBIS.", exc.Message);
            }

            return OficinasServicio;
        }

        #endregion

        #region Metodos Privados
        public static ListaOficinas CargarOficinasServicioCobis()
        {
            ListaOficinas Oficinas = new ListaOficinas();
            List<catalogoResult> SortCatalogo = new List<catalogoResult>();
            Oficinas.Resultado = new Resultado();
            Oficinas.ListOficinas = new List<Oficina>();
            String codCatalogo = "";
            string val = "";
            string url = ConfigurationManager.AppSettings.Get("BuscarCatalogoOficina");
            string CatalogoCodEstado = ConfigurationManager.AppSettings.Get("CatalogoCodEstado");
            string CatalogoOficinaCodClase = ConfigurationManager.AppSettings.Get("CatalogoOficinaCodClase");
            string UltimoRegistroTexto = ConfigurationManager.AppSettings.Get("UltimoRegistroTexto");

            try
            {
                RequestCatalogo requestCatalogo = GetRango(UltimoRegistroTexto);

                do
                {
                    val = REST.GetResponse_POST(url, Newtonsoft.Json.JsonConvert.SerializeObject(requestCatalogo));
                    if (val != null && val != "")
                    {
                        OficinasResult oficinas = new OficinasResult();
                        oficinas.Oficinas = new OficinasCobis();
                        oficinas.Oficinas.Catalogo = new List<catalogoResult>();

                        try
                        {
                            oficinas = Newtonsoft.Json.JsonConvert.DeserializeObject<OficinasResult>(val);
                            if (oficinas.Oficinas == null)
                            {
                                throw new Exception("Se generó la excepción - Estructura incorrecta de Cobis.");
                            }
                        }
                        catch
                        {
                            OficinasResultSingle oficinasSigle = Newtonsoft.Json.JsonConvert.DeserializeObject<OficinasResultSingle>(val);
                            oficinas.Oficinas.Catalogo.Add(oficinasSigle.Oficinas.Catalogo);
                            if (oficinas.Oficinas.Catalogo == null)
                            {
                                throw new Exception("Se generó la excepción - Estructura incorrecta de Cobis.");
                            }
                        }

                        oficinas.Oficinas.Catalogo = oficinas.Oficinas.Catalogo.OrderBy(m => m.codCatalogo).ToList();

                        foreach (catalogoResult catalogo in oficinas.Oficinas.Catalogo)
                        {
                            codCatalogo = "";
                            if (catalogo.oficina != null)
                            {
                                if ((catalogo.codEstado == CatalogoCodEstado) && (catalogo.oficina.codClase == CatalogoOficinaCodClase))
                                {
                                    Oficina Oficina = new Oficina();
                                    Oficina.IdOficina = Convert.ToInt32(catalogo.oficina.codOficina);
                                    Oficina.Nombre = catalogo.oficina.valOficina;
                                    Oficina.Ciudad = catalogo.oficina.municipio.valMunicipio;
                                    Oficina.Activo = 1;
                                    Oficinas.ListOficinas.Add(Oficina);

                                    codCatalogo = catalogo.codCatalogo;

                                }
                                else
                                {
                                    //if ((catalogo.codEstado != "V") || (catalogo.oficina.codClase == "F"))
                                    //{
                                    codCatalogo = catalogo.codCatalogo;
                                    //}
                                }
                            }
                            else
                            {
                                //if (catalogo.oficina == null)
                                //{
                                codCatalogo = catalogo.codCatalogo;
                                //}
                            }
                        }
                        requestCatalogo = null;
                        requestCatalogo = GetRango(codCatalogo);
                    }

                } while (val != null && val != "");

            }
            catch (Exception exc)
            {
                //Oficinas.ListOficinas.First().Resultado.Error = true;
                //Oficinas.ListOficinas.First().Resultado.Mensaje = String.Concat("Se generó excepción al consultar servicio en COBIS.", exc.Message);
                Oficinas.Resultado = new Resultado();
                Oficinas.Resultado.Error = true;
                int Pos = exc.Message.IndexOf("excepción", 0);
                if (Pos == -1)
                {
                    Oficinas.Resultado.Mensaje = String.Concat("CargarOficinasServicioCobis: Se generó excepción al consultar servicio en COBIS. ", exc.Message);
                }
                else
                {
                    Oficinas.Resultado.Mensaje = exc.Message;
                }
                // return Oficinas;
            }

             return Oficinas;
        }

        private static RequestCatalogo GetRango(string valUltimoRegistroPag)
        {
            RequestCatalogo requestCatalogo = new RequestCatalogo()
            {
                opBuscarCatalogoSolicitud = new OpBuscarCatalogoSolicitud()
                {
                    contextoTransaccional = new contextoTransaccional()
                    {
                        identificadorTransaccional = "1",
                        fecTransaccion = DateTime.Now.ToString("yyyy-MM-dd"),
                        codCanalOriginador = "13",
                        codProcesoOriginador = "1",
                        codFuncionalidadOriginador = "1",
                        ipConsumidor = "172.26.51.150"
                    },
                    paginacion = new paginacion()
                    {
                        valUltimoRegistroTexto = valUltimoRegistroPag,
                        valTamPagina = ConfigurationManager.AppSettings.Get("PaginacionServicioCobis"),
                        valOrdenacion = "1",
                    },
                    catalogo = new catalogo()
                    {
                        codEstado = "V",
                        codClase = "F",
                        codTabla = "cl_oficina"
                    }
                }
            };

            return requestCatalogo;

        }

        #endregion

    }
}
