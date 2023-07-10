using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ProductoCarrito
    {
        int cantidad;
        string codigoLibros;
        decimal precio;

        public ProductoCarrito(string codigo, decimal precio)
        {

            this.cantidad = 1;
            this.codigoLibros = codigo;
            this.precio = precio;

        }

        public ProductoCarrito()
        {
            this.cantidad=1;
        }

        public int Cantidad
        {
            get { return cantidad; }
        }

        public string CodigoLibro
        {
            get { return codigoLibros; }
            set {  codigoLibros = value; }
        }
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public decimal calcularMonto()
        {
            return precio * cantidad;
        }

        public void agregar(string codigo)
        {
            if(codigo == this.CodigoLibro)
                cantidad++;
        }
    }
}
