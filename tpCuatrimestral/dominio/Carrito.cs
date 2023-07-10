﻿using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        private List <Libro> libros;
        private List<ProductoCarrito> productos;
        private decimal monto;

        public Carrito()
        {

        }

        public Carrito(List<Libro> libros, decimal monto)
        {
            this.libros = libros;
            this.monto = monto;
        }

        public List<Libro> Libros
        {            
            get { return libros; }
            set { libros = value; }
        }
        public List<ProductoCarrito> Productos 
        { 
            get { return productos; } 
            set { productos = value; }
        }
        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public decimal CalcularMonto()
        {
            monto = 0;
            foreach (Libro art in libros)
            {
                monto += art.Precio;
            }
            return monto;
        }

        public bool QuitarLibro(int id)
        {
            foreach (Libro art in libros)
            {
                if (art.Id == id) libros.Remove(art);
                return true;
            }
            return false;
        }

        public int contabilizarLibro(int id)
        {
            int cant = 0;
            foreach (Libro libro in libros)
            {
                if(libro.Id == id)
                    cant++;
            }
            return cant;
        }

        public void agregarProd(Libro prod)
        {
            foreach(ProductoCarrito art in productos)
            {
                if (art.CodigoLibro == prod.Codigo)
                {
                    art.agregar(prod.Codigo);
                    return;
                }

            }
            ProductoCarrito nuevo = new ProductoCarrito(prod.Codigo, prod.Precio);
            productos.Add(nuevo);
        }

       /* ~Carrito()
        {
            libros.Clear();
        }*/
    }
}
