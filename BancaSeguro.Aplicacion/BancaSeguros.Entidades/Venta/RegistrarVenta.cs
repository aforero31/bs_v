namespace BancaSeguros.Entidades.Venta
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class RegistrarVenta
    {
        private int idVenta;
        private int idPlan;
        private int codigoConvenio;
        private int idSeguro;
        private string consecutivo;
        private Asesor asesor;
        private List<Beneficiario> beneficiario;
        private Cliente cliente;
        private Conyuge conyuge;
        private ProductoBancario productoBancario;
        private List<VariableVenta> variablesVenta;

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public int IdPlan
        {
            get { return idPlan; }
            set { idPlan = value; }
        }

        public int IdSeguro
        {
            get { return idSeguro; }
            set { idSeguro = value; }
        }

        public string Consecutivo
        {
            get { return consecutivo; }
            set { consecutivo = value; }
        }

        public Cliente Cliente {
            get { return cliente; }
            set { cliente = value; }
        }

        public Asesor Asesor
        {
            get { return asesor; }
            set { asesor = value; }
        }

        public List<Beneficiario> Beneficiario
        {
            get { return beneficiario; }
            set { beneficiario = value; }
        }

        public Conyuge Conyuge
        {
            get { return conyuge; }
            set { conyuge = value; }
        }

        public ProductoBancario ProductoBancario
        {
            get { return productoBancario; }
            set { productoBancario = value; }
        }

        public List<VariableVenta> VariablesVenta
        {
            get { return this.variablesVenta; }
            set { this.variablesVenta = value; }
        }

        public int CodigoConvenio
        {
            get
            {
                return codigoConvenio;
            }

            set
            {
                codigoConvenio = value;
            }
        }
    }
}
