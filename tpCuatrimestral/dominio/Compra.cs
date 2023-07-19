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
        private string estado;
        private DateTime fechaCompra;
        private Carrito carrito;

        public Compra()
        {

        }

        public Compra(int id, int idCliente, Carrito carrito, string estado, DateTime fechaCompra)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.carrito = carrito;
            this.estado = estado;
            this.fechaCompra = fechaCompra;
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
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public DateTime FechaCompra
        {
            get { return fechaCompra; }
            set { fechaCompra = value; }
        }
    }
}
