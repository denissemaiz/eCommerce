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

        public List<Autor> RemoveDuplicadosGenero(List<Autor> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Autor> finalList = new List<Autor>();
            foreach (Autor aut in inputList)
            {
                if (!uniqueStore.ContainsKey(aut.Nombre))
                {
                    uniqueStore.Add(aut.Nombre, "0");
                    finalList.Add(aut);
                }
            }
            return finalList;
        }
    }
}
