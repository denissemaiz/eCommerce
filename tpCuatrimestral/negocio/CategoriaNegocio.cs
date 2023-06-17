using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> Listar = new List<Categoria>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select C.ID_Categoria, C.Nombre From CATEGORIA C");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Nombre = (string)Datos.Lector["Categ"];
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

        public List<Categoria> RemoveDuplicadosCategoria(List<Categoria> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Categoria> finalList = new List<Categoria>();
            foreach (Categoria cat in inputList)
            {
                if (!uniqueStore.ContainsKey(cat.Nombre))
                {
                    uniqueStore.Add(cat.Nombre, "0");
                    finalList.Add(cat);
                }
            }
            return finalList;
        }
    }
}
