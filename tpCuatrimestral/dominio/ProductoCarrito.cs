using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ProductoCarrito
    {
        private int cantidad;
        //string codigoLibros;
        //decimal precio;
        private Libro libroCarrito;

        public ProductoCarrito(/*string codigo, decimal precio,*/ Libro libroCarrito)
        {

            this.cantidad = 1;
            //this.codigoLibros = codigo;
            //this.precio = precio;
            this.libroCarrito = libroCarrito;
        }

        public ProductoCarrito()
        {
            this.cantidad = 1;
            this.libroCarrito = new Libro();
        }

        public int Cantidad
        {
            get { return cantidad; }
        }

        public Libro LibroCarrito
        {
            get { return libroCarrito; }
            set { libroCarrito = value; }
        }

        public decimal Monto
        {
            get { return CalcularMonto(); }
        }

        //public string CodigoLibro
        //{
        //    get { return codigoLibros; }
        //    set {  codigoLibros = value; }
        //}
        //public decimal Precio
        //{
        //    get { return precio; }
        //    set { precio = value; }
        //}
        

        public decimal CalcularMonto()
        {
            return libroCarrito.Precio * cantidad;
        }

        public void Agregar(string codigo)
        {
            if(codigo == this.libroCarrito.Codigo)
                cantidad++;
        }
    }
}
