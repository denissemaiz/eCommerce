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
                Datos.Consulta("Select A.ID_Articulo, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.Stock From ARTICULO A");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)Datos.Lector["ID_Articulo"];
                    aux.Codigo = (string)Datos.Lector["Codigo"];
                    aux.Titulo = (string)Datos.Lector["Nombre"];
                    //aux.Autores = (List<Autor>)Datos.Lector["Autores"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    aux.Stock = (Int32)Datos.Lector["Stock"];
                    //aux.Generos = (List<Genero>)Datos.Lector["Generos"];
                    //aux.Portada = (Portada)Datos.Lector["Portada"];
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
