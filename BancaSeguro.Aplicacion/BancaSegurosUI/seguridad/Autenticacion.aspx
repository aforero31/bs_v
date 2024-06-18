<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autenticacion.aspx.cs" Inherits="BancaSegurosUI.seguridad.Autenticacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BancaSeguros || Banco Agrario De Colombia</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />

    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/jquery/jquery.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/jquery/jquery-ui.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/bootstrap/v3.3.6/bootstrap.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/nicescroll/jquery.nicescroll.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/custom/custom.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/jquery/jquery.linq.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/jquery/jquery.linq.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/jquery/linq.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/jquery/linq.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Utilidades.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/Storage/jstorage.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/parsley/parsley.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/seguridad/Autenticacion.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("../scripts/aplicacion/Alertas.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/jqueryIntroLoader/dist/helpers/jquery.easing.1.3.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/jqueryIntroLoader/dist/helpers/spin.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/controles/jqueryIntroLoader/dist/jquery.introLoader.js")%>"></script>
    <link type="text/css" rel="stylesheet" href="<%=Page.ResolveUrl("~/css/bootstrap/v3.3.6/bootstrap.min.css")%>" />
    <link type="text/css" rel="stylesheet" href="<%=Page.ResolveUrl("~/css/controles/custom/custom.css")%>" />
    <link type="text/css" rel="stylesheet" href="<%=Page.ResolveUrl("~/scripts/controles/jqueryIntroLoader/dist/css/introLoader.css")%>" />

</head>
<body>
    <div>
        <div class="wrapper">
            <a class="hiddenanchor" id="toregister"></a>
            <a class="hiddenanchor" id="tologin"></a>
            <div id="wrapper">
                <div id="login" class="animate form" data-parsley-validate="">
                    <section class="login_content">
                        <form runat="server" id="form1">
                            <h1>Banca Seguros</h1>
                            <div>
                                <input type="text" class="form-control" placeholder="Usuario" id="txtUsuario" runat="server" required="" />
                            </div>
                            <div>
                                <input type="password" class="form-control" placeholder="Contraseña" id="txtContrasena" runat="server" required="" onkeyup="if(event.keyCode == 13) AutenticarUsuario()" />
                            </div>
                            <div>
                                <input type="button" class="btn btn-default submit" id="BtnObtener" value="Ingresar" onclick="AutenticarUsuario()" />
                            </div>
                            <div class="clearfix"></div>
                            <div class="separator">
                                <div class="clearfix"></div>
                                <br />
                                <div>
                                    <h1>
                                        <img src="<%=Page.ResolveUrl("~/imagenes/logo-banco-agrario-colombia.png")%>" width="90%" />
                                    </h1>
                                </div>
                            </div>
                        </form>
                    </section>
                    <div class="separator" style="text-align: center">
                        <div class="clearfix"></div>
                        <p>©2016 Derechos Reservados. Banco Agrario De Colombia</p>
                    </div>
                    <div class="separator" style="text-align: center">
                        <div class="clearfix"></div>
                        <p id="version"></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="Cargando" class="introLoading"></div>
</body>
</html>
