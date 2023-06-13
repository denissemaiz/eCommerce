using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        private List <Articulo> articulos;
        private decimal monto;

        public Carrito()
        {

        }

        public Carrito(List<Articulo> articulos, decimal monto)
        {
            this.articulos = articulos;
            this.monto = monto;
        }

        public List<Articulo> Articulos
        {            
            get { return articulos; }
            set { articulos = value; }
        }
        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public decimal CalcularMonto()
        {
            monto = 0;
            foreach (Articulo art in articulos)
            {
                monto += art.Precio;
            }
            return monto;
        }

        public bool QuitarArticulo(int id)
        {
            foreach (Articulo art in articulos)
            {
                if (art.Id == id) articulos.Remove(art);
                return true;
            }
            return false;
        }

        ~Carrito()
        {
            articulos.Clear();
        }
    }
}
