using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Compra
    {
        private int id;
        private int idCliente;
        private Carrito carrito;

        public Compra()
        {

        }

        public Compra(int id, int idCliente, Carrito carrito)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.carrito = carrito;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public Carrito Carrito
        {
            get { return carrito; }
            set { carrito = value; }
        }
    }
}
