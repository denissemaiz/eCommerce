using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal class Compra
    {
        private int id;
        private string idCliente;
        private List<int> idArticulo;
        //private List<Articulo> articulo;
        private int precioTotal;

        public Compra()
        {

        }

        public Compra(int id, string idCliente, List<int> idArticulo, int precioTotal)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.idArticulo = idArticulo;
            this.precioTotal = precioTotal;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public List<int> IdArticulo
        {
            get { return idArticulo; }
            set { idArticulo = value; }
        }
        public int PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }
    }
}
