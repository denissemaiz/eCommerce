using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar() 
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                //Datos.Consulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Id Categoria From ARTICULOS");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Codigo = (string)Datos.Lector["Codigo"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    //aux.IdCategoria = (List<Categoria>)Datos.Lector["Categoria"];
                    //aux.IdImagen = (List<Imagen>)Datos.Lector["Imagen"];
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

        public void Agregar(Articulo nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                //datos.Consulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, Precio) VALUES('" + nuevo.Codigo + "', '" + nuevo.Nombre + "' , '" + nuevo.Descripcion + "' , '" + nuevo.Precio + "')");
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

        public int Agregar_getId(Articulo nuevo)
        {
            AccesoSQL datos = new AccesoSQL();
            int id;

            try
            {
                //datos.Consulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, Precio, IdCategoria, IdMarca) output INSERTED.Id VALUES('" + nuevo.Codigo + "', '" + nuevo.Nombre + "' , '" + nuevo.Descripcion + "' , '" + nuevo.Precio + "')");
                id = datos.EjecutarScalar();
                
                return id;
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

        public void Modificar(Articulo modificar)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                //datos.Consulta("UPDATE ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdCategoria = @Categoria, IdMarca = @Marca Where Id = @Id ");
                
                datos.SetParametros("@Id", modificar.Id);                
                datos.SetParametros("@Codigo", modificar.Codigo);
                datos.SetParametros("@Nombre", modificar.Nombre);
                datos.SetParametros("@Descripcion", modificar.Descripcion);
                datos.SetParametros("@Precio", modificar.Precio);
                //datos.SetParametros("@Categoria", modificar.IdCategoria);
                //datos.SetParametros("@Imagen", modificar.IdImagen);

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

        public List<Articulo> Buscar(string busqueda, string criterio)
        {
            AccesoSQL Datos = new AccesoSQL();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                criterio = ManejoDeCriterio(criterio);
                //Datos.Consulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio , C.Id Categoria, M.Id Marca From ARTICULOS A Inner Join CATEGORIAS C on A.IdCategoria = C.Id where '" + busqueda + "' like " + criterio);
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)Datos.Lector["Id"];                   
                    aux.Codigo = (string)Datos.Lector["Codigo"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    //aux.IdCategoria = (List<Categoria>)Datos.Lector["Categoria"];
                    //aux.IdImagen = (List<IdImagen>)Datos.Lector["Imagen"];

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

        private string ManejoDeCriterio(string criterio)
        {
            if (criterio == "Categoria")
                return "C.Descripcion";
            return "A." + criterio;
        }

        public void Eliminar(int Id)
        {          
            try
            {
                AccesoSQL datos = new AccesoSQL();
                datos.Consulta("DELETE from ARTICULOS where Id = @Id");
                datos.SetParametros("@Id",Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public List<Articulo> RemoveDuplicadosArticulo(List<Articulo> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Articulo> finalList = new List<Articulo>();
            foreach (Articulo art in inputList)
            {
                if (!uniqueStore.ContainsKey(art.Codigo))
                {
                    uniqueStore.Add(art.Codigo, "0");
                    finalList.Add(art);
                }
            }
            return finalList;
        }
    }
}
