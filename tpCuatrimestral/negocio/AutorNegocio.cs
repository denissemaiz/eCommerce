using Clases;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public class AutorNegocio
    {
        public List<Autor> Listar()
        {
            List<Autor> Listar = new List<Autor>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT A.ID_Autor, A.Nombre, A.Apellido FROM Autor A");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)Datos.Lector["ID_Autor"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Apellido = (string)Datos.Lector["Apellido"];
                    Listar.Add(aux);
                }
                return Listar;
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

        public void Agregar(Autor nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Autor (Nombre, Apellido) VALUES('" + nuevo.Nombre + "', '" + nuevo.Apellido + "')");
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

        public void Agregar_a_Libro(int idAutor, int idLibro)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("INSERT INTO Libro_X_Autor (ID_Autor, ID_Libro) VALUES(@ID_Autor, @ID_Libro)");
                datos.SetParametros("ID_Autor", idAutor);
                datos.SetParametros("ID_Libro", idLibro);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
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
                datos.Consulta("DELETE FROM Autor WHERE ID_Autor =" + Id);
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

        public void Modificar(Autor autor)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("UPDATE Autor SET Nombre = '" + autor.Nombre + "', Apellido = '" + autor.Apellido + "' WHERE ID_Autor = " + autor.Id);
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


        public List<Autor> BuscarAutor(string codigo)
        {
            List<Autor> lista = new List<Autor>();
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta(" Select A.ID_Autor,A.Nombre,A.Apellido from Autor A inner join Libro_X_Autor LXA on LXA.ID_Autor = A.ID_Autor inner join Libro L on L.ID_Libro = LXA.ID_Libro where L.Codigo = '" + codigo + "' ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Autor Autor = new Autor();
                    Autor.Id = (int)datos.Lector["ID_Autor"];
                    Autor.Nombre = (string)datos.Lector["Nombre"];
                    Autor.Apellido = (string)datos.Lector["Apellido"];
                    lista.Add(Autor);
                }
                return lista;
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

        public Autor BuscarAutor_ID(int id)
        {
            Autor autor = null;
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("Select * From Autor WHERE ID_Autor = @id");
                datos.SetParametros("id", id);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    autor = new Autor();
                    autor.Id = id;
                    autor.Nombre = (string)datos.Lector["Nombre"];
                    autor.Apellido = (string)datos.Lector["Apellido"];
                }
                return autor;
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

        public List<Autor> RemoveDuplicadosAutor(List<Autor> inputList)  ///va a sacra a todos los que tengan el mismo apellido
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Autor> finalList = new List<Autor>();
            foreach (Autor aut in inputList)
            {
                if (!uniqueStore.ContainsKey(aut.Apellido))
                {
                    uniqueStore.Add(aut.Apellido, "0");
                    finalList.Add(aut);
                }
            }
            return finalList;
        }
    }
}
