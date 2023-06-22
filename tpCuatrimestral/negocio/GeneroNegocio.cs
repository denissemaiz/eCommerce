using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class GeneroNegocio
    {
        public List<Genero> Listar()
        {
            List<Genero> Listar = new List<Genero>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select G.ID_Categoria, G.Nombre From GENERO G");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
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

        public List<Genero> RemoveDuplicadosGenero(List<Genero> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Genero> finalList = new List<Genero>();
            foreach (Genero gen in inputList)
            {
                if (!uniqueStore.ContainsKey(gen.Nombre))
                {
                    uniqueStore.Add(gen.Nombre, "0");
                    finalList.Add(gen);
                }
            }
            return finalList;
        }
    }
}
