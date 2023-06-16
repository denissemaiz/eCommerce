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
                Datos.Consulta("Select Id, Descripcion as Categ From CATEGORIAS");
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


        public Categoria Buscar(string busqueda, string criterio)
        {
            AccesoSQL Datos = new AccesoSQL();
            Categoria aux = new Categoria();

            try
            {
                if (ManejoDeBusqueda(busqueda, criterio))
                {
                    
                    Datos.Consulta("Select Id, Descripcion From CATEGORIAS where " + busqueda + " like " + criterio);
                    Datos.EjecutarLectura();
                    if(Datos.Lector.Read())
                    {
                        aux.Id = (int)Datos.Lector["Id"];
                        aux.Nombre = (string)Datos.Lector["Descripcion"];
                    }
                }
                return aux;
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

        private bool ManejoDeBusqueda(string busqueda, string criterio)
        {
            if (criterio == "Id")
            {
                bool isWrongType = int.TryParse(busqueda, out int id);
                return isWrongType;
            }
            else return true;
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
