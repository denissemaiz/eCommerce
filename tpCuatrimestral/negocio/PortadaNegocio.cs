using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PortadaNegocio
    {
        public List<Portada> Listar()
        {
            List<Portada> Listar = new List<Portada>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select P.ID_Imagen, P.ID_Libro, P.Url From PORTADA P");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Portada aux = new Portada();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.IdLibro = (int)Datos.Lector["IdLibro"];                    
                    aux.Url = (string)Datos.Lector["Url"];
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

        public List<Portada> RemoveDuplicadosPortada(List<Portada> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Portada> finalList = new List<Portada>();
            foreach (Portada port in inputList)
            {
                if (!uniqueStore.ContainsKey(port.Url))
                {
                    uniqueStore.Add(port.Url, "0");
                    finalList.Add(port);
                }
            }
            return finalList;
        }
    }
}
