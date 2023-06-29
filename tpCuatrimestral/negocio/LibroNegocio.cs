using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using Clases;

namespace negocio
{
    public class LibroNegocio
    {
        public List<Libro> Listar() 
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select Codigo, Titulo, Descripcion, Precio, Stock from Libro");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Codigo = (string)Datos.Lector["Codigo"];
                    aux.Titulo = (string)Datos.Lector["Titulo"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    aux.Stock = (Int32)Datos.Lector["Stock"];
                    lista.Add(aux);
                }
                    return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }                               
        }


        public List<Libro> ListarLibro()
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select Codigo, Titulo, Descripcion, Precio, Stock from Libro");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Codigo = (string)Datos.Lector["Codigo"];
                    aux.Titulo = (string)Datos.Lector["Titulo"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    aux.Stock = (Int32)Datos.Lector["Stock"];
                    lista.Add(aux);
                }
                    return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }



        public void Agregar(Libro nuevo)
        {

            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Insert into Libro(Codigo, Titulo, Descripcion, Precio, Stock) VALUES('" + nuevo.Codigo + "', '" + nuevo.Titulo + "' , '" + nuevo.Descripcion + "' , '" + nuevo.Precio + "' , '" + nuevo.Stock + "')");
                Datos.EjecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                Datos.CerrarConexion();
            }

        }


        public List<Libro> RemoveDuplicadosLibro(List<Libro> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Libro> finalList = new List<Libro>();
            foreach (Libro lib in inputList)
            {
                if (!uniqueStore.ContainsKey(lib.Codigo.ToString()))
                {
                    uniqueStore.Add(lib.Codigo.ToString(), "0");
                    finalList.Add(lib);
                }
            }
            return finalList;
        }
    }
}
