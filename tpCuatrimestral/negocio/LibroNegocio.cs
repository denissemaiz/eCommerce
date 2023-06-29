using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using Clases;
using negocio;

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
                Datos.Consulta("SELECT L.ID_Libro, L.Codigo, L.Titulo, /*Autores*/ L.Descripcion, L.Precio, L.Stock, /*Genero*/ L.PortadaURL FROM Libro L");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)Datos.Lector["ID_Libro"];
                    aux.Codigo = (Int16)Datos.Lector["Codigo"];
                    aux.Titulo = (string)Datos.Lector["Titulo"];
                    //aux.Autores = (List<Autor>)Datos.Lector["Autores"];*******
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    aux.Stock = (Int16)Datos.Lector["Stock"];
                    //aux.Generos = (List<Genero>)Datos.Lector["Generos"];
                    aux.PortadaURL = (string)Datos.Lector["PortadaURL"];
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
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Libro (Codigo, Titulo, Descripcion, Precio, Stock, PortadaURL) " +
                              "VALUES ('" + nuevo.Codigo + "', '" + nuevo.Titulo + "', '" + nuevo.Descripcion + "', '" + nuevo.Precio + "', '" + nuevo.Stock + "', " +
                              "'" + nuevo.PortadaURL +"')");
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public void Eliminar(int Id)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("DELETE FROM Libro_X_Autor WHERE ID_Libro = " + Id);
                datos.EjecutarAccion();

                datos.Consulta("DELETE FROM Libro WHERE ID_Libro = " + Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
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
