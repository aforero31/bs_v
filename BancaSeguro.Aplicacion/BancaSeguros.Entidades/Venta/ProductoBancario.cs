namespace BancaSeguros.Entidades.Venta
{
    using General;
    using System;

    [Serializable]
    public class ProductoBancario
    {
        private int idProductoBancario;
        private int idNumeroCuenta;
        private string numeroCuenta;
        private string nombreProducto;
        private string descripcion;
        private double saldo;
        private string saldoFormatoMoneda;
        private string codigoProducto;
        private string codigoSubProducto;
        private string codigoCategoria;
        private Resultado resultado;

        public int IdProductoBancario
        {
            get { return idProductoBancario; }
            set { idProductoBancario = value; }
        }

        public int IdNumeroCuenta
        {
            get { return idNumeroCuenta; }
            set { idNumeroCuenta = value; }
        }

        public string NumeroCuenta
        {
            get { return numeroCuenta; }
            set { numeroCuenta = value; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        public string CodigoProducto
        {
            get { return codigoProducto; }
            set { codigoProducto = value; }
        }

        public string CodigoSubProducto
        {
            get { return codigoSubProducto; }
            set { codigoSubProducto = value; }
        }

        public string CodigoCategoria
        {
            get { return codigoCategoria; }
            set { codigoCategoria = value; }
        }

        public string SaldoFormatoMoneda
        {
            get { return saldoFormatoMoneda; }
            set { saldoFormatoMoneda = value; }
        }

        public Resultado Resultado
        {
            get
            {
                return resultado;
            }

            set
            {
                resultado = value;
            }
        }
    }
}
