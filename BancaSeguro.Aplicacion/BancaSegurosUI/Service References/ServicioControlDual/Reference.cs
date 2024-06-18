﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancaSegurosUI.ServicioControlDual {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioControlDual.IServicioControlDual")]
    public interface IServicioControlDual {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/InsertarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/InsertarRegistroEfectivoResponse")]
        BancaSeguros.Entidades.General.Resultado InsertarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/InsertarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/InsertarRegistroEfectivoResponse")]
        System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> InsertarRegistroEfectivoAsync(int idAprobacionDual, string usuarioAprueba);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/ActualizarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/ActualizarRegistroEfectivoResponse")]
        BancaSeguros.Entidades.General.Resultado ActualizarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/ActualizarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/ActualizarRegistroEfectivoResponse")]
        System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> ActualizarRegistroEfectivoAsync(int idAprobacionDual, string usuarioAprueba);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/ActivarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/ActivarRegistroEfectivoResponse")]
        BancaSeguros.Entidades.General.Resultado ActivarRegistroEfectivo(int idAprobacionDual);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/ActivarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/ActivarRegistroEfectivoResponse")]
        System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> ActivarRegistroEfectivoAsync(int idAprobacionDual);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/EliminarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/EliminarRegistroEfectivoResponse")]
        BancaSeguros.Entidades.General.Resultado EliminarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/EliminarRegistroEfectivo", ReplyAction="http://tempuri.org/IServicioControlDual/EliminarRegistroEfectivoResponse")]
        System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> EliminarRegistroEfectivoAsync(int idAprobacionDual, string usuarioAprueba);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/ConsultarRegistroControlDualPorId", ReplyAction="http://tempuri.org/IServicioControlDual/ConsultarRegistroControlDualPorIdResponse" +
            "")]
        BancaSeguros.Entidades.Administracion.AprobacionDual ConsultarRegistroControlDualPorId(int idAprobacionDual);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioControlDual/ConsultarRegistroControlDualPorId", ReplyAction="http://tempuri.org/IServicioControlDual/ConsultarRegistroControlDualPorIdResponse" +
            "")]
        System.Threading.Tasks.Task<BancaSeguros.Entidades.Administracion.AprobacionDual> ConsultarRegistroControlDualPorIdAsync(int idAprobacionDual);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioControlDualChannel : BancaSegurosUI.ServicioControlDual.IServicioControlDual, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioControlDualClient : System.ServiceModel.ClientBase<BancaSegurosUI.ServicioControlDual.IServicioControlDual>, BancaSegurosUI.ServicioControlDual.IServicioControlDual {
        
        public ServicioControlDualClient() {
        }
        
        public ServicioControlDualClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioControlDualClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioControlDualClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioControlDualClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BancaSeguros.Entidades.General.Resultado InsertarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba) {
            return base.Channel.InsertarRegistroEfectivo(idAprobacionDual, usuarioAprueba);
        }
        
        public System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> InsertarRegistroEfectivoAsync(int idAprobacionDual, string usuarioAprueba) {
            return base.Channel.InsertarRegistroEfectivoAsync(idAprobacionDual, usuarioAprueba);
        }
        
        public BancaSeguros.Entidades.General.Resultado ActualizarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba) {
            return base.Channel.ActualizarRegistroEfectivo(idAprobacionDual, usuarioAprueba);
        }
        
        public System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> ActualizarRegistroEfectivoAsync(int idAprobacionDual, string usuarioAprueba) {
            return base.Channel.ActualizarRegistroEfectivoAsync(idAprobacionDual, usuarioAprueba);
        }
        
        public BancaSeguros.Entidades.General.Resultado ActivarRegistroEfectivo(int idAprobacionDual) {
            return base.Channel.ActivarRegistroEfectivo(idAprobacionDual);
        }
        
        public System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> ActivarRegistroEfectivoAsync(int idAprobacionDual) {
            return base.Channel.ActivarRegistroEfectivoAsync(idAprobacionDual);
        }
        
        public BancaSeguros.Entidades.General.Resultado EliminarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba) {
            return base.Channel.EliminarRegistroEfectivo(idAprobacionDual, usuarioAprueba);
        }
        
        public System.Threading.Tasks.Task<BancaSeguros.Entidades.General.Resultado> EliminarRegistroEfectivoAsync(int idAprobacionDual, string usuarioAprueba) {
            return base.Channel.EliminarRegistroEfectivoAsync(idAprobacionDual, usuarioAprueba);
        }
        
        public BancaSeguros.Entidades.Administracion.AprobacionDual ConsultarRegistroControlDualPorId(int idAprobacionDual) {
            return base.Channel.ConsultarRegistroControlDualPorId(idAprobacionDual);
        }
        
        public System.Threading.Tasks.Task<BancaSeguros.Entidades.Administracion.AprobacionDual> ConsultarRegistroControlDualPorIdAsync(int idAprobacionDual) {
            return base.Channel.ConsultarRegistroControlDualPorIdAsync(idAprobacionDual);
        }
    }
}